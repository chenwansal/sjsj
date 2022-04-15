using System;

namespace SJSJ.Server.Facades {

    public static class AllNetwork {

        public static NetworkServer NetworkServer { get; private set; }

        public static void Inject(NetworkServer networkServer) {
            NetworkServer = networkServer;
        }

    }

}