using System.Collections.Generic;
using Entitas;
using Sources.GamePlay.Common;
using Sources.Networking.Client;
using Sources.Tools;
using UnityEngine;

public class CommandMoveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _gameContext;
    private readonly IGroup<GameEntity> _movers;
    private readonly ClientNetworkSystem _client;

    public CommandMoveSystem(Contexts contexts, Services services) : base(contexts.input)
    {
        _movers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Mover));
        _gameContext = contexts.game;
        _client = services.ClientSystem;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.LeftMouse, InputMatcher.MouseDown));
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var clientId = _client.ConnectionId.Id.ToString();
            var curTick = _gameContext.tick.CurrentTick;

            var moversList = new List<GameEntity>(_movers.GetEntities());
            var curMover = moversList.Find(m => m.moverID.value == clientId);
            if (curMover == null) continue;
            var tarPosition = e.mouseDown.position;
            var command = new ClientBeeMoveCommand {Tick = curTick + 1, Target = tarPosition};
            var moveAction = new MoveAction(command, clientId);
            Util.GameUtil.AddLocalActionList(_gameContext, moveAction);
            _client.EnqueueCommand(command);
        }
    }
}