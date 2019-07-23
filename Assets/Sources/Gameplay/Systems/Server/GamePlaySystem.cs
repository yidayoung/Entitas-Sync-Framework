using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;
using Util;
using Action = Sources.GamePlay.Common.Action;

public class GamePlaySystem : IExecuteSystem
{
    private readonly GameContext _context;
    private readonly IGroup<GameEntity> _movers;
    private IGroup<GameEntity> _fixers;
    private const float MoveSpeed = 0.08f;
    private const float RoteSpeed = 4f;
    private readonly List<GameEntity> _syncBuffer = new List<GameEntity>(256);
    private readonly IGroup<GameEntity> _ices;


    public GamePlaySystem(Contexts contexts)
    {
        _context = contexts.game;
        _movers = _context.GetGroup(GameMatcher.Mover);
        _ices = _context.GetGroup(GameMatcher.Ice);
//        _fixers = contexts.game.GetGroup(GameMatcher.Checked);
    }

    /// <inheritdoc />
    /// 游戏的主体更新逻辑，服务器和客户端同源，不做资源界面相关，只做逻辑
    /// 对于服务器和客户端都是拿到符合当前计算帧区间的动作列表进行套用，然后更新单帧内的运算逻辑
    /// 运算到当前帧，不包括当前帧为止
    public void Execute()
    {
        if (!_context.hasLastTick) return;
        var localActList = _context.hasLocalActionList ? _context.localActionList.Actions : new List<Action>();
        var localActionIndex = 0;
        var curTick = _context.tick.CurrentTick;
        var lastTick = _context.lastTick.Value;
        localActList.Sort();

#if CLIENT_MOD
        var clientWorldStates = _context.hasClientWorldStateList
            ? _context.clientWorldStateList.WorldStates
            : new Dictionary<long, ClientWorldState>();
#endif

        for (var tick = lastTick + 1; tick <= curTick; tick++)
        {
            DoTick(ref localActionIndex, localActList, tick);
#if CLIENT_MOD
            AddState(tick, clientWorldStates);
#endif
        }

#if CLIENT_MOD
        _context.ReplaceClientWorldStateList(clientWorldStates);
#endif
        _context.ReplaceLastTick(curTick);
    }

    private void AddState(long tick, IDictionary<long, ClientWorldState> clientWorldStates)
    {
        //有ID就是服务器模式，暂时客户端和服务器都是带宏的所以只能暂时这样
        if (_context.tickEntity.hasId) return;
        var curState = GameUtil.MakeState(_context, _syncBuffer);
        if (clientWorldStates.ContainsKey(tick))
        {
            clientWorldStates.Remove(tick);
        }
        clientWorldStates.Add(tick, curState);
    }

    private void DoTick(ref int i, IReadOnlyList<Action> actions, long tick)
    {
        while (i < actions.Count)
        {
            var action = actions[i];
            if (action.Tick == tick)
            {
                action.ApplyAction(_context);
                i++;
            }
            else if (action.Tick > tick)
            {
                break;
            }
            else
            {
                i++;
            }
        }

        #region Move

        foreach (var e in _movers.GetEntities())
        {
            if (e.hasMove && tick > e.move.move_time)
            {
                DoMove(e, tick);
            }
        }

        #endregion

        #region Destory Ice

        foreach (var ice in _ices.GetEntities())
        {
            if (ice.ice.StartTick + ice.ice.LastsTick < tick)
            {
                ice.isDestroyed = true;
            }
        }

        #endregion
    }

    /// <summary>
    /// 验算一个移动体一帧内的移动结果
    /// </summary>
    /// <param name="e"></param>
    /// <param name="curTick"></param>
    private void DoMove(GameEntity e, long curTick)
    {
        var lastTick = e.lastMoveTick.value;
        
        if (!IsFreeze(e, _ices.GetEntities(), lastTick + 1))
        {
            var curPosition = e.position.Value;

            var dirCur = e.move.target - curPosition;
            var newPosition = GameUtil.CutVector(curPosition + MoveSpeed * dirCur.normalized);
            var dirNew = newPosition - curPosition;

            if (dirNew.sqrMagnitude < dirCur.sqrMagnitude)
            {
                e.ReplaceDirection(CalcNextDirection(e));
                e.ReplacePosition(newPosition);
//                Debug.Log($"set lastmove {lastTick +1 } curTick : {_context.tick.CurrentTick}");
                e.ReplaceLastMoveTick(lastTick + 1);
            }
            else
            {
                e.RemoveMove();
                e.isMoveComplete = true;
                e.RemoveLastMoveTick();
            }
        }
        else
        {
//            Debug.Log($"set lastmove {lastTick +1 } curTick : {_context.tick.CurrentTick}");
            e.ReplaceLastMoveTick(lastTick + 1);
        }
    }

    private static bool IsFreeze(GameEntity e, IEnumerable<GameEntity> ices, long curTick)
    {
        return ices.Select(iceEntity => iceEntity.ice)
            .Where(ice => curTick >= ice.StartTick && curTick <= ice.StartTick + ice.LastsTick)
            .Any(ice => ice.Owner != e.moverID.value);
    }

    /// <summary>
    /// 计算一个mover移动一帧后的新的角度，也就是根据当前方向和目标方向，得到是否应该旋转，如果要旋转，旋转固定角度*方向
    /// </summary>
    /// <param name="mover"></param>
    /// <returns>newDirection(float)</returns>
    private static float CalcNextDirection(GameEntity mover)
    {
        var move = mover.move;
        var dir = move.target - mover.position.Value;

        var curAngle = mover.direction.Value;
        var tarAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (Math.Abs(curAngle - tarAngle) < RoteSpeed)
        {
            return GameUtil.CutFloat(tarAngle);
        }

        float add;
        if (curAngle > tarAngle)
        {
            add = -RoteSpeed;
        }
        else
        {
            add = RoteSpeed;
        }

        //如果旋转后和目标角度的绝对差值变小了那就转动，否则就不转
        return Math.Abs(curAngle + add - tarAngle) < Math.Abs(curAngle - tarAngle) ?
            GameUtil.CutFloat(curAngle + add) : GameUtil.CutFloat(tarAngle);
    }
}