using System;
using UnityEngine;
using SJSJ.Server.Facades;
using JackFrame;

namespace SJSJ.Server.Operation.Controller {

    public class OperationController {

        OperationRepo operationRepo;

        public OperationController() {}

        public void Inject(OperationRepo operationRepo) {
            this.operationRepo = operationRepo;
        }

        public void Init(GameObject appRoot) {
            var canvas = appRoot.transform.Find("Canvas");
            var operationPanel = canvas.Find("OperationPanel").GetComponent<OperationPanel>();
            operationRepo.OperationPanel = operationPanel;

            operationPanel.OnStartServerHandle += OnStartServer;
            operationPanel.OnStopServerHandle += OnStopServer;
        }

        public void Tick(float deltaTime) {

            var operationPanel = operationRepo.OperationPanel;
            if (operationPanel == null) {
                return;
            }

            int beforePlayerCount = GlobalAppState.onlinePlayerCount;
            int nowPlayerCount = GlobalAppRepo.GetCachedPlayerCount();
            if (beforePlayerCount != nowPlayerCount) {
                GlobalAppState.onlinePlayerCount = nowPlayerCount;
                operationPanel.SetOnlinePlayerCount(nowPlayerCount);
            }

            beforePlayerCount = GlobalAppState.cachedPlayerCount;
            nowPlayerCount = GlobalAppRepo.GetCachedPlayerCount();
            if (beforePlayerCount != nowPlayerCount) {
                GlobalAppState.cachedPlayerCount = nowPlayerCount;
                operationPanel.SetCachedPlayerCount(nowPlayerCount);
            }

        }

        void OnStartServer(int port) {
            var server = AllNetwork.NetworkServer;
            server.StartListen(port);
            PLog.Log("Listen: " + port.ToString());
        }

        void OnStopServer() {
            var server = AllNetwork.NetworkServer;
            server.StopListen();
            PLog.Log("Stop");
        }

    }
}