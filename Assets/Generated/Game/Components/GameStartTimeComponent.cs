//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity startTimeEntity { get { return GetGroup(GameMatcher.StartTime).GetSingleEntity(); } }
    public StartTimeComponent startTime { get { return startTimeEntity.startTime; } }
    public bool hasStartTime { get { return startTimeEntity != null; } }

    public GameEntity SetStartTime(long newStartTick, System.DateTime newStartTime) {
        if (hasStartTime) {
            throw new Entitas.EntitasException("Could not set StartTime!\n" + this + " already has an entity with StartTimeComponent!",
                "You should check if the context already has a startTimeEntity before setting it or use context.ReplaceStartTime().");
        }
        var entity = CreateEntity();
        entity.AddStartTime(newStartTick, newStartTime);
        return entity;
    }

    public void ReplaceStartTime(long newStartTick, System.DateTime newStartTime) {
        var entity = startTimeEntity;
        if (entity == null) {
            entity = SetStartTime(newStartTick, newStartTime);
        } else {
            entity.ReplaceStartTime(newStartTick, newStartTime);
        }
    }

    public void RemoveStartTime() {
        startTimeEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public StartTimeComponent startTime { get { return (StartTimeComponent)GetComponent(GameComponentsLookup.StartTime); } }
    public bool hasStartTime { get { return HasComponent(GameComponentsLookup.StartTime); } }

    public void AddStartTime(long newStartTick, System.DateTime newStartTime) {
        var index = GameComponentsLookup.StartTime;
        var component = (StartTimeComponent)CreateComponent(index, typeof(StartTimeComponent));
        component.StartTick = newStartTick;
        component.StartTime = newStartTime;
        AddComponent(index, component);
    }

    public void ReplaceStartTime(long newStartTick, System.DateTime newStartTime) {
        var index = GameComponentsLookup.StartTime;
        var component = (StartTimeComponent)CreateComponent(index, typeof(StartTimeComponent));
        component.StartTick = newStartTick;
        component.StartTime = newStartTime;
        ReplaceComponent(index, component);
    }

    public void RemoveStartTime() {
        RemoveComponent(GameComponentsLookup.StartTime);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherStartTime;

    public static Entitas.IMatcher<GameEntity> StartTime {
        get {
            if (_matcherStartTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StartTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStartTime = matcher;
            }

            return _matcherStartTime;
        }
    }
}