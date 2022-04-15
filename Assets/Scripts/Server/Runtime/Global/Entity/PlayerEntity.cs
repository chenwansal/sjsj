using System;

namespace SJSJ.Server {

    public class PlayerEntity {

        public string token;
        public int connID;

        private PlayerEntity() {}

        public static PlayerEntity Create() {
            return new PlayerEntity();
        }

    }

}