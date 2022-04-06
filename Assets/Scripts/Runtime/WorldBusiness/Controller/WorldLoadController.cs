using System;

namespace ActSample.World.Controller {

    public class WorldLoadController {

        WorldFactory worldFactory;

        public WorldLoadController() {}

        public void Inject(WorldFactory worldFactory) {
            this.worldFactory = worldFactory;
        }

        public void Tick(float deltaTime) {

        }

    }

}