using System;
using UnityEngine;
using ActSample.Client.Facades;

namespace ActSample.Client.Login.Controller {

    public class LoginOpenAppController {

        LoginRepo loginRepo;

        public LoginOpenAppController() { }

        public void Inject(LoginRepo loginRepo) {
            this.loginRepo = loginRepo;
        }

        public void Tick(float deltaTime) {

            var appState = GlobalAppRepo.AppState;
            if (!appState.isFresh) {
                return;
            }

            appState.isFresh = false;

            if (loginRepo.TitlePage == null) {
                var ui = UIManager.Instance;
                TitlePage titlePage = ui.OpenPage<TitlePage>((UIPageID.Title));
                titlePage.OnClickEnterGameHandle += OnClickEnterGame;
                loginRepo.TitlePage = titlePage;
            }

            var client = AllNetwork.NetworkClient;
            client.Connect("127.0.0.1", 4399);

        }

        void OnClickEnterGame() {
            var em = GlobalAppEventCenter.LoginToWorldEM;
            em.isTrigger = true;
            em.worldSignID = "TestScene";

            loginRepo.TitlePage.CloseAndDestroy();

        }

    }

}