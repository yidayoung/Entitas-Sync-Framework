using Entitas;
using UnityEngine;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
    readonly InputContext _context;
    private InputEntity _leftMouseEntity;
    private InputEntity _rightMouseEntity;

    public EmitInputSystem(Contexts contexts)
    {
        _context = contexts.input;
    }

    public void Initialize()
    {
        // initialize the unique entities that will hold the mouse button data
        _context.isLeftMouse = true;
        _leftMouseEntity = _context.leftMouseEntity;

        _context.isRightMouse = true;
        _rightMouseEntity = _context.rightMouseEntity;
    }
    
    public void Execute()
    {
        if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1)) return;
        // mouse position
        if (Camera.main == null) return;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            _leftMouseEntity.ReplaceMouseDown(mousePosition);
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            _rightMouseEntity.ReplaceMouseDown(mousePosition);
        }
    }

}