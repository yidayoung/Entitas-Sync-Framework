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
                action.Tick = curTick+1;
            }

            var preexist = gameContext.hasLocalActionList ? gameContext.localActionList.Actions : new List<Action>();
            preexist.Add(action);
            gameContext.ReplaceLocalActionList(preexist);
        }


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