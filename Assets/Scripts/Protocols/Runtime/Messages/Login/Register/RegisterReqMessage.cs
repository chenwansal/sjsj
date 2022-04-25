using System;
using JackBuffer;

namespace SJSJ.Protocol {

    [JackMessageObject]
    public struct RegisterReqMessage {
        public string username;
        public string password;
    }
}