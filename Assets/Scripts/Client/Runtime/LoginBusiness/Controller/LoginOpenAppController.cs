using System;
using UnityEngine;
using SJSJ.Client.Facades;
using SJSJ.Protocol;

namespace SJSJ.Client.Login.Controller {

    public class LoginOpenAppController {

        LoginRepo loginRepo;

        public LoginOpenAppController() { }

        public void Inject(LoginRepo loginRepo) {
            this.loginRepo = loginRepo;
        }

        public void Init() {
            var client = AllNetwork.NetworkClient;
            client.On<ConnectResMessage>(OnConnected);
        }

        public void Tick(float deltaTime) {

        }

        void OnConnected(ConnectResMessage msg) {
            var player = GlobalAppRepo.PlayerEntity;
            player.connID = msg.connID;
            player.token = msg.token;

            if (loginRepo.LoginTitlePage == null) {
                var ui = UIManager.Instance;
                LoginTitlePage titlePage = ui.OpenPage<LoginTitlePage>((UIPageID.Title));
                titlePage.OnClickEnterGameHandle += OnClickEnterGame;
                loginRepo.LoginTitlePage = titlePage;
            }

        }

        void OnClickEnterGame() {
            var ev = GlobalAppEventCenter.LoginToBattleEvent;
            ev.isTrigger = true;
            ev.sceneSignID = "TestScene";

            loginRepo.LoginTitlePage.CloseAndDestroy();
        }

    }

}