using System;
using System.Collections.Generic;


namespace Sources.GamePlay.Common
{
    public enum ActionType
    {
        Create = 1,
        Move
    }

    public class Action : IComparable<Action>
    {
        public readonly long Tick;
        private readonly ActionType _type;
        protected readonly ICommand Command;
        protected readonly string Id;

        protected Action(ICommand command, long tick, ActionType type, string id)
        {
            Tick = tick;
            _type = type;
            Id = id;
            Command = command;
        }

        public virtual void ApplyAction(GameContext gameContext)
        {
        }


        public int CompareTo(Action other)
        {
            if (Tick > other.Tick)
                return 1;
            if (Tick == other.Tick)
                return 0;
            return -1;
        }

        public override bool Equals(object obj)
        {
            return obj is Action action &&
                   Tick == action.Tick &&
                   _type == action._type &&
                   Id == action.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "tick:" + Tick + " type:" + _type + " id:" + Id;
        }
    }

//    public class IceAction : Action
//    {
//        readonly long lasts;
//        public IceAction(long startTick, long lasts, string owner) : base(startTick, NetUtil.ICE, owner)
//        {
//            this.lasts = lasts;
//            Id = owner;
//        }
//
//        public IceAction(ByteBuffer buffer) : base(buffer, NetUtil.ICE)
//        {
//            lasts = buffer.ReadLong();
//        }
//
//        public override byte[] Format()
//        {
//            ByteBuffer buffer = new ByteBuffer();
//            buffer.WriteString(Util.NetUtil.ICE);
//            buffer.WriteLong(Tick);
//            buffer.WriteString(Id);
//            buffer.WriteLong(lasts);
//            return buffer.Getbuffer();
//        }
//
//        private bool HasMe(GameContext gameContext)
//        {
//            var _ices = new List<GameEntity>(gameContext.GetGroup(GameMatcher.Ice).GetEntities());
//            if (_ices.Find(x => x.ice.owner == Id) != null)
//            {
//                return true;
//            }
//            return false;
//        }
//        public override void ApplyAction(GameContext gameContext, InputContext inputContext)
//        {
//            //冰块生效逻辑
//            //检查当前冰块是否已经过期如果过期就什么都不做
//            //检查当前环境中是否有完全相同的冰块，如果有就什么都不做
//            //如果没有就创建冰块
//            //if (tick + lasts < gameContext.tick.currentTick)
//            //{
//            //    return;
//            //}
//            //if (HasMe(gameContext))
//            //{
//            //    return;
//            //}
//            var Ice = gameContext.CreateEntity();
//            Ice.AddIce(Id, Tick, lasts);
//            Ice.isChecked = true;
//            Ice.AddSprite("ice");
//            base.ApplyAction(gameContext, inputContext);
//        }
//
//    }

    public class CreateAction : Action
    {
        public CreateAction(ClientCreateBeeCommand command, string moverId) : base(command, command.Tick,
            ActionType.Create, moverId)
        {
        }


        public override void ApplyAction(GameContext gameContext)
        {
            var movers = gameContext.GetGroup(GameMatcher.Mover);
            var curEntities = new List<GameEntity>(movers.GetEntities());
            var command = (ClientCreateBeeCommand) Command;
            if (curEntities.Exists(x => x.moverID.value == Id)) return;
            var mover = gameContext.CreateEntity();
            mover.isMover = true;
            mover.AddPosition(command.Position);
            mover.AddViewPosition(command.Position);
            mover.AddDirection(command.Direction);
            mover.AddSprite(command.Sprite);
            mover.AddMoverID(Id);
            mover.isSync = true;
        }

        public override string ToString()
        {
            return "do_create:" + base.ToString();
        }
    }

    public class MoveAction : Action
    {
        public MoveAction(ClientBeeMoveCommand command, string id)
            : base(command, command.Tick, ActionType.Move, id)
        {
        }

        public override void ApplyAction(GameContext gameContext)
        {
            var movers = gameContext.GetGroup(GameMatcher.Mover);
            var curEntities = new List<GameEntity>(movers.GetEntities());
            var e = curEntities.Find(x => x.moverID.value == Id);
            var command = (ClientBeeMoveCommand) Command;
            e.ReplaceMove(command.Target, Tick, 0f);
            e.isMoveComplete = false;
            e.ReplaceLastMoveTick(Tick);
            //Debug.Log("call Apply Action curTick:" + gameContext.tick.currentTick + " action:" + this);
        }

        public override string ToString()
        {
            return "do_move" + base.ToString();
        }
    }
}