using NetStack.Serialization;
using NetStack.Compression;
	
public partial class PositionComponent : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(1);

		bitBuffer.AddFloat(Value.x);
		bitBuffer.AddFloat(Value.y);

	}

	public void Deserialize(BitBuffer bitBuffer)
	{

		Value.x = bitBuffer.ReadFloat();
        Value.y = bitBuffer.ReadFloat();
	}
}