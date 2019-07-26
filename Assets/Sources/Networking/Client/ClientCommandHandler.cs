using System;
using ENet;
using Sources.Tools;

namespace Sources.Networking.Client
{
    public class ClientCommandHandler : IClientHandler
    {
        private readonly ClientNetworkSystem _client;
        private readonly GameContext         _game;

        public ClientCommandHandler(GameContext game, ClientNetworkSystem client)
        {
            _game   = game;
            _client = client;
        }

        public void HandleChatMessageCommand(ref ServerChatMessageCommand command)
        {
            Logger.I.Log(this, $"Client-{command.Sender}: {command.Message}");
        }

        public void HandleGrantedIdCommand(ref ServerGrantedIdCommand command)
        {
            Logger.I.Log(this, $"Got ID - {command.Id}");
            _client.State              = ClientState.Connected;
            _client.ConnectionId.IsSet = true;
            _client.ConnectionId.Id    = command.Id;

        }

        public void HandleSetTickrateCommand(ref ServerSetTickrateCommand command)
        {
            _client.TickRate = command.Tickrate;
        }

        public void HandleSetTickValCommand(ref ServerSetTickValCommand command)
        {
            var utcNow = DateTime.Parse(DateTime.Now.ToString("1970-01-01 00:00:00")).AddMilliseconds(command.ServerMillSec);
            var timeSpan = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0);
            var ping = timeSpan.TotalMilliseconds - command.ServerMillSec;
            
            var localTick = (long)ping / 20 + command.Tick;
            var addTick = _client.AddTick;
            _game.ReplaceTick(localTick + addTick);
            _game.SetStartTime(localTick + addTick, utcNow);
            _game.ReplaceLastTick(localTick + addTick);
        }

        public void HandleTestCommand(ref ServerTestCommand command)
        {
            Logger.I.Log(this, $"{command.Value:##}, {command.BoolValue:##}");
        }

        public void OnConnected(Peer peer)
        {
            Logger.I.Log(this, $"Connected to server {peer.IP} {peer.Port}, waiting for ID");
            _client.State            = ClientState.WaitingForId;
            _client.ServerConnection = peer;
        }

        public void OnDisconnected(Peer peer)
        {
            Logger.I.Log(this, "Disconnected from server");
            _client.EnqueueRequest(NetworkThreadRequest.Cleanup);
            _client.CleanupState();
        }
    }
}