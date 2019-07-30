public class CommonGeneratedFeature : Feature
{
    public CommonGeneratedFeature(Contexts contexts, Services services)
    {
        Add(new GameEventSystems(contexts));
        Add(new GameCleanupSystems(contexts));
        Add(new DestroyDestroyedGameSystem(services.BackContext));
    }
}