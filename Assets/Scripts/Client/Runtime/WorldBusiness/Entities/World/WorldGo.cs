using System;
using UnityEngine;

namespace ActSample.Client.World {

    public class WorldGo : MonoBehaviour, IEntity {
        
        public EntityType EntityType => EntityType.World;

        int entityID;
        public int EntityID => entityID;

    }

}