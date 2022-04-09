using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using JackFrame;

namespace ActSample.Client.World {

    public class WorldFactory {

        public async Task<WorldGo> LoadWorld(string key) {
            var res = await Addressables.LoadSceneAsync(key, LoadSceneMode.Additive).Task;
            var go = res.Scene.GetRootGameObjects().Find(value => value.GetComponent<WorldGo>() != null);
            return go.GetComponent<WorldGo>();
        }

    }

}