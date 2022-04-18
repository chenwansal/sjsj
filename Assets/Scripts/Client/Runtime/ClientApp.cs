using System;
using UnityEngine;
using SJSJ.Client.World.Entry;
using SJSJ.Client.Login.Entry;
using SJSJ.Client.Facades;
using JackFrame;

namespace SJSJ.Client.MainEntry {

    public class ClientApp : MonoBehaviour {

        // NETWORK
        NetworkEntry networkEntry;

        // UI
        UIEntry uiEntry;

        // LOGIN
        LoginEntry loginEntry;

        // WORLD
        WorldEntry worldEntry;

        void Awake() {

            var appState = GlobalAppRepo.AppState;
            appState.Reset();

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

                    appState.isInit = true;

                } catch (Exception ex) {

                    PLog.Error(ex.ToString());

                }

            };

            initAction.Invoke();


        }

        void Update() {

            var appState = GlobalAppRepo.AppState;
            if (!appState.isInit) {
                return;
            }

            float dt = Time.deltaTime;
            networkEntry.Tick();

            loginEntry.Tick(dt);
            worldEntry.Tick(dt);

        }

        void FixedUpdate() {

            var appState = GlobalAppRepo.AppState;
            if (!appState.isInit) {
                return;
            }

        }

        void LateUpdate() {

            var appState = GlobalAppRepo.AppState;
            if (!appState.isInit) {
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

            var appState = GlobalAppRepo.AppState;
            if (appState.isTearDown) {
                return;
            }

            appState.isTearDown = true;

            networkEntry.TearDown();

        }

    }

}