using System;
using UnityEngine;
using ActSample.Server.Facades;
using JackFrame;

namespace ActSample.Server.Operation.Controller {

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