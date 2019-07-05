using NetStack.Serialization;

public partial class MoverComponent : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(4);

	}

	public void Deserialize(BitBuffer bitBuffer)
	{
	}
}