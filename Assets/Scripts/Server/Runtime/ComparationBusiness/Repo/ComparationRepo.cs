using System;
using System.Collections.Generic;

namespace SJSJ.Server.Comparation {

    public class ComparationRepo {

        List<ComparationEntity> all;

        public ComparationRepo() {
            this.all = new List<ComparationEntity>();
        }

        public void Add(ComparationEntity entity) {
            this.all.Add(entity);
        }

        public void Remove(ComparationEntity entity) {
            this.all.Remove(entity);
        }

        public ComparationEntity GetComparationEntity(int id) {
            return all.Find(value => value.ID == id);
        }

    }

}