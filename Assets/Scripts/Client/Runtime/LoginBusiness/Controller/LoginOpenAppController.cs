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
            client.Connect("127.0.0.1", 4399);
        }

        public void Tick(float deltaTime) {

        }

        void OnConnected(ConnectResMessage msg) {
            var player = GlobalAppRepo.PlayerEntity;
            player.connID = msg.connID;
            player.token = msg.token;

            if (loginRepo.TitlePage == null) {
                var ui = UIManager.Instance;
                TitlePage titlePage = ui.OpenPage<TitlePage>((UIPageID.Title));
                titlePage.OnClickEnterGameHandle += OnClickEnterGame;
                loginRepo.TitlePage = titlePage;
            }

        }

        void OnClickEnterGame() {
            var em = GlobalAppEventCenter.LoginToWorldEM;
            em.isTrigger = true;
            em.worldSignID = "TestScene";

            loginRepo.TitlePage.CloseAndDestroy();
        }

    }

}