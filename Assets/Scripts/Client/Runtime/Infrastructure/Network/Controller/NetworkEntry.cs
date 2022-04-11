using System;
using ActSample.Client.Facades;
using ActSample.Protocol;

namespace ActSample.Client {

    public class NetworkEntry {

        public NetworkEntry() { }

        public void Inject() {

            NetworkClient client = new NetworkClient(1024);
            client.OnConnectedHandle += OnConnected;

            AllNetwork.Inject(client);

        }

        public void Tick() {

            var client = AllNetwork.NetworkClient;
            client.Tick();

        }

        void OnConnected() {
            var player = GlobalAppRepo.PlayerEntity;
            var client = AllNetwork.NetworkClient;
            client.Send(new ConnectReqMessage { token = player.token });
        }

    }

}