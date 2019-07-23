using System.Collections.Generic;
using Entitas;
using Sources.Networking.Server;

public class ServerCaptureRemovedMoverIDSystem : ReactiveSystem<GameEntity>
{
	private readonly ServerNetworkSystem _server;
	public ServerCaptureRemovedMoverIDSystem (Contexts contexts, Services services) : base(contexts.game)
	{
		_server = services.ServerSystem;
	}
		
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.MoverID.Removed());
	}
		
	protected override bool Filter(GameEntity entity)
	{
        return !entity.isDestroyed && entity.isWasSynced && !entity.hasMoverID;
	}

	protected override void Execute(List<GameEntity> entities) {
		if (_server.State != ServerState.Working) return;

        foreach (var e in entities) {
		    _server.RemovedComponents.AddUShort(e.id.Value);
			_server.RemovedComponents.AddUShort(7);
		    _server.RemovedComponentsCount++;
		}
	}
}