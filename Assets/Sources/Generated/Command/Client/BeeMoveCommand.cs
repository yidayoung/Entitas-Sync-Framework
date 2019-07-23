








using NetStack.Serialization;

using NetStack.Compression;
	

public struct ClientBeeMoveCommand : ICommand, IClientCommand
{

	public UnityEngine.Vector2 Target;

	public System.Int64 Tick;

    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(1);


		bitBuffer.AddFloat(Target.x);
		bitBuffer.AddFloat(Target.y);


		bitBuffer.AddLong(Tick); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{


		Target.x = bitBuffer.ReadFloat();
        Target.y = bitBuffer.ReadFloat();

		Tick = bitBuffer.ReadLong(); 
	}
}