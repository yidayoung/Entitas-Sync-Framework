using System;
using Entitas;
using Sources.Networking.Server;

public class EnsureServerSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly ServerNetworkSystem _server;
    
    public EnsureServerSystem(Contexts contexts, Services services)
    {
        _context = contexts.game;
        _server = services.ServerSystem;
    }
    

    public void Initialize()
    {
        var e = _context.tickEntity;
        e.isSync = true;
        PackEntityUtility.Pack(e, _server.CreatedEntities);
        e.isWasSynced = true;
        _server.CreatedEntitiesCount++;
        _context.SetStartTime(0, DateTime.Now);
        _context.SetLastTick(0);
    }
}