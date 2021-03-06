using System;
using UnityEngine;
using SJSJ.Server.Operation.Controller;

namespace SJSJ.Server.Operation.Entry {

    public class OperationEntry {

        OperationController operationController;
        OperationRepo operationRepo;

        public OperationEntry() {}

        public void Ctor() {
            operationController = new OperationController();
            operationRepo = new OperationRepo();
        }

        public void Inject() {
            operationController.Inject(operationRepo);
        }

        public void Init(GameObject appRoot) {
            operationController.Init(appRoot);
        }

        public void Tick(float deltaTime) {
            operationController.Tick(deltaTime);
        }
    }

}