using System;
using JackBuffer;
using SJSJ.Protocol;
using JackFrame.Network;

namespace SJSJ.Server {

    public class NetworkServer : TcpServer {

        IProtocolService protocolService;

        public NetworkServer(int maxMessageSize) : base(maxMessageSize) {
            protocolService = new ProtocolService();
        }

        public void Send<T>(int connID, T msg) where T : IJackMessage<T> {
            (byte serviceID, byte messageID) = protocolService.GetMessageID<T>();
            Send<T>(serviceID, messageID, connID, msg);
        }

        public void On<T>(Action<int, T> action) where T : IJackMessage<T> {
            (byte serviceID, byte messageID) = protocolService.GetMessageID<T>();
            On<T>(serviceID, messageID, protocolService.GetGenerateHandle<T>(), action);
        }

    }

}