using NetStack.Serialization;

public partial class IceComponent : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(9);

		bitBuffer.AddString(Owner); 
		bitBuffer.AddLong(StartTick); 
		bitBuffer.AddLong(LastsTick); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
		Owner = bitBuffer.ReadString();
		StartTick = bitBuffer.ReadLong(); 
		LastsTick = bitBuffer.ReadLong(); 
	}
}