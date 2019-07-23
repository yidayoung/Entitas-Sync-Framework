using NetStack.Serialization;

public partial class TickComponent : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(8);

		bitBuffer.AddLong(CurrentTick); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
		CurrentTick = bitBuffer.ReadLong(); 
	}
}