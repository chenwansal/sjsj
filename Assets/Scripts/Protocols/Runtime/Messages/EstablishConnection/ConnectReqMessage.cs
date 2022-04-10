using JackBuffer;

namespace ActSample.Protocol {

    [JackMessageObject]
    public struct ConnectReqMessage {
        public string token;
    }

}