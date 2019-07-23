using NetStack.Serialization;

public partial class Connection : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(12);

		bitBuffer.AddUShort(Id); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
		Id = bitBuffer.ReadUShort(); 
	}
}