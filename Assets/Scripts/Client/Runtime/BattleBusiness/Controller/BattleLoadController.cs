using System;
using JackFrame;

namespace SJSJ.Client.Battle.Controller {

    public class BattleLoadController {

        BattleFactory battleFactory;
        BattleRepo battleRepo;

        public BattleLoadController() { }

        public void Inject(BattleFactory battleFactory, BattleRepo battleRepo) {
            this.battleFactory = battleFactory;
            this.battleRepo = battleRepo;
        }

        public void Tick(float deltaTime) {

            var ev = GlobalAppEventCenter.LoginToBattleEvent;
            if (!ev.isTrigger) {
                return;
            }

            ev.isTrigger = false;

            Action action = async () => {

                var go = await battleFactory.LoadBattle(ev.sceneSignID);
                PLog.Log("WORLD SPAWNED");

                go.LoadChildren();

                battleRepo.Add(go);
                int count = battleRepo.Count();
                if (count == 1) {
                    battleRepo.SetCurrentBattle(go);
                } else {
                    PLog.Warning($"世界数量有多余: {count}");
                }

            };

            action.Invoke();

        }

    }

}