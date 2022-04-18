using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using JackFrame;

namespace SJSJ.Client.Battle {

    public class BattleChildrenComponent {

        List<CameraGoEntity> cameraGoEntities;

        public BattleChildrenComponent() {
            this.cameraGoEntities = new List<CameraGoEntity>();
        }

        // CAMERA
        public void AddCamera(CameraGoEntity cameraGo) {
            if (cameraGo.isMain) {
                cameraGoEntities.Insert(0, cameraGo);
            } else {
                cameraGoEntities.Add(cameraGo);
            }
        }

        public CameraGoEntity GetMainCamera() {
            if (cameraGoEntities.Count == 0) {
                PLog.Error("不存在相机");
                return null;
            }
            return cameraGoEntities.First();
        }

    }

}