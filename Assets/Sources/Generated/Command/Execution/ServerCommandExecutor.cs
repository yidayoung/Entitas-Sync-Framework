using NetStack.Serialization;
using Sources.Tools;

public static class ServerCommandExecutor
{
    public static void Execute(IServerHandler handler, BitBuffer buffer, ushort commandCount)
	{
		for (int i = 0; i < commandCount; i++)
        {
            var commandId = buffer.ReadUShort();
            switch (commandId)
            {
							
                case 0:
                {
					Logger.I.Log("ServerCommandExecutor", "Executing ClientBeeMoveCommand");
                    var c = new  ClientBeeMoveCommand();
                    c.Deserialize(buffer);
                    handler.HandleBeeMoveCommand(ref c);
                    break;
                }
								
                case 1:
                {
					Logger.I.Log("ServerCommandExecutor", "Executing ClientChatMessageCommand");
                    var c = new  ClientChatMessageCommand();
                    c.Deserialize(buffer);
                    handler.HandleChatMessageCommand(ref c);
                    break;
                }
								
                case 2:
                {
					Logger.I.Log("ServerCommandExecutor", "Executing ClientCreateBeeCommand");
                    var c = new  ClientCreateBeeCommand();
                    c.Deserialize(buffer);
                    handler.HandleCreateBeeCommand(ref c);
                    break;
                }
								
                case 3:
                {
					Logger.I.Log("ServerCommandExecutor", "Executing ClientRequestCharacterCommand");
                    var c = new  ClientRequestCharacterCommand();
                    c.Deserialize(buffer);
                    handler.HandleRequestCharacterCommand(ref c);
                    break;
                }
								
                case 4:
                {
					Logger.I.Log("ServerCommandExecutor", "Executing ClientSetTickrateCommand");
                    var c = new  ClientSetTickrateCommand();
                    c.Deserialize(buffer);
                    handler.HandleSetTickrateCommand(ref c);
                    break;
                }
								
                case 5:
                {
					Logger.I.Log("ServerCommandExecutor", "Executing ClientTestCommand");
                    var c = new  ClientTestCommand();
                    c.Deserialize(buffer);
                    handler.HandleTestCommand(ref c);
                    break;
                }
				            }
        }
	}
}