using Codegen.CodegenAttributes;
using Entitas;
using UnityEngine;


[Game]
[Sync]
public partial class PositionComponent : IComponent
{
    public Vector2 Value;
}

[Game]
[Sync]
public partial class DirectionComponent : IComponent
{
    public float Value;
}

[Game]
[Sync]
public partial class SpriteComponent : IComponent
{
    public string Name;
}

[Game]
[Sync]
public partial class MoverComponent : IComponent
{
}

[Game]
[Sync]
public partial class MoveComponent : IComponent
{
    public Vector2 target;
    public long move_time;
    public float start_direction;

    public MoveComponent()
    {
    }

    public MoveComponent(MoveComponent other)
    {
        target = other.target;
        move_time = other.move_time;
        start_direction = other.start_direction;
    }
}

[Game]
public class MoveCompleteComponent : IComponent
{
}

[Game]
public class LastMoveTickComponent : IComponent
{
    public long value;
}

[Game]
[Sync]
public partial class MoverIDComponent : IComponent
{
    public string value;
}

[Game]
public class ViewPositionComponent : IComponent
{
    public Vector2 value;
}

[Game]
public class ViewComponent : IComponent
{
    public UnityEngine.GameObject gameObject;
}