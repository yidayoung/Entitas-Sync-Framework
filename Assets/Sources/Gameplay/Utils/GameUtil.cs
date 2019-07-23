using Entitas;
using System.Collections.Generic;
using NetStack.Serialization;
using Sources.GamePlay.Common;
using UnityEngine;

namespace Util
{
    class GameUtil
    {
        public static void AddLocalActionList(GameContext gameContext, Action action)
        {
            var curTick = gameContext.tick.CurrentTick;
            if (curTick > action.Tick)
            {
                Debug.LogError($"msg timeout curTick {curTick}, actionTick {action.Tick}");
                return;
            }

            var preexist = gameContext.hasLocalActionList ? gameContext.localActionList.Actions : new List<Action>();
            var checkedTick = gameContext.hasLocalActionList ? gameContext.localActionList.CheckedTick : 0;
            preexist.Add(action);
            gameContext.ReplaceLocalActionList(preexist, checkedTick);
        }

//        public static Action TakeAction(GameContext gameContext)
//        {
//            var prevlist = gameContext.hasLoclActionList ? gameContext.loclActionList.actList : new List<Action>();
//            var checkedTick = gameContext.hasLoclActionList ? gameContext.loclActionList.checkedTick : 0;
//            var lastAction = prevlist.Find(x => x.tick > checkedTick);
//            if (lastAction != null)
//            {
//                //prevlist.RemoveAt(0);
//                gameContext.ReplaceLoclActionList(prevlist, lastAction.tick);
//                return lastAction;
//            }
//            else
//                return null;
//        }
//
//        public static Action TakeDeleteAction(GameContext gameContext)
//        {
//            var prevlist = gameContext.hasLoclActionList ? gameContext.loclActionList.actList : new List<Action>();
//            var checkedTick = gameContext.hasActionList ? gameContext.loclActionList.checkedTick : 0;
//            var lastAction = prevlist.Find(x => x.tick > checkedTick);
//            if (lastAction != null)
//            {
//                prevlist.RemoveAt(0);
//                gameContext.ReplaceLoclActionList(prevlist, lastAction.tick);
//                return lastAction;
//            }
//            else
//                return null;
//        }

        public static Vector3 CutVector(Vector3 v, int size = 4)
        {
            v.Set(CutFloat(v.x, size),
                CutFloat(v.y, size),
                CutFloat(v.z, size)
            );
            return v;
        }

        public static Vector2 CutVector(Vector2 v, int size = 4)
        {
            v.Set(CutFloat(v.x, size),
                CutFloat(v.y, size));
            return v;
        }

        public static float CutFloat(float v, int size = 4)
        {
            return float.Parse(v.ToString("F" + size));
        }

        public static ClientWorldState MakeState(GameContext game, List<GameEntity> syncBuffer)
        {
            var buffer = new BitBuffer(512);
            ushort entityCount = 0;
            var syncGroup = game.GetGroup(GameMatcher.Sync);
            syncGroup.GetEntities(syncBuffer);
            foreach (var entity in syncBuffer)
                if (!entity.isDestroyed)
                {
                    entityCount++;
                    PackEntityUtility.Pack(entity, buffer);
                }

            var worldState = new ClientWorldState {EntityCount = entityCount, Buffer = buffer};
            return worldState;
        }
    }
}