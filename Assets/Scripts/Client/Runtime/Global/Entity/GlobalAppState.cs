using System;

namespace ActSample.Client {

    public class AppState {
        public bool isInit;
        public bool isTearDown;
        public bool isFresh;

        public void Reset() {
            isInit = false;
            isTearDown = false;
            isFresh = true;
        }

    }

}