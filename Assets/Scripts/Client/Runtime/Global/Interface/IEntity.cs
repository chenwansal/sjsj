using System;

namespace SJSJ.Client {

    public interface IEntity {
        EntityType EntityType { get; }
        int EntityID { get; }
    }

}