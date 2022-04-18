using System;
using System.Collections.Generic;
using UnityEngine;

namespace SJSJ.Client.Battle {

    public class BattleRepo {

        Dictionary<int/* EntityID */, BattleGo> all;
        BattleGo current;

        public BattleRepo() {
            this.all = new Dictionary<int, BattleGo>();
        }

        public void Add(BattleGo go) {
            if (all.ContainsKey(go.EntityID)) {
                return;
            }
            all.Add(go.EntityID, go);
        }

        public void SetCurrentBattle(BattleGo go) {
            this.current = go;
        }

        public int Count() {
            return all.Count;
        }

        public BattleGo GetCurrentBattle() {
            return current;
        }

        public BattleGo Get(int entityID) {
            all.TryGetValue(entityID, out var go);
            return go;
        }

    }

}