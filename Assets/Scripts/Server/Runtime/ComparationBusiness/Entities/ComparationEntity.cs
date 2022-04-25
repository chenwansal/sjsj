using System;
using System.Collections.Generic;

namespace SJSJ.Server.Comparation {

    public class ComparationEntity {

        public int ID { get; private set; }
        int eachAllyCount;

        List<string> redAllies;
        List<string> blueAllies;

        public ComparationEntity(int id, int eachAllyCount = 4) {
            redAllies = new List<string>();
            blueAllies = new List<string>();
            this.ID = id;
            this.eachAllyCount = eachAllyCount;
        }

        public (AllyType allyType, int index) AddRandomAlly(string userToken) {
            if (redAllies.Count < blueAllies.Count) {
                if (redAllies.Count < eachAllyCount) {
                    redAllies.Add(userToken);
                    return (AllyType.Red, redAllies.Count - 1);
                } else {
                    return (AllyType.None, -1);
                }
            } else {
                if (blueAllies.Count < eachAllyCount) {
                    blueAllies.Add(userToken);
                    return (AllyType.Blue, blueAllies.Count - 1);
                } else {
                    return (AllyType.None, -1);
                }
            }
        }

        public void AddRedAlly(string userToken) {
            redAllies.Add(userToken);
        }

        public void RemoveRedAlly(string userToken) {
            redAllies.Remove(userToken);
        }

        public void ClearBlueAllies() {
            blueAllies.Clear();
        }

        public void ClearRedAllies() {
            redAllies.Clear();
        }

        public IEnumerable<string> GetAllTokens() {
            foreach (var item in redAllies) {
                yield return item;
            }
            foreach (var item in blueAllies) {
                yield return item;
            }
        }

        public IEnumerable<string> GetRedAllies() {
            return redAllies;
        }

        public IEnumerable<string> GetBlueAllies() {
            return blueAllies;
        }

        public void AddBlueAlly(string userToken) {
            blueAllies.Add(userToken);
        }

        public void RemoveBlueAlly(string userToken) {
            blueAllies.Remove(userToken);
        }

    }

}