using System;
using UnityEngine;
using UnityEngine.UI;

namespace SJSJ.Client.Comparation {

    public class ComparationPlayerElement : MonoBehaviour {

        int ally;
        public int PID { get; private set; }
        SoulType soulType;

        Text playerNameText;
        Text soulNameText;

        void Awake() {
            playerNameText = transform.GetChild(0).GetComponent<Text>();
            soulNameText = transform.GetChild(1).GetComponent<Text>();
        }

        public void Init(int ally, int pid, SoulType soulType, string playerName, string soulName) {
            this.ally = ally;
            this.PID = pid;
            this.soulType = soulType;
            this.playerNameText.text = playerName;
            this.soulNameText.text = soulName;
        }

    }

}