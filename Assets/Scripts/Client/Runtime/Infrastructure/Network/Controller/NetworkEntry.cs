using System;
using ActSample.Client.Facades;

namespace ActSample.Client {

    public class NetworkEntry {

        public NetworkEntry() {}

        public void Inject() {
            
            NetworkClient client = new NetworkClient(1024);

            AllNetwork.Inject(client);

        }

        public void Tick() {

            var client = AllNetwork.NetworkClient;
            client.Tick();

        }

    }

}