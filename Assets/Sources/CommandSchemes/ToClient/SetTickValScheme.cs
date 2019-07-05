using Codegen.CodegenAttributes;

namespace Sources.CommandSchemes.ToClient
{
    [CommandToClient]
    public class SetTickValScheme
    {
        public long Tick;
        public long ServerMillSec;
    }
}