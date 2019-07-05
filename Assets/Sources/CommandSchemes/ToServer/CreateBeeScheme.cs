using Codegen.CodegenAttributes;
using UnityEngine;

namespace Sources.CommandSchemes.ToServer
{
    [CommandToServer]
    public class CreateBeeScheme
    {
        public Vector3 Position;
        public float Direction;
        public string Sprite;
        public long Tick;
    }
}