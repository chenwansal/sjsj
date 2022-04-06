using System;
using System.Threading.Tasks;
using UnityEngine;
using ActSample.World.Controller;

namespace ActSample.World.Entry {

    public class WorldEntry {

        WorldFactory worldFactory;
        WorldRepo worldRepo;

        WorldLoadController worldLoadController;

        public WorldEntry() {
            worldFactory = new WorldFactory();
            worldRepo = new WorldRepo();
            worldLoadController = new WorldLoadController();
        }

        public void Inject() {
            worldLoadController.Inject(worldFactory, worldRepo);
        }

        public void Init() {

        }

        public void Tick(float deltaTime) {
            worldLoadController.Tick(deltaTime);
        }

    }

}