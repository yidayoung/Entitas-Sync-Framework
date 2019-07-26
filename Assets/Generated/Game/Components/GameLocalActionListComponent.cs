//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity localActionListEntity { get { return GetGroup(GameMatcher.LocalActionList).GetSingleEntity(); } }
    public LocalActionListComponent localActionList { get { return localActionListEntity.localActionList; } }
    public bool hasLocalActionList { get { return localActionListEntity != null; } }

    public GameEntity SetLocalActionList(System.Collections.Generic.List<Sources.GamePlay.Common.Action> newActions) {
        if (hasLocalActionList) {
            throw new Entitas.EntitasException("Could not set LocalActionList!\n" + this + " already has an entity with LocalActionListComponent!",
                "You should check if the context already has a localActionListEntity before setting it or use context.ReplaceLocalActionList().");
        }
        var entity = CreateEntity();
        entity.AddLocalActionList(newActions);
        return entity;
    }

    public void ReplaceLocalActionList(System.Collections.Generic.List<Sources.GamePlay.Common.Action> newActions) {
        var entity = localActionListEntity;
        if (entity == null) {
            entity = SetLocalActionList(newActions);
        } else {
            entity.ReplaceLocalActionList(newActions);
        }
    }

    public void RemoveLocalActionList() {
        localActionListEntity.Destroy();
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

    public LocalActionListComponent localActionList { get { return (LocalActionListComponent)GetComponent(GameComponentsLookup.LocalActionList); } }
    public bool hasLocalActionList { get { return HasComponent(GameComponentsLookup.LocalActionList); } }

    public void AddLocalActionList(System.Collections.Generic.List<Sources.GamePlay.Common.Action> newActions) {
        var index = GameComponentsLookup.LocalActionList;
        var component = (LocalActionListComponent)CreateComponent(index, typeof(LocalActionListComponent));
        component.Actions = newActions;
        AddComponent(index, component);
    }

    public void ReplaceLocalActionList(System.Collections.Generic.List<Sources.GamePlay.Common.Action> newActions) {
        var index = GameComponentsLookup.LocalActionList;
        var component = (LocalActionListComponent)CreateComponent(index, typeof(LocalActionListComponent));
        component.Actions = newActions;
        ReplaceComponent(index, component);
    }

    public void RemoveLocalActionList() {
        RemoveComponent(GameComponentsLookup.LocalActionList);
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

    static Entitas.IMatcher<GameEntity> _matcherLocalActionList;

    public static Entitas.IMatcher<GameEntity> LocalActionList {
        get {
            if (_matcherLocalActionList == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LocalActionList);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLocalActionList = matcher;
            }

            return _matcherLocalActionList;
        }
    }
}
