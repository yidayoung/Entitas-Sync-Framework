using Entitas;
using System.Collections.Generic;
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
                Debug.Log($"msg timeout curTick {curTick}, actionTick {action.Tick}");
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

        
    }
}
