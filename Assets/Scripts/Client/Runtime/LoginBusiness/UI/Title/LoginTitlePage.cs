using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JackFrame;

namespace SJSJ.Client.Login {

    public class LoginTitlePage : FrameUIPanelBase {

        public override int Id => (int)UIPageID.Title;
        public override UIRootLevel RootLevel => UIRootLevel.Page;
        public override bool IsUnique => true;

        Button enterGameButton;

        public event Action OnClickEnterGameHandle;

        void Awake() {

            var bd = transform.Find("BD");
            enterGameButton = bd.Find("EnterGameButton").GetComponent<Button>();

            PLog.Assert(enterGameButton != null);

            enterGameButton.onClick.AddListener(() => {
                OnClickEnterGameHandle.Invoke();
            });

        }

        void Start() {
#if !UNITY_INCLUDE_TESTS
            PLog.Assert(OnClickEnterGameHandle != null);
#endif

        }

    }

}