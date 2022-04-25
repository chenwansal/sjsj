using System;

namespace SJSJ.Server.Comparation.Entry {

    public class ComparationEntry {

        ComparationController comparationController;

        public ComparationEntry() {}

        public void Ctor() {
            comparationController = new ComparationController();
            comparationController.Ctor();
        }

        public void Inject() {
            comparationController.Inject();
        }

        public void Init() {
            comparationController.Init();
        }

    }
}