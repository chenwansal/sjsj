using System;
using System.Collections.Generic;
using UnityEngine;
using JackFrame;

namespace ActSample.Server.MainEntry {

    public class ServerApp : MonoBehaviour {

        // NETWORK
        NetworkEntry networkEntry;

        void Awake() {

            GlobalAppState.isInit = false;
            GlobalAppState.isTearDown = false;

            DontDestroyOnLoad(gameObject);

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
            Time.fixedDeltaTime = 0.016f;

            // ==== CTOR ====
            networkEntry = new NetworkEntry();

            // ==== INJECT ====
            networkEntry.Inject();

            // ==== INIT ====
            GlobalAppState.isInit = true;

        }

        void Update() {

            if (!GlobalAppState.isInit) {
                return;
            }

        }

        void FixedUpdate() {

            if (!GlobalAppState.isInit) {
                return;
            }

            networkEntry.Tick();

        }

        void OnDestroy() {
            TearDown();
        }

        void OnApplicationQuit() {
            TearDown();
        }

        void TearDown() {
            if (GlobalAppState.isTearDown) {
                return;
            }

            GlobalAppState.isTearDown = true;
        }

    }

}