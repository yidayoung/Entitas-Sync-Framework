using Sources.Networking.Client;

public class ClientFeature : Feature
{
    public ClientFeature(Contexts contexts, Services services)
    {
        Add(new CommonGameplayFeature(contexts, services));
        Add(new ClientGamePlayFeature(contexts, services));

        Add(new ClientNetworkFeature(contexts, services));
        Add(new CommonGeneratedFeature(contexts));

        Add(new DestroyDestroyedGameSystem(services.BackContext));
    }
}