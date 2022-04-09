using System;

namespace ActSample.Client {

    public static class AllNetwork {

        public static NetworkClient NetworkClient { get; private set; }

        public static void Inject(NetworkClient networkClient) {
            NetworkClient = networkClient;
        }

    }

}