using System;

namespace ActSample.Client.World {

    public interface IEntity {
        EntityType EntityType { get; }
        int EntityID { get; }
    }

}