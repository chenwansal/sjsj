using System;
using System.Collections.Generic;

namespace SJSJ.Client {

    public static class GlobalAppEventCenter {

        public static LoginToBattleEvent LoginToBattleEvent { get; set; } = new LoginToBattleEvent();

    }

}