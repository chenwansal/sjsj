using System;
using JackBuffer;

namespace ActSample.Protocol {
    public interface IProtocolService {
        (byte serviceID, byte messageID) GetMessageID<T>() where T : IJackMessage<T>;
        Func<T> GetGenerateHandle<T>() where T : IJackMessage<T>;
    }

}