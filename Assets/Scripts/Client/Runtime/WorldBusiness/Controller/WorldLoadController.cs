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
                worldRepo.Add(go);

                PLog.Log("WORLD SPAWNED");

            };

            action.Invoke();

        }

    }

}