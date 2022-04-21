using System;

namespace SJSJ.Server {

    public interface IEntity {
        EntityType EntityType { get; }
        int EntityID { get; }
    }

}