using NetStack.Serialization;
using NetStack.Compression;
	
public partial class MoveComponent : INetworkComponent
{
    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(5);

		bitBuffer.AddFloat(target.x);
		bitBuffer.AddFloat(target.y);

		bitBuffer.AddLong(move_time); 
		bitBuffer.AddFloat(start_direction);
	}

	public void Deserialize(BitBuffer bitBuffer)
	{

		target.x = bitBuffer.ReadFloat();
        target.y = bitBuffer.ReadFloat();
		move_time = bitBuffer.ReadLong(); 

        start_direction = bitBuffer.ReadFloat();
	}
}