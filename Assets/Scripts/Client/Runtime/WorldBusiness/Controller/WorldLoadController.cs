using System;
using JackFrame;

namespace SJSJ.Client.World.Controller {

    public class WorldLoadController {

        WorldFactory worldFactory;
        WorldRepo worldRepo;

        public WorldLoadController() { }

        public void Inject(WorldFactory worldFactory, WorldRepo worldRepo) {
            this.worldFactory = worldFactory;
            this.worldRepo = worldRepo;
        }

        public void Tick(float deltaTime) {

            var em = GlobalAppEventCenter.LoginToWorldEM;
            if (!em.isTrigger) {
                return;
            }

            em.isTrigger = false;

            Action action = async () => {

                var go = await worldFactory.LoadWorld(em.worldSignID);
                PLog.Log("WORLD SPAWNED");

                go.LoadChildren();

                worldRepo.Add(go);
                int count = worldRepo.Count();
                if (count == 1) {
                    worldRepo.SetCurrentWorld(go);
                } else {
                    PLog.Warning($"世界数量有多余: {count}");
                }

            };

            action.Invoke();

        }

    }

}