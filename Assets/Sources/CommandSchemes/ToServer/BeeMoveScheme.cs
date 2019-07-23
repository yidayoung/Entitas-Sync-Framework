using Codegen.CodegenAttributes;
using Codegen.CodegenAttributes.Bounds;
using UnityEngine;

namespace Sources.CommandSchemes.ToServer
{
    [CommandToServer]
    public class BeeMoveScheme
    {
        [BoundedVector3(-100f,100f,0.0001f,-100f,100f,0.0001f,-100f,100f,0.0001f)]
        public Vector2 Target;
        public long Tick;
    }
}