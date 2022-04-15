using System;
using SJSJ.Client.Login.Controller;

namespace SJSJ.Client.Login.Entry {

    public class LoginEntry {

        LoginRepo loginRepo;

        LoginOpenAppController openAppController;

        public LoginEntry() {
            
            loginRepo = new LoginRepo();

            openAppController = new LoginOpenAppController();

        }

        public void Inject() {

            openAppController.Inject(loginRepo);

        }

        public void Init() {

            openAppController.Init();

        }

        public void Tick(float deltaTime) {
            openAppController.Tick(deltaTime);
        }

    }

}