using NetStack.Serialization;
using NetStack.Compression;
	
public struct ClientCreateBeeCommand : ICommand, IClientCommand
{
	public UnityEngine.Vector3 Position;
	public System.Single Direction;
	public System.String Sprite;
	public System.Int64 Tick;
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(2);

        bitBuffer.AddUShort(HalfPrecision.Compress(Position.x));
        bitBuffer.AddUShort(HalfPrecision.Compress(Position.y));
        bitBuffer.AddUShort(HalfPrecision.Compress(Position.z));
        bitBuffer.AddUShort(HalfPrecision.Compress(Direction));
		bitBuffer.AddString(Sprite); 
		bitBuffer.AddLong(Tick); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
        Position.x = HalfPrecision.Decompress(bitBuffer.ReadUShort());
        Position.y = HalfPrecision.Decompress(bitBuffer.ReadUShort());
        Position.z = HalfPrecision.Decompress(bitBuffer.ReadUShort());
        Direction = HalfPrecision.Decompress(bitBuffer.ReadUShort());
		Sprite = bitBuffer.ReadString();
		Tick = bitBuffer.ReadLong(); 
	}
}