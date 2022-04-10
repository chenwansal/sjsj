using System;
using UnityEngine;
using UnityEngine.UI;

namespace ActSample.Server.Operation {

    public class OperationPanel : MonoBehaviour {

        Button startServerButton;
        Button stopServerButton;
        InputField portInputField;

        public event Action<int> OnStartServerHandle;
        public event Action OnStopServerHandle;

        void Awake() {
            var bd = transform.Find("BD");
            startServerButton = bd.Find("StartServerButton").GetComponent<Button>();
            stopServerButton = bd.Find("StopServerButton").GetComponent<Button>();
            portInputField = bd.Find("PortInputField").GetComponent<InputField>();

            startServerButton.onClick.AddListener(() => {
                string value = portInputField.text;
                int.TryParse(value, out int port);
                OnStartServerHandle.Invoke(port);
            });

            stopServerButton.onClick.AddListener(() => {
                OnStopServerHandle.Invoke();
            });
        }

    }

}