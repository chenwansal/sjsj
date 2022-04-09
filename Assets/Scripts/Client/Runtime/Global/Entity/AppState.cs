using System;

namespace ActSample.Client {

    public static class AppState {
        public static bool isInit;
        public static bool isTearDown;
        public static bool isFresh;

        public static void Reset() {
            isInit = false;
            isTearDown = false;
            isFresh = true;
        }

    }

}