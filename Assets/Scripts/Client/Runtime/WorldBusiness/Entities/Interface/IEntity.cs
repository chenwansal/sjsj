using System;

namespace SJSJ.Client.World {

    public interface IEntity {
        EntityType EntityType { get; }
        int EntityID { get; }
    }

}