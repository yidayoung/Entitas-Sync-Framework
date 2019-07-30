public class CommonGamePlayFeature : Feature
{
    public CommonGamePlayFeature(Contexts contexts, Services services)
    {
        Add(new TickUpdateSystem(contexts));
        Add(new GamePlaySystem(contexts));
    }
}