using NetStack.Serialization;
using NetStack.Compression;
	
public partial class PositionComponent : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(1);

        bitBuffer.AddUShort(HalfPrecision.Compress(Value.x));
        bitBuffer.AddUShort(HalfPrecision.Compress(Value.y));
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
        Value.x = HalfPrecision.Decompress(bitBuffer.ReadUShort());
        Value.y = HalfPrecision.Decompress(bitBuffer.ReadUShort());
	}
}