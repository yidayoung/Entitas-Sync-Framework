public class ClientGamePlayFeature : Feature
{
    public ClientGamePlayFeature(Contexts contexts, Services services)
    {
        Add(new GamePlaySystem(contexts));
    }
}