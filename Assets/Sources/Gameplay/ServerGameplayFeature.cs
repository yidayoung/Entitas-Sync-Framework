public class ServerGameplayFeature : Feature
{
    public ServerGameplayFeature(Contexts contexts, Services services)
    {
        
        Add(new GamePlaySystem(contexts));
    }
}