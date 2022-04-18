using System;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using JackFrame;

namespace SJSJ.Client.Battle {

    public class BattleGo : MonoBehaviour, IEntity {
        
        public EntityType EntityType => EntityType.Battle;

        int entityID;
        public int EntityID => entityID;

        // RENDERER
        public SceneInstance sceneInstance;

        // CHILDREN
        public BattleChildrenComponent ChildrenComponent { get; private set; }

        void Awake() {

            ChildrenComponent = new BattleChildrenComponent();

        }

        public void LoadChildren() {

            // CAMERA
            var cameraRoot = transform.Find("CAMERA_ROOT");
            var cameras = cameraRoot.GetComponentsInChildren<CameraGoEntity>();
            cameras.Foreach(cam => ChildrenComponent.AddCamera(cam));

        }

    }

}