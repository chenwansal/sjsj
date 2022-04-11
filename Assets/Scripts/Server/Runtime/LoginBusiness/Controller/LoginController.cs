using System;
using UnityEngine;
using JackFrame;
using ActSample.Server.Facades;
using ActSample.Protocol;

namespace ActSample.Server.Login.Controller {

    public class LoginController {

        public LoginController() { }

        public void Inject() {

        }

        public void Init() {

            var server = AllNetwork.NetworkServer;
            server.On((int connID, ConnectReqMessage msg) => {

                if (string.IsNullOrEmpty(msg.token)) {
                    goto noPlayer;
                }

                bool hasPlayer = GlobalAppRepo.ContainsPlayerByToken(msg.token);
                if (hasPlayer) {
                    server.Send(connID, new ConnectResMessage { token = msg.token, connID = connID });
                    return;
                }

            noPlayer:
                PlayerEntity player = GlobalAppRepo.NewPlayer();
                player.connID = connID;
                player.token = System.Guid.NewGuid().ToString();
                GlobalAppRepo.AddPlayer(player);
                server.Send(connID, new ConnectResMessage { token = player.token, connID = connID });

            });
        }

    }

}