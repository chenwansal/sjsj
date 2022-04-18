using System;
using UnityEngine;
using Cinemachine;
using JackFrame;

namespace SJSJ.Client {

    public class CameraGoEntity : MonoBehaviour {

        // PARAMS
        public bool isMain;

        // MODEL
        Vector3 originPos;

        // RENDERER
        Transform stand;
        CinemachineVirtualCamera cam;
        CinemachineFramingTransposer framingTransposer;

        public Transform Stand => stand;

        void Awake() {
            
            stand = transform.Find("stand");
            cam = stand.Find("cam").GetComponent<CinemachineVirtualCamera>();
            framingTransposer = cam.GetCinemachineComponent<CinemachineFramingTransposer>();
            originPos = framingTransposer.m_TrackedObjectOffset;

            PLog.Assert(cam != null);
            PLog.Assert(framingTransposer != null);

        }

        public void SetPos(Vector3 pos) {
            framingTransposer.m_TrackedObjectOffset = pos;
        }

        public void ResetPos() {
            framingTransposer.m_TrackedObjectOffset = originPos;
        }

        public void MoveOffset(float xOffset, float yOffset, float zOffset) {
            Vector3 old = framingTransposer.m_TrackedObjectOffset;
            old += new Vector3(xOffset, yOffset, zOffset);
            framingTransposer.m_TrackedObjectOffset = old;
        }

        public void RotateYOffset(float yOffset) {
            Vector3 old = stand.rotation.eulerAngles;
            old += new Vector3(0, yOffset, 0);
            stand.Rotate(old);
        }

        public void Follow(Transform target) {
            cam.Follow = target;
        }

        public void LookAt(Transform target) {
            cam.LookAt = target;
        }

    }

}