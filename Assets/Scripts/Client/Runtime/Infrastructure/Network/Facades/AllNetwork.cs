using System;

namespace ActSample.Client.Facades {

    public static class AllNetwork {

        public static NetworkClient NetworkClient { get; private set; }

        public static void Inject(NetworkClient networkClient) {
            NetworkClient = networkClient;
        }

    }

}