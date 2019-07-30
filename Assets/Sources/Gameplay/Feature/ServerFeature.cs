using Sources.Networking.Server;

public class ServerFeature : Feature
{
    public ServerFeature(Contexts contexts, Services services)
    {
        Add(new CommonGamePlayFeature(contexts, services));
        Add(new ServerGamePlayFeature(contexts, services));

        Add(new ServerNetworkFeature(contexts, services));
        Add(new CommonGeneratedFeature(contexts, services));
    }
}