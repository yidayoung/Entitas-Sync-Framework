using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Sources.GamePlay.Common;
using Action = Sources.GamePlay.Common.Action;

public class GamePlaySystem : IExecuteSystem
{
    private readonly GameContext _context;
    private readonly IGroup<GameEntity> _movers;
    private IGroup<GameEntity> _fixers;
    private const float MoveSpeed = 0.08f;
    private const float _roateSpeed = 4f;

    public GamePlaySystem(Contexts contexts)
    {
        _context = contexts.game;
        _movers = contexts.game.GetGroup(GameMatcher.Mover);
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
        for (var tick = lastTick; tick < curTick; tick++)
        {
            while (localActionIndex < localActList.Count)
            {
                var action = localActList[localActionIndex];
                if (action.Tick == tick)
                {
                    action.ApplyAction(_context);
                    localActionIndex++;
                }
                else if (action.Tick > tick)
                {
                    break;
                }
                else
                {
                    localActionIndex++;
                }
            }
            #region Move

            foreach (var e in _movers.GetEntities())
            {
                if (!e.isMoveComplete && e.hasMove && (tick > e.move.move_time) && e.lastMoveTick.value < tick)
                {
                    DoMove(e, tick);
                }
            }

            #endregion
        }
        localActList.RemoveRange(0, localActionIndex);
        _context.ReplaceLocalActionList(localActList, 0);
    }

    
    
    private static void DoMove(GameEntity e, long curTick)
    {
        var lastTick = e.lastMoveTick.value;

//        if (!IsFreeze(e, _ices.GetEntities(), lastTick + addOnce))
        var curPosition = e.position.Value;
        {
            var dirCur = e.move.target - curPosition;
            var newPosition = curPosition + MoveSpeed * dirCur.normalized;
            var dirNew = newPosition - curPosition;

            //Debug.Log("dirNew.sqrMagnitude - dirCur.sqrMagnitude" + dirNew.sqrMagnitude + " - " + dirCur.sqrMagnitude);
            if (dirNew.sqrMagnitude < dirCur.sqrMagnitude)
            {
                e.ReplaceDirection(CalcCurDirection(e, curTick));
                e.ReplacePosition(newPosition);
                e.ReplaceLastMoveTick(lastTick + 1);
                //Debug.Log("do move " + "cur Tick " + curTick + " RealTick:" + (lastTick + addOnce) 
                //    + "curPostion: " + curPosition.ToString("F5") + " lastMoveTick:" + lastTick + "\n" +
                //    "dirNew.sqrMagnitude - dirCur.sqrMagnitude" + dirNew.sqrMagnitude + " - " + dirCur.sqrMagnitude + "this: " + _game_context.ToString());
                //Debug.Log("dirNew.sqrMagnitude - dirCur.sqrMagnitude" + dirNew.sqrMagnitude + " - " + dirCur.sqrMagnitude);
            }
            else
            {
                //Debug.Log("move complete! tarPostion :" + e.move.target.ToString("F5") + "clientID:" + e.moverID.value);
                //Debug.Log("cur Tick " + (lastTick + addOnce) + "curPostion: " + e.position.value.ToString("F5")); 
                e.RemoveMove();
                e.isMoveComplete = true;
                e.RemoveLastMoveTick();
            }
        }
//        else
//        {
//            e.ReplaceLastMoveTick(lastTick + addOnce);
//        }
    }

    private static float CalcCurDirection(GameEntity mover, long curTick)
    {
        var move = mover.move;
        Vector2 dir = move.target - mover.position.Value;

        float curAngle = mover.direction.Value;
        float tarAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        float add;
        if (curAngle > tarAngle)
        {
            add = -_roateSpeed;
        }
        else
        {
            add = _roateSpeed;
        }

        //如果旋转后和目标角度的绝对差值变小了那就转动，否则就不转
        if (Math.Abs(curAngle + add - tarAngle) < Math.Abs(curAngle - tarAngle))
        {
            return curAngle + add;
        }

        return tarAngle;
    }
}