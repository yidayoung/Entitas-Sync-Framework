using NetStack.Serialization;
using NetStack.Compression;
	
public partial class DirectionComponent : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(2);

		bitBuffer.AddFloat(Value);
	}

	public void Deserialize(BitBuffer bitBuffer)
	{

        Value = bitBuffer.ReadFloat();
	}
}