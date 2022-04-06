using System;
using UnityEngine;

namespace ActSample.Login.Controller {

    public class LoginOpenAppController {

        LoginRepo loginRepo;

        public LoginOpenAppController() { }

        public void Inject(LoginRepo loginRepo) {
            this.loginRepo = loginRepo;
        }

        public void Tick(float deltaTime) {

            if (!AppState.isFresh) {
                return;
            }

            AppState.isFresh = false;

            if (loginRepo.TitlePage == null) {
                var ui = UIManager.Instance;
                TitlePage titlePage = ui.OpenPage<TitlePage>((UIPageID.Title));
                titlePage.OnClickEnterGameHandle += OnClickEnterGame;
                loginRepo.TitlePage = titlePage;
            }

        }

        void OnClickEnterGame() {
            var em = AppEventCenter.LoginToWorldEM;
            em.isTrigger = true;
            em.worldSignID = "TestScene";

            loginRepo.TitlePage.CloseAndDestroy();

        }

    }

}