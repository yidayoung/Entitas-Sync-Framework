using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderDirectionSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;

    public RenderDirectionSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Direction);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDirection && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var ang = e.direction.Value;
            var tarRotation = Quaternion.AngleAxis(ang - 90, Vector3.forward);
            e.view.gameObject.transform.rotation = Quaternion.RotateTowards(tarRotation, Quaternion.identity, Time.deltaTime * 100);
        }
    }
}