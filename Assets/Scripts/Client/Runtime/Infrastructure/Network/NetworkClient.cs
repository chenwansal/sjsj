using System;
using UnityEngine;
using JackFrame.Network;
using JackBuffer;
using ActSample.Protocol;

namespace ActSample.Client {

    public class NetworkClient : TcpClient {

        IProtocolService protocolService;

        public NetworkClient(int messageSize) : base(messageSize) {
            protocolService = new ProtocolService();
        }

        public void Send<T>(T msg) where T : IJackMessage<T> {
            (byte serviceID, byte messageID) = protocolService.GetMessageID<T>();
            Send(serviceID, messageID, msg);
        }

        public void On<T>(Action<T> action) where T : IJackMessage<T> {
            (byte serviceID, byte messageID) = protocolService.GetMessageID<T>();
            On<T>(serviceID, messageID, protocolService.GetGenerateHandle<T>(), action);
        }

    }

}