using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JackFrame;

namespace SJSJ.Client.World {

    public class WorldMainNavigationWindow : FrameUIPanelBase {
        
        public override int Id => (int)UIWindowID.WorldMainNavigation;
        public override UIRootLevel RootLevel => UIRootLevel.Window;
        public override bool IsUnique => true;

        Button openSoulButton;
        Button startComparationButton;

        void Awake() {
            
        }

    }

}