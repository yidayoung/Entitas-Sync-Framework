using Codegen.CodegenAttributes;
using Codegen.CodegenAttributes.Bounds;
using UnityEngine;

namespace Sources.CommandSchemes.Common
{
    [CommandToClient]
    [CommandToServer]
    public class TestScheme
    {
        [BoundedVector3(-1,1,0.01f,-1,1,0.01f,-1,-1,0.01f)]
        public Vector3 Value;
        public bool BoolValue;
    }
}