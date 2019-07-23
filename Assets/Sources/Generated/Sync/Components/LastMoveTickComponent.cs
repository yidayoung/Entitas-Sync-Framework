using NetStack.Serialization;

public partial class LastMoveTickComponent : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(6);

		bitBuffer.AddLong(value); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
		value = bitBuffer.ReadLong(); 
	}
}