//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LastMoveTickComponent lastMoveTick { get { return (LastMoveTickComponent)GetComponent(GameComponentsLookup.LastMoveTick); } }
    public bool hasLastMoveTick { get { return HasComponent(GameComponentsLookup.LastMoveTick); } }

    public void AddLastMoveTick(long newValue) {
        var index = GameComponentsLookup.LastMoveTick;
        var component = (LastMoveTickComponent)CreateComponent(index, typeof(LastMoveTickComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLastMoveTick(long newValue) {
        var index = GameComponentsLookup.LastMoveTick;
        var component = (LastMoveTickComponent)CreateComponent(index, typeof(LastMoveTickComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLastMoveTick() {
        RemoveComponent(GameComponentsLookup.LastMoveTick);
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

    static Entitas.IMatcher<GameEntity> _matcherLastMoveTick;

    public static Entitas.IMatcher<GameEntity> LastMoveTick {
        get {
            if (_matcherLastMoveTick == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LastMoveTick);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLastMoveTick = matcher;
            }

            return _matcherLastMoveTick;
        }
    }
}
