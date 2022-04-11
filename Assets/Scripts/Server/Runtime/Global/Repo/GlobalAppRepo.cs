using System;
using System.Collections.Generic;
using JackFrame;

namespace ActSample.Server {

    public static class GlobalAppRepo {

        static Pool<PlayerEntity> playerPool;
        static MultiKeySortedDictionary<int, string, PlayerEntity> allPlayer;
        static SortedDictionary<int, PlayerEntity> idDic;
        static Dictionary<string, PlayerEntity> tokenDic;

        static GlobalAppRepo() {
            playerPool = new Pool<PlayerEntity>(() => PlayerEntity.Create(), 16);
            idDic = new SortedDictionary<int, PlayerEntity>();
            tokenDic = new Dictionary<string, PlayerEntity>();
            allPlayer = new MultiKeySortedDictionary<int, string, PlayerEntity>();
        }

        public static PlayerEntity CreatePlayer() {
            return playerPool.Take();
        }

        public static void AddPlayerByIDAndToken(PlayerEntity entity) {
            idDic.Add(entity.connID, entity);
            tokenDic.Add(entity.token, entity);
        }

        public static void AddPlayerByID(PlayerEntity entity) {
            idDic.Add(entity.connID, entity);
        }

        public static bool ContainsPlayerByToken(string token) {
            return tokenDic.ContainsKey(token);
        }

        public static bool ContainsPlayerByConnID(int connID) {
            return idDic.ContainsKey(connID);
        }

        public static bool GetPlayerEntityByConnID(int connID, out PlayerEntity entity) {
            return idDic.TryGetValue(connID, out entity);
        }

        public static bool GetPlayerEntityByToken(string token, out PlayerEntity entity) {
            return tokenDic.TryGetValue(token, out entity);
        }

        public static void Remove(PlayerEntity entity) {
            idDic.Remove(entity.connID);
            tokenDic.Remove(entity.token);
            playerPool.Return(entity);
        }

        public static int GetOnlinePlayerCount() {
            return idDic.Count;
        }

        public static int GetCachedPlayerCount() {
            return tokenDic.Count;
        }

        public static void RemovePlayerIdKey(int connID) {
            idDic.Remove(connID);
        }
        
    }

}