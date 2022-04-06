using System;
using UnityEngine;
using ActSample.World;
using ActSample.World.Controller;
using JackFrame;

namespace ActSample.MainEntry {

    public class App : MonoBehaviour {

        // UI
        UIEntryController uiEntryController;

        // WORLD
        WorldFactory worldFactory;
        WorldLoadController worldLoadController;

        void Awake() {

            AppState.isInit = false;
            AppState.isTearDown = false;

            // ==== CTOR ====
            // - WORLD
            worldFactory = new WorldFactory();
            worldLoadController = new WorldLoadController();

            // ==== INJECT ====
            // - UI
            uiEntryController.Inject();

            // - WORLD
            worldLoadController.Inject(worldFactory);

            // ==== INIT ====
            Action initAction = async () => {
                try {

                    // - UI
                    await uiEntryController.InitAssets();

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
            worldLoadController.Tick(dt);

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