using System;

namespace ActSample.World {

    public interface IEntity {
        EntityType EntityType { get; }
        int EntityID { get; }
    }

}