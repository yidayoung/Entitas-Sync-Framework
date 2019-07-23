








using NetStack.Serialization;


public struct ClientCreateIceCommand : ICommand, IClientCommand
{

	public System.Int64 Tick;

	public System.Int64 LastsTick;

    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(0);


		bitBuffer.AddLong(Tick); 

		bitBuffer.AddLong(LastsTick); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{

		Tick = bitBuffer.ReadLong(); 

		LastsTick = bitBuffer.ReadLong(); 
	}
}