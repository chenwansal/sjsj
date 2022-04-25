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

        InputField loginUsernameInputField;
        InputField loginPasswordInputField;
        Button loginButton;

        InputField registerUsernameInputField;
        InputField registerPasswordInputField;
        Button registerButton;

        public event Action<string/*username*/, string/*password*/> OnClickLoginHandle;
        public event Action<string/*username*/, string/*password*/> OnClickRegisterHandle;

        void Awake() {

            var loginBD = transform.Find("LoginBD");
            loginUsernameInputField = loginBD.GetChild(0).GetComponent<InputField>();
            loginPasswordInputField = loginBD.GetChild(1).GetComponent<InputField>();
            loginButton = loginBD.GetChild(2).GetComponent<Button>();

            var registerBD = transform.Find("RegisterBD");
            registerUsernameInputField = registerBD.GetChild(0).GetComponent<InputField>();
            registerPasswordInputField = registerBD.GetChild(1).GetComponent<InputField>();
            registerButton = registerBD.GetChild(2).GetComponent<Button>();

            PLog.Assert(loginUsernameInputField != null);
            PLog.Assert(loginPasswordInputField != null);
            
            PLog.Assert(registerUsernameInputField != null);
            PLog.Assert(registerPasswordInputField != null);

            loginButton.onClick.AddListener(() => {
                string username = loginUsernameInputField.text;
                string password = loginPasswordInputField.text;
                OnClickLoginHandle.Invoke(username, password);
            });

            registerButton.onClick.AddListener(() => {
                string username = registerUsernameInputField.text;
                string password = registerPasswordInputField.text;
                OnClickRegisterHandle.Invoke(username, password);
            });

        }

        void Start() {
            PLog.Assert(OnClickLoginHandle != null);
            PLog.Assert(OnClickRegisterHandle != null);
        }

    }

}