using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using NetStack.Serialization;
using Sources.GamePlay.Common;
using UnityEngine;
using Util;
using Action = Sources.GamePlay.Common.Action;

delegate string TakeKeyMethod(GameEntity e);

delegate GameEntity RollBackMethod(GameContext context, GameEntity le, GameEntity se);

/// <summary>
/// 根据服务器返回的状态修复当前状态
/// 所谓修复就是根据服务器提供的一个过去的绝对正确的镜像和本地的操作队列演算出来新的客户端状态，然后进行覆盖
/// </summary>
public class StateFixSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    private readonly GameContext _backGameContext;
    private readonly GameContext _tmpGameContext;

    private BitBuffer serverBuffer, localBuffer;

    public StateFixSystem(Contexts contexts, Services services) : base(services.BackContext)
    {
        _context = contexts.game;
        _backGameContext = services.BackContext;
        _tmpGameContext = new GameContext();
        _tmpGameContext.AddEntityIndex(new PrimaryEntityIndex<GameEntity, ushort>(
            "Id",
            _tmpGameContext.GetGroup(GameMatcher.Id),
            (e, c) => ((IdComponent) c).Value));
        serverBuffer = new BitBuffer(512);
        localBuffer = new BitBuffer(512);
    }


    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Tick);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.tick.CurrentTick > 0;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (!_context.hasClientWorldStateList) return;
        var serverTick = _backGameContext.tick.CurrentTick;
        var worldStates = EnsureClientState(serverTick);
        ExeState(worldStates[serverTick], serverTick);
        CleanStats(worldStates);
        CleanLocalActions(serverTick);
    }

    private void CleanStats(Dictionary<long, ClientWorldState> worldStates)
    {
        var flag = false;
        var curTick = _backGameContext.tick.CurrentTick;
        foreach (var state in worldStates.ToList())
        {
            if (state.Key >= curTick) continue;
            worldStates.Remove(state.Key);
            flag = true;
        }

        if (flag)
        {
            _context.ReplaceClientWorldStateList(worldStates);
        }
    }

    private Dictionary<long, ClientWorldState> EnsureClientState(long serverTick)
    {
        var worldStates = _context.clientWorldStateList.WorldStates;
        if (worldStates.ContainsKey(serverTick)) return worldStates;
        Debug.LogWarning($"客户端镜像不存在, 服务器帧为{serverTick}");
        var curTickState = GameUtil.MakeState(_context, new List<GameEntity>(256));
        for (var tick = serverTick; tick <= _context.tick.CurrentTick; tick++)
        {
            if (worldStates.ContainsKey(tick)) continue;
            worldStates.Add(tick, curTickState);
        }

        _context.ReplaceClientWorldStateList(worldStates);
        //如果当时客户端的版本和当前服务器同步环境对比结果不相同，则对客户端版本进行修正
        return worldStates;
    }


    private void ExeState(ClientWorldState clientState, long serverTick)
    {
        if (!NeedRollBack(clientState)) return;
        // 粗暴的直接进行覆盖不太好，Entity上可能绑定了已经初始化好的Object，这些Object没必要释放重新创建@TODO
        Debug.Log($"check失败，需要回滚，当前环境为:{_context.tick.CurrentTick}帧，将回滚到：{serverTick}帧");
        RollBackContext(_context, _backGameContext);
        _context.ReplaceLastTick(serverTick);
    }

    private void CleanLocalActions(long serverTick)
    {
        var localActList = _context.hasLocalActionList ? _context.localActionList.Actions : new List<Action>();
        localActList.RemoveAll(x => x.Tick < serverTick);
        _context.ReplaceLocalActionList(localActList, 0);
    }

    /// <summary>
    /// 这里比较的是通过客户端的缓存还原出来的和服务器时间对应的过去状态和当前服务器状态的比较
    /// 这里只能确认当前演播环境需不需要回滚，但是并不能得到演播环境应该如何回滚，只有演播环境自己才能做自己的回滚
    /// </summary>
    /// <param name="clientState"></param>
    /// <returns></returns>
    private bool NeedRollBack(ClientWorldState clientState)
    {
        _tmpGameContext.Reset();

        clientState.Buffer.Reset();
        UnpackEntityUtility.CreateEntities(_tmpGameContext, clientState.Buffer, clientState.EntityCount);

        #region Movers

        var moverMatcher = GameMatcher.Mover;

        string TakeMoverIdMethod(GameEntity e)
        {
            return e.moverID.value;
        }

        if (!SameEntices(moverMatcher, TakeMoverIdMethod, _backGameContext, _tmpGameContext))
        {
            return true;
        }

        #endregion

        #region Ice

        var iceMatcher = GameMatcher.Ice;

        string TakeIceOwnerMethod(GameEntity e)
        {
            return e.ice.Owner;
        }

        return !SameEntices(iceMatcher, TakeIceOwnerMethod, _backGameContext, _tmpGameContext);

        #endregion
    }

    private bool SameEntices(IMatcher<GameEntity> matcher, TakeKeyMethod takeKeyMethod,
        GameContext backGameContext, GameContext tmpGameContext)
    {
        var serverEntices = new List<GameEntity>(backGameContext.GetEntities(matcher));
        var localEntices = new List<GameEntity>(tmpGameContext.GetEntities(matcher));

        foreach (var serverEntity in serverEntices)
        {
            if (serverEntity.isDestroyed) continue;

            bool FindPredicate(GameEntity x) => takeKeyMethod(x) == takeKeyMethod(serverEntity);
            var localEntity = localEntices.Find(FindPredicate);
            if (localEntity == null)
            {
                return false;
            }

            if (!CompareEntityUtility.Equals(localEntity, serverEntity, localBuffer, serverBuffer))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 根据服务器环境还原当前播放环境
    /// </summary>
    /// <param name="context"></param>
    /// <param name="serverContext"></param>
    private void RollBackContext(GameContext context, GameContext serverContext)
    {
        #region Movers

        var moverMatcher = GameMatcher.Mover;

        string TakeMoverIdMethod(GameEntity e)
        {
            return e.moverID.value;
        }

        RollBackEntityIfNeed(context, serverContext, moverMatcher, TakeMoverIdMethod, RollBackMover);

        //@TODO 被服务器check过的做标记，没做标记的放在最后统一删除，然后清除check标记

        #endregion

        #region Ice

        var iceMatcher = GameMatcher.Ice;

        string TakeIceOwnerMethod(GameEntity e)
        {
            return e.ice.Owner;
        }

        RollBackEntityIfNeed(context, serverContext, iceMatcher, TakeIceOwnerMethod, RollBackIce);

        #endregion

        #region Clean

        var dirtyEntities = context.GetEntities(GameMatcher.Sync);
        foreach (var entity in dirtyEntities)
        {
            if (entity.isWasSynced)
            {
                entity.isWasSynced = false;
            }
            else
            {
                entity.isDestroyed = true;
            }
        }

        #endregion
    }

    private void RollBackEntityIfNeed(GameContext context, GameContext serverContext, IMatcher<GameEntity> matcher,
        TakeKeyMethod takeKeyMethod, RollBackMethod rollBackMethod)
    {
        var serverEntities = new List<GameEntity>(serverContext.GetEntities(matcher));
        var localEntities = new List<GameEntity>(context.GetEntities(matcher));

        foreach (var serverEntity in serverEntities)
        {
            if (serverEntity.isDestroyed) continue;

            bool FindPredicate(GameEntity x) => takeKeyMethod(x) == takeKeyMethod(serverEntity);
            var localEntity = localEntities.Find(FindPredicate);
            if (localEntity == null || !CompareEntityUtility.Equals(localEntity, serverEntity, localBuffer, serverBuffer))
            {
                localEntity = rollBackMethod(_context, localEntity, serverEntity);   
                if (localEntity.isMover)
                {
                    Debug.LogWarningFormat($"Mover校验失败，进行覆盖 ID: {localEntity.moverID.value} curTick: {_backGameContext.tick.CurrentTick}");    
                }
                else if (localEntity.hasIce)
                {
                    Debug.LogWarningFormat($"Ice校验失败，进行覆盖 Owner:{localEntity.ice.Owner} curTick: {_backGameContext.tick.CurrentTick}");
                }
            }

            localEntity.isWasSynced = true;
            
        }
    }

    private GameEntity RollBackMover(GameContext context, GameEntity localMover, GameEntity serverMover)
    {
        return CopyEntityBase(context, localMover, serverMover);
    }

    private GameEntity CopyEntityBase(GameContext context, GameEntity localEntity, GameEntity serverEntity)
    {
        if (localEntity == null)
        {
            localEntity = context.CreateEntity();
        }

        GameObject obj = null;
        if (localEntity.hasView)
        {
            obj = localEntity.view.gameObject;
        }

        localEntity.RemoveAllComponents();
        serverBuffer.Clear();
        PackEntityUtility.Pack(serverEntity, serverBuffer);
        DoCover(serverBuffer, localEntity);

        if (localEntity.hasId)
        {
            localEntity.RemoveId();
        }

        if (obj != null)
        {
            localEntity.AddView(obj);
        }

        return localEntity;
    }

    private static void DoCover(BitBuffer buffer, GameEntity localEntity)
    {
        buffer.Reset();
        UnpackEntityUtility.MakeEntity(localEntity, buffer);
    }

    private GameEntity RollBackIce(GameContext context, GameEntity localIce, GameEntity serverIce)
    {
        localIce = CopyEntityBase(context, localIce, serverIce);
        if (!localIce.hasDestroyedListener)
        {
            localIce.AddDestroyedListener(new IceDestoryListener());
        }

        return localIce;
    }
}