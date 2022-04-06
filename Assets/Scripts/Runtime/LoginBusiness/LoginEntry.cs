using System;
using ActSample.Login.Controller;

namespace ActSample.Login.Entry {

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

        }

        public void Tick(float deltaTime) {
            openAppController.Tick(deltaTime);
        }

    }

}