using System;
using JackFrame;
using SJSJ.Client.Facades;
using SJSJ.Protocol;

namespace SJSJ.Client {

    public class NetworkEntry {

        public NetworkEntry() { }

        public void Inject() {

            NetworkClient client = new NetworkClient(1024);
            client.OnDisconnectedHandle += OnDisconnected;
            client.OnConnectedHandle += OnConnected;

            AllNetwork.Inject(client);

        }

        public void Tick() {

            var client = AllNetwork.NetworkClient;
            client.Tick();

        }

        public void TearDown() {

            var client = AllNetwork.NetworkClient;
            client.Disconnect();
            
        }

        void OnConnected() {
            var player = GlobalAppRepo.PlayerEntity;
            var client = AllNetwork.NetworkClient;
            client.Send(new ConnectReqMessage { token = player.token });

            PLog.Log("CONNECTED");

        }

        void OnDisconnected() {

            var client = AllNetwork.NetworkClient;
            client.Reconnect();

            PLog.Log("RECONNECTING");

        }

    }

}