using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JackFrame;

namespace SJSJ.Client.Comparation {

    public class ComparationWindow : FrameUIPanelBase {

        public override int Id => (int)UIWindowID.Comparation;
        public override UIRootLevel RootLevel => UIRootLevel.Window;
        public override bool IsUnique => true;

        [SerializeField] ComparationPlayerElement elementPrefab;
        List<ComparationPlayerElement> elements;
        Transform blueGroup;
        Transform redGroup;
        Button startButton;

        public event Action OnStartHandle;

        void Awake() {

            var teamBD = transform.GetChild(0);
            blueGroup = teamBD.GetChild(0);
            redGroup = teamBD.GetChild(1);

            var buttonBD = transform.GetChild(1);
            startButton = buttonBD.GetChild(0).GetComponent<Button>();

            PLog.Assert(elementPrefab != null);
            PLog.Assert(blueGroup != null);
            PLog.Assert(redGroup != null);

            this.elements = new List<ComparationPlayerElement>();

            startButton.onClick.AddListener(() => {
                OnStartHandle.Invoke();
            });

        }

        void Start() {
            PLog.Assert(OnStartHandle != null);
        }

        public void AddPlayer(int ally, int pid, SoulType soulType, string playerName, string soulName) {
            var root = ally == 0 ? blueGroup : redGroup;
            ComparationPlayerElement element = GameObject.Instantiate(elementPrefab, root);
            element.Init(ally, pid, soulType, playerName, soulName);
            elements.Add(element);
        }

        public void RemovePlayer(int pid) {
            int index = elements.FindIndex(value => value.PID == pid);
            if (index != -1) {
                var element = elements[index];
                elements.RemoveAt(index);
                GameObject.Destroy(element.gameObject);
            }
        }

    }

}