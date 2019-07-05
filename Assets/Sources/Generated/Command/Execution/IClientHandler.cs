public interface IClientHandler
{
	void HandleChatMessageCommand(ref ServerChatMessageCommand command);
	void HandleGrantedIdCommand(ref ServerGrantedIdCommand command);
	void HandleSetTickrateCommand(ref ServerSetTickrateCommand command);
	void HandleSetTickValCommand(ref ServerSetTickValCommand command);
	void HandleTestCommand(ref ServerTestCommand command);
}

public interface IClientCommand{}