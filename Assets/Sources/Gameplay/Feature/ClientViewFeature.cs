

public class ClientViewFeature : Feature
{
    public ClientViewFeature(Contexts contexts, Services services)
    {
        Add(new EmitInputSystem(contexts));
        Add(new CreateMoverSystem(contexts, services));
        Add(new CommandMoveSystem(contexts, services));
        Add(new AddViewSystem(contexts));
        Add(new RenderSpriteSystem(contexts));
        Add(new RenderPositionSystem(contexts));
        Add(new RenderDirectionSystem(contexts));
    }
}