using System;
using SJSJ.Server.Facades;
using SJSJ.Protocol;

namespace SJSJ.Server.Comparation {

    public class ComparationController {

        // REPO
        ComparationRepo comparationRepo;

        public ComparationController() { }

        public void Ctor() {
            comparationRepo = new ComparationRepo();
        }

        public void Inject() {

        }

        public void Init() {

            // GEN A NEW COMPARATION ENTITY
            ComparationEntity comparationEntity = new ComparationEntity(1);
            comparationRepo.Add(comparationEntity);

            // LISTENING
            var server = AllNetwork.NetworkServer;

            server.On<ComparationStartReqMessage>((connID, msg) => {

                bool hasPlayer = GlobalAppRepo.GetPlayerEntityByConnID(connID, out PlayerEntity entity);

                if (hasPlayer) {

                    // FIND A COMPARATION ENTITY
                    var comparation = comparationRepo.GetComparationEntity(1);
                    (AllyType allyType, int index) = comparation.AddRandomAlly(entity.token);

                    if (allyType != AllyType.None) {
                        // Join the comparation successfully
                        // Response to all
                        var resMsg = new ComparationStartResMessage();
                        resMsg.allyType = (sbyte)allyType;
                        resMsg.index = (sbyte)index;
                        foreach (var otherToken in comparation.GetAllTokens()) {
                            var otherConnID = GlobalAppRepo.GetConnIDByToken(otherToken);
                            if (otherConnID != -1) {
                                server.Send(otherConnID, resMsg);
                            }
                        }
                    } else {
                        // Join the comparation failed
                        // Response to the client
                        var resMsg = new ComparationStartResMessage();
                        resMsg.allyType = (sbyte)AllyType.None;
                        resMsg.index = (sbyte)-1;
                        server.Send(connID, resMsg);
                    }
                }
            });

        }

    }

}