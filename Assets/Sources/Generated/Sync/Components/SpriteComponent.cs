using NetStack.Serialization;

public partial class SpriteComponent : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(3);

		bitBuffer.AddString(Name); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{
		Name = bitBuffer.ReadString();
	}
}