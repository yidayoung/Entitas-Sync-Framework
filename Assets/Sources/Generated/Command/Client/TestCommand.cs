using NetStack.Serialization;
using NetStack.Compression;
	
public struct ClientTestCommand : ICommand, IClientCommand
{
	public UnityEngine.Vector3 Value;
	public System.Boolean BoolValue;
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(5);

        bitBuffer.AddUInt(CommandCompressors.ClientTestValueXCompressor.Compress(Value.x));
        bitBuffer.AddUInt(CommandCompressors.ClientTestValueYCompressor.Compress(Value.y));
        bitBuffer.AddUInt(CommandCompressors.ClientTestValueZCompressor.Compress(Value.z));
		bitBuffer.AddBool(BoolValue); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
        Value.x = CommandCompressors.ClientTestValueXCompressor.Decompress(bitBuffer.ReadUInt());
        Value.y = CommandCompressors.ClientTestValueYCompressor.Decompress(bitBuffer.ReadUInt());
        Value.z = CommandCompressors.ClientTestValueZCompressor.Decompress(bitBuffer.ReadUInt());

		BoolValue = bitBuffer.ReadBool(); 
	}
}