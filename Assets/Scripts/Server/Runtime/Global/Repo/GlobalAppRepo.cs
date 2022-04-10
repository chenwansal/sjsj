using System;
using System.Collections.Generic;
using JackFrame;

namespace ActSample.Server {

    public static class GlobalAppRepo {

        static Pool<PlayerEntity> playerPool;
        static MultiKeySortedDictionary<int, string, PlayerEntity> allPlayer;

        public static void Ctor() {
            playerPool = new Pool<PlayerEntity>(() => PlayerEntity.Create(), 16);
            allPlayer = new MultiKeySortedDictionary<int, string, PlayerEntity>();
        }

        public static PlayerEntity NewPlayer() {
            return playerPool.Take();
        }

        public static void AddPlayer(PlayerEntity entity) {
            if (!allPlayer.ContainsKeyPrimary(entity.connID)) {
                allPlayer.Add(entity.connID, entity.token, entity);
            }
        }

        public static void Remove(PlayerEntity entity) {
            allPlayer.Remove(entity.connID, entity.token);
            playerPool.Return(entity);
        }

        public static void RemoveByID(int connID) {
            bool hasPlayer = allPlayer.ContainsKeyPrimary(connID);
            if (hasPlayer) {
                allPlayer.TryGetValueFromPrimary(connID, out var entity);
                allPlayer.Remove(connID, entity.token);
                playerPool.Return(entity);
            }
        }
        
    }

}