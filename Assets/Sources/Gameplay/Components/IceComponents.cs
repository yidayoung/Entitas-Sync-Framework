using Codegen.CodegenAttributes;
using Entitas;


[Game]
[Sync]
public partial class IceComponent : IComponent
{
    public string Owner;
    public long StartTick;
    public long LastsTick;
}