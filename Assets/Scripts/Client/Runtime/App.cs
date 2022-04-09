using System;
using UnityEngine;
using ActSample.Client.World.Entry;
using ActSample.Client.Login.Entry;
using JackFrame;

namespace ActSample.Client.MainEntry {

    public class App : MonoBehaviour {

        // NETWORK
        NetworkEntry networkEntry;

        // UI
        UIEntry uiEntry;

        // LOGIN
        LoginEntry loginEntry;

        // WORLD
        WorldEntry worldEntry;

        void Awake() {

            AppState.Reset();

            // ==== BIND LOG ====
            PLog.OnLog += Debug.Log;
            PLog.OnWarning += Debug.LogWarning;
            PLog.OnError += Debug.LogError;
            PLog.OnAssert += (condition, msg) => Debug.Assert(condition, msg);
            PLog.OnAssertWithoutMessage += (condition) => Debug.Assert(condition);

            // ==== CTOR ====
            // - NETWORK
            networkEntry = new NetworkEntry();
            
            // - UI
            uiEntry = new UIEntry();

            // - LOGIN
            loginEntry = new LoginEntry();

            // - WORLD
            worldEntry = new WorldEntry();

            // ==== INJECT ====
            // - NETWORK
            networkEntry.Inject();

            // - UI
            uiEntry.Inject();

            // - LOGIN
            loginEntry.Inject();

            // - WORLD
            worldEntry.Inject();

            // ==== INIT ====
            Action initAction = async () => {
                try {
                    // - UI
                    await uiEntry.InitAssets();

                    // - LOGIN
                    loginEntry.Init();

                    // - WORLD
                    worldEntry.Init();

                    AppState.isInit = true;

                } catch (Exception ex) {

                    PLog.Error(ex.ToString());

                }

            };

            initAction.Invoke();


        }

        void Update() {

            if (!AppState.isInit) {
                return;
            }

            float dt = Time.deltaTime;
            networkEntry.Tick();

            loginEntry.Tick(dt);
            worldEntry.Tick(dt);

        }

        void FixedUpdate() {

            if (!AppState.isInit) {
                return;
            }

        }

        void LateUpdate() {

            if (!AppState.isInit) {
                return;
            }

        }

        void OnDestroy() {
            TearDown();
        }

        void OnApplicationQuit() {
            TearDown();
        }

        void TearDown() {

            if (AppState.isTearDown) {
                return;
            }

            AppState.isTearDown = true;

        }

    }

}