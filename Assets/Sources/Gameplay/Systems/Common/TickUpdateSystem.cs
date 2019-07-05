using System;
using Entitas;

public class TickUpdateSystem : IInitializeSystem, IExecuteSystem
{
    private readonly GameContext _context;
    private DateTime startTime;

    public TickUpdateSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceTick(0);
    }

    public void Execute()
    {
        if (!_context.hasStartTime) return;
        var oldTick = _context.tick.CurrentTick;
        _context.ReplaceLastTick(oldTick);
        var timeSpan = DateTime.Now - _context.startTime.StartTime;
        var tick = (long) timeSpan.TotalMilliseconds / 20 + _context.startTime.StartTick;
        //if (tick - oldTick > 1)
        //{
        //    Debug.LogWarning("注意跳帧了！ 跳：" + oldTick + ":" + tick);
        //}
        _context.ReplaceTick(tick);
    }
}