using NetStack.Serialization;
using NetStack.Compression;
	
public struct ServerTestCommand : ICommand, IServerCommand
{
	public UnityEngine.Vector3 Value;
	public System.Boolean BoolValue;
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(4);

        bitBuffer.AddUInt(CommandCompressors.ServerTestValueXCompressor.Compress(Value.x));
        bitBuffer.AddUInt(CommandCompressors.ServerTestValueYCompressor.Compress(Value.y));
        bitBuffer.AddUInt(CommandCompressors.ServerTestValueZCompressor.Compress(Value.z));
		bitBuffer.AddBool(BoolValue); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
        Value.x = CommandCompressors.ServerTestValueXCompressor.Decompress(bitBuffer.ReadUInt());
        Value.y = CommandCompressors.ServerTestValueYCompressor.Decompress(bitBuffer.ReadUInt());
        Value.z = CommandCompressors.ServerTestValueZCompressor.Decompress(bitBuffer.ReadUInt());

		BoolValue = bitBuffer.ReadBool(); 
	}
}