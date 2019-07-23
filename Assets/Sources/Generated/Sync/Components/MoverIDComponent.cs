using NetStack.Serialization;

public partial class MoverIDComponent : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(7);

		bitBuffer.AddString(value); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
		value = bitBuffer.ReadString();
	}
}