public class ServerGamePlayFeature : Feature
{
    public ServerGamePlayFeature(Contexts contexts, Services services)
    {
        
        
        Add(new EnsureServerSystem(contexts, services));
    }
}