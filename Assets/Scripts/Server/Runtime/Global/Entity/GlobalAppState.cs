using System;

namespace SJSJ.Server {

    public static class GlobalAppState {

        public static bool isInit;
        public static bool isTearDown;

        public static int onlinePlayerCount = -1;
        public static int cachedPlayerCount = -1;
        
    }
}