using NetStack.Serialization;

public partial class ControlledBy : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(11);

		bitBuffer.AddUShort(Value); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
		Value = bitBuffer.ReadUShort(); 
	}
}