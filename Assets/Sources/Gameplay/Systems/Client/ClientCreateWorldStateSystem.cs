using System.Collections.Generic;
using Entitas;
using Util;


namespace Sources.Gameplay.Systems.Client
{
    /// <summary>
    /// 客户端保存每帧的镜像，用来将来和服务器版本进行对比
    /// 保存的方式就是讲当前所有带Sync标签的Entity都进行序列化并进行存储
    /// </summary>
    public class ClientCreateWorldStateSystem : ReactiveSystem<GameEntity>
    {
        private readonly List<GameEntity> _syncBuffer = new List<GameEntity>(256);
        private readonly IGroup<GameEntity> _syncGroup;
        private readonly GameContext _game;

        public ClientCreateWorldStateSystem(Contexts contexts) : base(contexts.game)
        {
            _game = contexts.game;
            _syncGroup = _game.GetGroup(GameMatcher.Sync);
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
            GameUtil.MakeState(_game, _syncBuffer);
            
        }
    }
}