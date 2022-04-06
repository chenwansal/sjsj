using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using JackFrame;

namespace ActSample {

    public class UIEntryController {

        public void Inject() {

            UIManager ui = new UIManager();

            Transform canvasRoot = GameObject.Find("UI_CANVAS").transform;
            Canvas uiCanvas = canvasRoot.GetComponent<Canvas>();
            Image bg = canvasRoot.Find("BG").GetComponent<Image>();
            Transform pageRoot = canvasRoot.Find("PAGE_ROOT");
            Transform windowRoot = canvasRoot.Find("WINDOW_ROOT");
            Transform worldTipsRoot = canvasRoot.Find("WORLD_TIPS_ROOT");
            Transform uiTipsRoot = canvasRoot.Find("UI_TIPS_ROOT");
            ui.Inject(uiCanvas, bg, pageRoot, windowRoot, worldTipsRoot, uiTipsRoot);

            PLog.Assert(uiCanvas != null);
            PLog.Assert(bg != null);
            PLog.Assert(pageRoot != null);
            PLog.Assert(windowRoot != null);
            PLog.Assert(worldTipsRoot != null);
            PLog.Assert(uiTipsRoot != null);

        }

        public async Task InitAssets() {
            var ui = UIManager.Instance;
            await AddressablesHelper.LoadWithLabel(AssetLabelCollection.UI_LAYOUT, (GameObject go) => {
                var panel = go.GetComponent<FrameUIPanelBase>();
                ui.RegisterUIPrefab(panel);
                PLog.Assert(panel != null);
            });
        }

    }

}