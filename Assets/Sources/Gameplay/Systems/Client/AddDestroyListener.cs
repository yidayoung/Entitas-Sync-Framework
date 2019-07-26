using System.Collections.Generic;
using Entitas;
using Sources.GamePlay.Common;

public class AddDestroyListener : ReactiveSystem<GameEntity>
{
    public AddDestroyListener(Contexts contexts) : base(contexts.game)
    {
    }

    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.View);
    }

    protected override bool Filter(GameEntity entity)
    {
        return !entity.hasDestroyedListener && !entity.isDestroyed && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.AddDestroyedListener(new ViewDestroyListener());
        }
    }
}