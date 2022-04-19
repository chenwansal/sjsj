using System;

namespace SJSJ.Client.Facades {

    public static class AllInput {
        
        public static InputEntity InputEntity { get; private set; }

        public static void Ctor() {
            InputEntity = new InputEntity();
        }

    }
}