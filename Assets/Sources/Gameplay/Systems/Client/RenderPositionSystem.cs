
using Entitas;
using UnityEngine;


public class RenderPositionSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _movers;
    public RenderPositionSystem(Contexts contexts) 
    {
        _movers = contexts.game.GetGroup(GameMatcher.Mover);
    }
    
    public void Execute()
    {
        var entities = _movers.GetEntities();
        foreach (GameEntity e in entities)
        {
//            Vector2 dirCur = e.position.Value - (Vector2)e.view.gameObject.transform.position;
//            if (dirCur.sqrMagnitude >= 0.01f || !e.isMoveComplete)
//            {
//                e.view.gameObject.transform.position = Vector2.Lerp(e.view.gameObject.transform.position, e.position.Value, 0.1f);
//            }
//            else
//            {
//                e.view.gameObject.transform.position = e.position.Value;
//            }
            e.view.gameObject.transform.position = e.position.Value;
        }
    }
}