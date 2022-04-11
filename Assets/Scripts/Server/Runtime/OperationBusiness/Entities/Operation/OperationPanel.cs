using System;
using UnityEngine;
using UnityEngine.UI;
using JackFrame;

namespace ActSample.Server.Operation {

    public class OperationPanel : MonoBehaviour {

        Button startServerButton;
        Button stopServerButton;
        InputField portInputField;

        Text onlinePlayerCountText;
        Text cachedPlayerCountText;

        public event Action<int> OnStartServerHandle;
        public event Action OnStopServerHandle;

        void Awake() {

            var bd = transform.Find("BD");
            startServerButton = bd.Find("StartServerButton").GetComponent<Button>();
            stopServerButton = bd.Find("StopServerButton").GetComponent<Button>();
            portInputField = bd.Find("PortInputField").GetComponent<InputField>();

            onlinePlayerCountText = bd.Find("OnlinePlayerCountText").GetComponent<Text>();
            cachedPlayerCountText = bd.Find("CachedPlayerCountText").GetComponent<Text>();

            PLog.Assert(onlinePlayerCountText != null);
            PLog.Assert(cachedPlayerCountText != null);

            startServerButton.onClick.AddListener(() => {
                string value = portInputField.text;
                int.TryParse(value, out int port);
                OnStartServerHandle.Invoke(port);
            });

            stopServerButton.onClick.AddListener(() => {
                OnStopServerHandle.Invoke();
            });
        }

        public void SetOnlinePlayerCount(int count) {
            onlinePlayerCountText.text = "在线玩家数: " + count.ToString();
        }

        public void SetCachedPlayerCount(int count) {
            cachedPlayerCountText.text = "缓存玩家数: " + count.ToString();
        }

    }

}