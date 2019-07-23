








using NetStack.Serialization;


public struct ServerSetTickValCommand : ICommand, IServerCommand
{

	public System.Int64 Tick;

	public System.Int64 ServerMillSec;

    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(3);


		bitBuffer.AddLong(Tick); 

		bitBuffer.AddLong(ServerMillSec); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{

		Tick = bitBuffer.ReadLong(); 

		ServerMillSec = bitBuffer.ReadLong(); 
	}
}