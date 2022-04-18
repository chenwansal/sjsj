using System;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using JackFrame;

namespace SJSJ.Client.World {

    public class WorldGo : MonoBehaviour, IEntity {
        
        public EntityType EntityType => EntityType.World;

        int entityID;
        public int EntityID => entityID;

        // RENDERER
        public SceneInstance sceneInstance;

        // CHILDREN
        public WorldChildrenComponent ChildrenComponent { get; private set; }

        void Awake() {

            ChildrenComponent = new WorldChildrenComponent();
            
        }

        public void LoadChildren() {

            // CAMERA
            var cameraRoot = transform.Find("CAMERA_ROOT");
            var cameras = cameraRoot.GetComponentsInChildren<CameraGoEntity>();
            cameras.Foreach(cam => ChildrenComponent.AddCamera(cam));

        }

    }

}