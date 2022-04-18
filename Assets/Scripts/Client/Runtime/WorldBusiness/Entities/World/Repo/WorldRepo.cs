using System;
using System.Collections.Generic;
using UnityEngine;

namespace SJSJ.Client.World {

    public class WorldRepo {

        Dictionary<int/* EntityID */, WorldGo> all;
        WorldGo current;

        public WorldRepo() {
            this.all = new Dictionary<int, WorldGo>();
        }

        public void Add(WorldGo go) {
            if (all.ContainsKey(go.EntityID)) {
                return;
            }
            all.Add(go.EntityID, go);
        }

        public void SetCurrentWorld(WorldGo go) {
            this.current = go;
        }

        public int Count() {
            return all.Count;
        }

        public WorldGo GetCurrentWorld() {
            return current;
        }

        public WorldGo Get(int entityID) {
            all.TryGetValue(entityID, out var go);
            return go;
        }

    }

}