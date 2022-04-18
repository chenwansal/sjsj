using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using JackFrame;

namespace SJSJ.Client.World {

    public class WorldFactory {

        public async Task<WorldGo> LoadWorld(string key) {
            var res = await Addressables.LoadSceneAsync(key, LoadSceneMode.Additive).Task;
            var go = res.Scene.GetRootGameObjects().Find(value => value.GetComponent<WorldGo>() != null);
            WorldGo worldGo = go.GetComponent<WorldGo>();
            worldGo.sceneInstance = res;
            return worldGo;
        }

        public async Task UnloadWorld(WorldGo worldGo) {
            await Addressables.UnloadSceneAsync(worldGo.sceneInstance).Task;
        }

    }

}