public class CommonGameplayFeature : Feature
{
    public CommonGameplayFeature(Contexts contexts, Services services)
    {
        Add(new TickUpdateSystem(contexts));
    }
}