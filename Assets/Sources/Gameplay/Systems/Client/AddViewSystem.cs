using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class AddViewSystem : ReactiveSystem<GameEntity>
{
    private readonly Transform _viewContainer = new GameObject("Game Views").transform;

    public AddViewSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && !entity.hasView && !entity.isDestroyed;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var go = new GameObject("Game View");
            go.transform.SetParent(_viewContainer, false);
            go.transform.localScale = new Vector3(0.25f, 0.25f, 1);
            if (e.hasPosition)
            {
                go.transform.position = e.position.Value;
            }
            e.AddView(go);
            go.Link(e);
        }
    }
}