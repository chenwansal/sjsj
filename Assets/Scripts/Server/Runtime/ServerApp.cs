using System;
using System.Collections.Generic;
using UnityEngine;
using JackFrame;
using ActSample.Server.Operation.Entry;

namespace ActSample.Server.MainEntry {

    public class ServerApp : MonoBehaviour {

        // NETWORK
        NetworkEntry networkEntry;

        // OPREATION
        OperationEntry operationEntry;

        void Awake() {

            GlobalAppState.isInit = false;
            GlobalAppState.isTearDown = false;

            DontDestroyOnLoad(gameObject);

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
            Time.fixedDeltaTime = 0.016f;

            // ==== BIND LOG ====
            PLog.OnLog += Debug.Log;
            PLog.OnWarning += Debug.LogWarning;
            PLog.OnError += Debug.LogError;
            PLog.OnAssert += (condition, msg) => Debug.Assert(condition, msg);
            PLog.OnAssertWithoutMessage += (condition) => Debug.Assert(condition);

            // ==== CTOR ====
            // - NETWORK
            networkEntry = new NetworkEntry();

            // - OPERATION
            operationEntry = new OperationEntry();
            operationEntry.Ctor();

            // ==== INJECT ====
            // - NETWORK
            networkEntry.Inject();

            // - OPERATION
            operationEntry.Inject();

            // ==== INIT ====
            // - OPERATION
            operationEntry.Init(gameObject);

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