//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MoverIDComponent moverID { get { return (MoverIDComponent)GetComponent(GameComponentsLookup.MoverID); } }
    public bool hasMoverID { get { return HasComponent(GameComponentsLookup.MoverID); } }

    public void AddMoverID(string newValue) {
        var index = GameComponentsLookup.MoverID;
        var component = (MoverIDComponent)CreateComponent(index, typeof(MoverIDComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMoverID(string newValue) {
        var index = GameComponentsLookup.MoverID;
        var component = (MoverIDComponent)CreateComponent(index, typeof(MoverIDComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMoverID() {
        RemoveComponent(GameComponentsLookup.MoverID);
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

    static Entitas.IMatcher<GameEntity> _matcherMoverID;

    public static Entitas.IMatcher<GameEntity> MoverID {
        get {
            if (_matcherMoverID == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MoverID);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMoverID = matcher;
            }

            return _matcherMoverID;
        }
    }
}
