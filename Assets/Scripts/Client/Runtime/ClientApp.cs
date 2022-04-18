using System;
using UnityEngine;
using SJSJ.Client.Battle.Entry;
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

        // BATTLE
        BattleEntry battleEntry;

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

            // - BATTLE
            battleEntry = new BattleEntry();

            // ==== INJECT ====
            // - NETWORK
            networkEntry.Inject();

            // - UI
            uiEntry.Inject();

            // - LOGIN
            loginEntry.Inject();

            // - BATTLE
            battleEntry.Inject();

            // ==== INIT ====
            Action initAction = async () => {
                try {

                    // - NETWORK
                    networkEntry.Init();

                    // - UI
                    await uiEntry.InitAssets();

                    // - LOGIN
                    loginEntry.Init();

                    // - BATTLE
                    battleEntry.Init();

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
            battleEntry.Tick(dt);

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