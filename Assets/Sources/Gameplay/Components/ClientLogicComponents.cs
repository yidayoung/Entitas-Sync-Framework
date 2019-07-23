using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using NetStack.Serialization;


[Game,Unique]
public class ClientWorldStateListComponent : IComponent
{
    public Dictionary<long, ClientWorldState> WorldStates;
}

public class ClientWorldState
{
    public ushort EntityCount;
    public BitBuffer Buffer;

}

