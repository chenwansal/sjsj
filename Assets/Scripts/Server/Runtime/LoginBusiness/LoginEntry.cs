using System;
using ActSample.Server.Login.Controller;

namespace ActSample.Server.Login.Entry {

    public class LoginEntry {

        LoginController loginController;

        public LoginEntry() {}

        public void Ctor() {
            loginController = new LoginController();
        }

        public void Inject() {
            loginController.Inject();
        }

        public void Init() {
            loginController.Init();
        }

    }

}