using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using Sources.GamePlay.Common;
using Sources.Networking.Client;
using UnityEngine;
using Util;


public class CreateMoverSystem : ReactiveSystem<InputEntity>
{
    readonly GameContext _gameContext;
    readonly InputContext _inputContext;
    readonly IGroup<GameEntity> _movers;
    private readonly ClientNetworkSystem _client;

    public CreateMoverSystem(Contexts contexts, Services services) : base(contexts.input)
    {
        _gameContext = contexts.game;
        _inputContext = contexts.input;
        ContextEntityChanged cachedDestroyEntity = Destroymover;
        _gameContext.OnEntityWillBeDestroyed += cachedDestroyEntity;
        _movers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Mover));
        _client = services.ClientSystem;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.RightMouse, InputMatcher.MouseDown));
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var moversList = new List<GameEntity>(_movers.GetEntities());
        var clientId = _client.ConnectionId.Id.ToString();
        var curMover = moversList.Find(m => m.moverID.value == clientId);

        if (curMover != null)
        {
            return;
        }
        
        foreach (var e in entities)
        {
            var position = e.mouseDown.position;
            var direction = Random.Range(0, 360);
            var mover = _gameContext.CreateEntity();
            mover.AddMoverID(_client.ConnectionId.Id.ToString());
            mover.isMover = true;
            mover.AddPosition(position);
            mover.AddViewPosition(position);
            mover.AddDirection(direction);
            mover.AddSprite("Bee");
            var createCommand = new ClientCreateBeeCommand
            {
                Position = position, Direction = direction,
                Tick = _gameContext.tick.CurrentTick, Sprite = "bee"
            };
            var createAction = new CreateAction(createCommand, _client.ConnectionId.Id.ToString());
            GameUtil.AddLocalActionList(_gameContext, createAction);
            _client.EnqueueCommand(createCommand);
        }
    }


    protected virtual void Destroymover(IContext context, IEntity e)
    {
        var entity = (GameEntity) e;
        if (entity.hasView)
        {
            entity.view.gameObject.Unlink();
            GameObject.Destroy(entity.view.gameObject);
        }
    }
}