using System;
using System.Threading.Tasks;
using UnityEngine;
using SJSJ.Client.Battle.Controller;

namespace SJSJ.Client.Battle.Entry {

    public class BattleEntry {

        BattleFactory battleFactory;
        BattleRepo battleRepo;

        BattleLoadController battleLoadController;

        public BattleEntry() {
            battleFactory = new BattleFactory();
            battleRepo = new BattleRepo();
            battleLoadController = new BattleLoadController();
        }

        public void Inject() {
            battleLoadController.Inject(battleFactory, battleRepo);
        }

        public void Init() {

        }

        public void Tick(float deltaTime) {
            battleLoadController.Tick(deltaTime);
        }

    }

}