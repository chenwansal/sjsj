using System;
using UnityEngine;
using UnityEngine.UI;
using JackFrame;

namespace ActSample {

    public class UIManager : FrameUIManagerBase {

        static UIManager instance;
        public static UIManager Instance => instance;

        public UIManager() {
            if (instance == null) {
                instance = this;
            } else {
                PLog.Warning("DONT INSTANTIATE TWICE");
            }
        }

        public T OpenPage<T>(UIPageID id) where T : FrameUIPanelBase {
            return OpenPage<T>((int)id);
        }

        public T OpenWindow<T>(UIWindowID id) where T : FrameUIPanelBase {
            return OpenWindow<T>((int)id);
        }

        public T OpenWorldTips<T>(UIWorldTipsID id) where T : FrameUIPanelBase {
            return OpenWorldTips<T>((int)id);
        }

        public T OpenUITips<T>(UIUITipsID id) where T : FrameUIPanelBase {
            return OpenUITips<T>((int)id);
        }

        void OnDestroy() {
            instance = null;
        }

    }

}