using System;
using System.Collections.Generic;
using ENet;
using Entitas;
using NetStack.Serialization;
using Sources.GamePlay.Common;
using UnityEngine;
using Util;
using Logger = Sources.Tools.Logger;

namespace Sources.Networking.Server
{
    public class ServerCommandHandler : IServerHandler
    {
        private readonly List<GameEntity> _connectionsBuffer = new List<GameEntity>(ServerNetworkSystem.MaxPlayers);

        private readonly IGroup<GameEntity> _connectionsGroup;

        private readonly GameContext         _game;
        private readonly ServerNetworkSystem _server;
        public           ushort              CurrentClientId;

        public ServerCommandHandler(GameContext game, ServerNetworkSystem server)
        {
            _game             = game;
            _server           = server;
            _connectionsGroup = _game.GetGroup(GameMatcher.Connection);
        }

        public void HandleBeeMoveCommand(ref ClientBeeMoveCommand command)
        {
            Logger.I.Log(this, $"Move-{CurrentClientId}: tar: {command.Target}, tick: {command.Tick}");
            //@TODO 消息进待处理队列
            GameUtil.AddLocalActionList(_game, new MoveAction(command, CurrentClientId.ToString()));
        }

        public void HandleChatMessageCommand(ref ClientChatMessageCommand command)
        {
            Logger.I.Log(this, $"Client-{CurrentClientId}: {command.Message}");
            _server.EnqueueCommandForEveryone(new ServerChatMessageCommand
                {Message = command.Message, Sender = CurrentClientId});
        }

        public void HandleCreateBeeCommand(ref ClientCreateBeeCommand command)
        {
            Logger.I.Log(this, $"Create-{CurrentClientId}: {command.Position}, {command.Direction}");
            //@TODO 收到的创建动作应该先缓存到动作序列里，等服务器帧到的时候自然会取，之后服务器演算后推送给其他客户端状态
            GameUtil.AddLocalActionList(_game, new CreateAction(command, CurrentClientId.ToString()));
        }

        public void HandleRequestCharacterCommand(ref ClientRequestCharacterCommand command)
        {
            var e = _game.GetEntityWithControlledBy(CurrentClientId);
            if (e == null)
            {
                e        = _game.CreateEntity();
                e.isSync = true;
                e.AddControlledBy(CurrentClientId);
            }
            else
            {
                _server.EnqueueCommandForClient(CurrentClientId,
                    new ServerChatMessageCommand {Message = "You already have one.", Sender = 0});
            }
        }

        public void HandleSetTickrateCommand(ref ClientSetTickrateCommand command)
        {
            _server.TickRate = command.Tickrate;
            _server.EnqueueCommandForEveryone(new ServerSetTickrateCommand {Tickrate = command.Tickrate});
        }

        public void HandleTestCommand(ref ClientTestCommand command)
        {
            Logger.I.Log(this, $"{command.Value:##}");
            _server.EnqueueCommandForEveryone(new ServerTestCommand {Value = command.Value, BoolValue = command.BoolValue});
        }

        public void OnClientConnected(Peer peer)
        {
            Logger.I.Log(this, $"Client connected - {peer.ID}");

            if (_connectionsGroup.count == ServerNetworkSystem.MaxPlayers)
            {
                _server.EnqueueDisconnectData(new DisconnectData {Peer = peer});
                return;
            }

            var id = (ushort) peer.ID;
            var e  = _game.CreateEntity();
            e.isSync = true;
            e.AddConnectionPeer(peer);
            e.AddConnection(id);
            e.AddClientDataBuffer(0, new BitBuffer(64));
            e.isRequiresWorldState = true;

            _server.EnqueueCommandForClient(id, new ServerGrantedIdCommand {Id         = id});
            _server.EnqueueCommandForClient(id, new ServerSetTickrateCommand {Tickrate = _server.TickRate});
            
            var dt = new DateTime(1970, 1, 1);
            var nowMillSec = DateTime.Now.Subtract(dt).TotalMilliseconds;
            _server.EnqueueCommandForClient(id, new ServerSetTickValCommand{Tick = _game.tick.CurrentTick, ServerMillSec = (long)nowMillSec});
        }

        public void OnClientDisconnected(Peer peer)
        {
            Logger.I.Log(this, $"Client disconnected - {peer.ID}");

            var e = _game.GetEntityWithConnection((ushort) peer.ID);

            if (e != null) e.isDestroyed = true;
        }
    }
}