using Codegen.CodegenAttributes;
using UnityEngine;

namespace Sources.CommandSchemes.ToServer
{
    [CommandToServer]
    public class BeeMoveScheme
    {
        public Vector2 Target;
        public long Tick;
    }
}