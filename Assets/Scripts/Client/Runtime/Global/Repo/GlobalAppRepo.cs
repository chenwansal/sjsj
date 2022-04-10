using System;

namespace ActSample.Client {

    public static class GlobalAppRepo {

        public static AppState AppState { get; private set; } = new AppState();
        public static PlayerEntity PlayerEntity { get; private set; } = new PlayerEntity();

    }

}