using System;
using SJSJ.Server.Login.Controller;

namespace SJSJ.Server.Login.Entry {

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