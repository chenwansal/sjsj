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

            server.OnConnectedHandle += OnConnected;
            server.OnDisconnectedHandle += OnDisconnected;

            server.On((int connID, ConnectReqMessage msg) => {

                if (string.IsNullOrEmpty(msg.token)) {
                    goto noPlayer;
                }

                bool hasPlayer = GlobalAppRepo.GetPlayerEntityByToken(msg.token, out var playerEntity);
                if (hasPlayer) {
                    if (playerEntity.connID != connID) {
                        playerEntity.connID = connID;
                        GlobalAppRepo.AddPlayerByID(playerEntity);
                    }
                    server.Send(connID, new ConnectResMessage { token = msg.token, connID = connID });
                    return;
                } else {
                    goto noPlayer;
                }

            noPlayer:
                PlayerEntity player = GlobalAppRepo.CreatePlayer();
                player.connID = connID;
                player.token = System.Guid.NewGuid().ToString();
                GlobalAppRepo.AddPlayerByIDAndToken(player);
                server.Send(connID, new ConnectResMessage { token = player.token, connID = connID });

            });
        }

        void OnConnected(int connID) {

        }

        void OnDisconnected(int connID) {

            // TODO: DELAY REMOVE CACHE
            GlobalAppRepo.RemovePlayerIdKey(connID);

        }

    }

}