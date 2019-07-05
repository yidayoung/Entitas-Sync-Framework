using NetStack.Serialization;
using NetStack.Compression;
	
public struct ClientBeeMoveCommand : ICommand, IClientCommand
{
	public UnityEngine.Vector2 Target;
	public System.Int64 Tick;
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(0);

        bitBuffer.AddUShort(HalfPrecision.Compress(Target.x));
        bitBuffer.AddUShort(HalfPrecision.Compress(Target.y));
		bitBuffer.AddLong(Tick); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
        Target.x = HalfPrecision.Decompress(bitBuffer.ReadUShort());
        Target.y = HalfPrecision.Decompress(bitBuffer.ReadUShort());
		Tick = bitBuffer.ReadLong(); 
	}
}