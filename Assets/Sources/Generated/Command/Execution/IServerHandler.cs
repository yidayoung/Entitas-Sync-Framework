public interface IServerHandler
{
	void HandleBeeMoveCommand(ref ClientBeeMoveCommand command);
	void HandleChatMessageCommand(ref ClientChatMessageCommand command);
	void HandleCreateBeeCommand(ref ClientCreateBeeCommand command);
	void HandleRequestCharacterCommand(ref ClientRequestCharacterCommand command);
	void HandleSetTickrateCommand(ref ClientSetTickrateCommand command);
	void HandleTestCommand(ref ClientTestCommand command);
}

public interface IServerCommand{}