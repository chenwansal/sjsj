using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JackFrame;

namespace SJSJ.Client {

    public class InputMoveJoystickWindow : FrameUIPanelBase, IPointerDownHandler, IPointerUpHandler, IDragHandler {

        public override int Id => (int)UIWindowID.MoveJoystick;
        public override UIRootLevel RootLevel => UIRootLevel.Window;
        public override bool IsUnique => true;

        RectTransform boardRect;
        Transform joystickRoot;
        Image bgImg;
        Image pointerImg;

        float radius;
        Vector2 downPos;
        Vector2 axis;

        bool isLock;

        public event Action<Vector2> OnDragHandle;
        public event Action<Vector2> OnEndDragHandle;

        void Awake() {

            isLock = false;

            boardRect = GetComponent<RectTransform>();
            joystickRoot = transform.Find("JoystickRoot");
            bgImg = joystickRoot.Find("BG").GetComponent<Image>();
            pointerImg = joystickRoot.Find("Pointer").GetComponent<Image>();

            PLog.Assert(bgImg != null);
            PLog.Assert(pointerImg != null);

            radius = bgImg.rectTransform.rect.x * 0.5f;
            radius = Math.Abs(radius);

        }

        public void LockJoystick(bool isLock) {
            this.isLock = isLock;
        }

        public void OnPointerDown(PointerEventData eventData) {

            if (!joystickRoot.gameObject.activeSelf) {
                joystickRoot.gameObject.SetActive(true);
            }

            Vector2 localPos = eventData.position;

            if (!isLock) {

                bgImg.rectTransform.position = localPos;
                pointerImg.rectTransform.position = localPos;
                downPos = localPos;

                PLog.Log("DOWN POS: " + downPos.ToString());

            } else {
                PLog.Error("未处理该 Case");
            }

        }

        public void OnPointerUp(PointerEventData eventData) {
            if (joystickRoot.gameObject.activeSelf) {
                joystickRoot.gameObject.SetActive(false);
            }
            if (OnEndDragHandle != null) {
                OnEndDragHandle.Invoke(eventData.position - downPos);
            }
        }

        public void OnDrag(PointerEventData eventData) {
            Vector2 pos = eventData.position;
            Vector2 dir = pos - downPos;
            dir.Normalize();
            float distance = Vector2.Distance(pos, downPos);
            if (distance > radius) {
                pos = (Vector2)bgImg.rectTransform.position + dir * radius;
            }
            pointerImg.rectTransform.position = pos;
            if (OnDragHandle != null) {
                OnDragHandle.Invoke(pos - downPos);
            }
        }

    }

}