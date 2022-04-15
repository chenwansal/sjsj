using System;
using UnityEngine;
using JackBuffer;
using SJSJ.Server.Facades;

namespace SJSJ.Server {

    public class NetworkEntry {

        public NetworkEntry() { }

        public void Inject() {
            NetworkServer server = new NetworkServer(4096);

            AllNetwork.Inject(server);
        }

        public void Tick() {
            var server = AllNetwork.NetworkServer;
            server.Tick();
        }

    }
}