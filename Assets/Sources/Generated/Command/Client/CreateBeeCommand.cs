








using NetStack.Serialization;

using NetStack.Compression;
	

public struct ClientCreateBeeCommand : ICommand, IClientCommand
{

	public UnityEngine.Vector3 Position;

	public System.Single Direction;

	public System.String Sprite;

	public System.Int64 Tick;

    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(3);


		bitBuffer.AddFloat(Position.x);
		bitBuffer.AddFloat(Position.y);
		bitBuffer.AddFloat(Position.z);

		bitBuffer.AddFloat(Direction);

		bitBuffer.AddString(Sprite); 

		bitBuffer.AddLong(Tick); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{

		Position.x = bitBuffer.ReadFloat();
        Position.y = bitBuffer.ReadFloat();
        Position.z = bitBuffer.ReadFloat();
        


        Direction = bitBuffer.ReadFloat();

		Sprite = bitBuffer.ReadString();

		Tick = bitBuffer.ReadLong(); 
	}
}