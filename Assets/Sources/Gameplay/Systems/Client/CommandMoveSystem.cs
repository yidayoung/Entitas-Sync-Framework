using System.Collections.Generic;
using Entitas;
using Sources.GamePlay.Common;
using Sources.Networking.Client;

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
            var moversList = new List<GameEntity>(_movers.GetEntities());
            var curMover = moversList.Find(m => m.moverID.value == clientId);
            if (curMover == null) continue;
            var curTick = _gameContext.lastTick.Value + 1;
            var tarPosition = e.mouseDown.position;
            var moverDirection = curMover.direction.Value;
            if (curMover.hasMove)
            {
                curMover.ReplaceMove(tarPosition, curTick, moverDirection);
            }
            else
            {
                curMover.AddMove(tarPosition, curTick, moverDirection);
            }
            curMover.isMoveComplete = false;
            curMover.ReplaceLastMoveTick(curTick);
            var command = new ClientBeeMoveCommand {Tick = curTick, Target = tarPosition};
            var moveAction = new MoveAction(command, curMover.moverID.value);
            Util.GameUtil.AddLocalActionList(_gameContext, moveAction);
            _client.EnqueueCommand(command);


        }
    }
}