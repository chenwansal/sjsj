using System;

namespace SJSJ.Client.Battle {

    public interface IEntity {
        EntityType EntityType { get; }
        int EntityID { get; }
    }

}