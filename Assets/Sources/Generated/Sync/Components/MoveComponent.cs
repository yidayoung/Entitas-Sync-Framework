using NetStack.Serialization;
using NetStack.Compression;
	
public partial class MoveComponent : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(5);

        bitBuffer.AddUShort(HalfPrecision.Compress(target.x));
        bitBuffer.AddUShort(HalfPrecision.Compress(target.y));
		bitBuffer.AddLong(move_time); 
        bitBuffer.AddUShort(HalfPrecision.Compress(start_direction));
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
        target.x = HalfPrecision.Decompress(bitBuffer.ReadUShort());
        target.y = HalfPrecision.Decompress(bitBuffer.ReadUShort());
		move_time = bitBuffer.ReadLong(); 
        start_direction = HalfPrecision.Decompress(bitBuffer.ReadUShort());
	}
}