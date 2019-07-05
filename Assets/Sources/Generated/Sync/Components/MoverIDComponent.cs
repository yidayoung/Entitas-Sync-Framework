using NetStack.Serialization;

public partial class MoverIDComponent : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(6);

		bitBuffer.AddString(value); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
		value = bitBuffer.ReadString();
	}
}