using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using Sources.GamePlay.Common;
using Sources.Networking.Client;
using UnityEngine;
using Util;
using Logger = Sources.Tools.Logger;


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
//        ContextEntityChanged cachedDestroyEntity = Destorymover;
//        _gameContext.OnEntityWillBeDestroyed += cachedDestroyEntity;
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
        var curTick = _gameContext.tick.CurrentTick;

        if (curMover != null)
        {
            var iceCommand = new ClientCreateIceCommand
            {
                Tick = curTick + 1,
                LastsTick = 150
            };
            var iceAction = new IceAction(iceCommand, clientId);
            GameUtil.AddLocalActionList(_gameContext, iceAction);
            _client.EnqueueCommand(iceCommand);
            return;
        }

        foreach (var e in entities)
        {
            var position = e.mouseDown.position;
            var direction = Random.Range(0, 360);
            var createCommand = new ClientCreateBeeCommand
            {
                Position = position, Direction = direction,
                Tick = curTick + 1, Sprite = "bee"
            };
            var createAction = new CreateAction(createCommand, clientId);
            Debug.Log($"createAction : ${position.x:f5},{position.y:f5}");
            GameUtil.AddLocalActionList(_gameContext, createAction);
            _client.EnqueueCommand(createCommand);
        }
    }
    
}