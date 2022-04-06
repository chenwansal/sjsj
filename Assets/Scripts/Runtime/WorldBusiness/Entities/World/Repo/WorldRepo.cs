using System;
using System.Collections.Generic;
using UnityEngine;

namespace ActSample.World {

    public class WorldRepo {

        Dictionary<int/* EntityID */, WorldGo> all;

        public WorldRepo() {
            this.all = new Dictionary<int, WorldGo>();
        }

        public void Add(WorldGo go) {
            all.Add(go.EntityID, go);
        }

        public WorldGo Get(int entityID) {
            all.TryGetValue(entityID, out var go);
            return go;
        }

    }

}