using Codegen.CodegenAttributes;
using Codegen.CodegenAttributes.Bounds;
using UnityEngine;

namespace Sources.CommandSchemes.ToServer
{
    [CommandToServer]
    public class CreateBeeScheme
    {
        [BoundedVector3(-100f,100f,0.0001f,-100f,100f,0.0001f,-100f,100f,0.0001f)]
        public Vector3 Position;
        [BoundedFloat(0, 360, 1f)]
        public float Direction;
        public string Sprite;
        public long Tick;
    }
}