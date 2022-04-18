using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using JackFrame;

namespace SJSJ.Client.Battle {

    public class BattleFactory {

        public async Task<BattleGo> LoadBattle(string key) {
            var res = await Addressables.LoadSceneAsync(key, LoadSceneMode.Additive).Task;
            var go = res.Scene.GetRootGameObjects().Find(value => value.GetComponent<BattleGo>() != null);
            BattleGo worldGo = go.GetComponent<BattleGo>();
            worldGo.sceneInstance = res;
            return worldGo;
        }

        public async Task UnloadBattle(BattleGo worldGo) {
            await Addressables.UnloadSceneAsync(worldGo.sceneInstance).Task;
        }

    }

}