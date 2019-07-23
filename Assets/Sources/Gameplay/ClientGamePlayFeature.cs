using Sources.Gameplay.Systems.Client;

public class ClientGamePlayFeature : Feature
{
    public ClientGamePlayFeature(Contexts contexts, Services services)
    {
        Add(new GamePlaySystem(contexts));
//        Add(new ClientCreateWorldStateSystem(contexts));
        Add(new StateFixSystem(contexts, services));
    }
}