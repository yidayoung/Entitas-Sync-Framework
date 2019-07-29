using System.Collections.Generic;
using Codegen.CodegenAttributes;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sources.GamePlay.Common;


[Game, Unique]
[Sync]
public partial class TickComponent : IComponent
{
    public long CurrentTick;
}

[Game, Unique]
public class LastTickComponent : IComponent
{
    public long Value;
}

[Game, Unique]
public class LocalActionListComponent : IComponent
{
    public List<Action> Actions;
}

[Game, Unique]
public class StartTimeComponent : IComponent
{
    public long StartTick;
    public System.DateTime StartTime;
}


[Game, Unique]
public class NetCommandsComponent : IComponent
{
    public List<ICommand> Commands;
}

[Game, Unique]
public class GamePlaySystemComponent : IComponent
{
    public GamePlaySystem GamePlaySystem;
}