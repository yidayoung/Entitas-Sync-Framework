using NetStack.Serialization;

public partial class Sync : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(10);

	}

	public void Deserialize(BitBuffer bitBuffer)
	{
	}
}