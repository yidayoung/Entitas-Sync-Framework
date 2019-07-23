








using NetStack.Serialization;

using NetStack.Compression;
	

public struct ClientTestCommand : ICommand, IClientCommand
{

	public UnityEngine.Vector3 Value;

	public System.Boolean BoolValue;

    public void Serialize(BitBuffer bitBuffer)
	{
		bitBuffer.AddUShort(6);


		bitBuffer.AddFloat(Value.x);
		bitBuffer.AddFloat(Value.y);
		bitBuffer.AddFloat(Value.z);

		bitBuffer.AddBool(BoolValue); 
	}

	public void Deserialize(BitBuffer bitBuffer)
	{

		Value.x = bitBuffer.ReadFloat();
        Value.y = bitBuffer.ReadFloat();
        Value.z = bitBuffer.ReadFloat();
        

		BoolValue = bitBuffer.ReadBool(); 
	}
}