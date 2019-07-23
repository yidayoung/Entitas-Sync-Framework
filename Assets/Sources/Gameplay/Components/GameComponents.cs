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

//
//[Game, Unique]
//public class LogicSystemComponent : IComponent
//{
//    public Systems systems;
//}
//
//[Game, Unique]
//public class NeedRefreshComponent : IComponent
//{
//}
//
[Game, Unique]
public class LocalActionListComponent : IComponent
{
    public List<Action> Actions;
    public long CheckedTick;
}
//
//[Game]
//public class CheckedComponent : IComponent
//{
//}
//
//[Game]
//public class FromSelfComponent : IComponent
//{
//}
//
//[Game]
//public class IceComponent : IComponent
//{
//    public string owner;
//    public long startTick;
//    public long lastsTick;
//}
//
[Game, Unique]
public class StartTimeComponent : IComponent
{
    public long StartTick;
    public System.DateTime StartTime;
}
//
//
//[Game, Unique]
//public class SnapListComponent : IComponent
//{
//    public List<GameSnap> snapList;
//}
//

[Game, Unique]
public class NetCommandsComponent : IComponent
{
    public List<ICommand> Commands;
}
//
//[Game]
//public class RefreshSpanActionComponent : IComponent
//{
//    public Action targetAction;
//}
//
//[Game, Unique]
//public class PingComponent : IComponent
//{
//    public long value;
//}