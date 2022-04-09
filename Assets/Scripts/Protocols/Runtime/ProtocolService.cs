using System;
using System.Collections.Generic;
using UnityEngine;
using JackBuffer;

namespace ActSample.Protocol
{
    public class ProtocolService : IProtocolService
    {
        Dictionary<Type, ushort> messageInfoDic;
        Dictionary<Type, object> generateDic;
        public ProtocolService()
        {
            this.messageInfoDic = new Dictionary<Type, ushort>();
            this.generateDic = new Dictionary<Type, object>();
            Init();
        }

        public Func<T> GetGenerateHandle<T>()
            where T : IJackMessage<T>
        {
            var type = typeof(T);
            bool hasFunc = generateDic.TryGetValue(type, out object func);
            if (hasFunc)
            {
                return func as Func<T>;
            }
            else
            {
                throw new Exception("Not Registered: " + type.Name);
            }
        }

        public (byte serviceID, byte messageID) GetMessageID<T>()
            where T : IJackMessage<T>
        {
            var type = typeof(T);
            bool hasMessage = messageInfoDic.TryGetValue(type, out ushort value);
            if (hasMessage)
            {
                return ((byte)value, (byte)(value >> 8));
            }
            else
            {
                throw new Exception("Not Registered: " + type.Name);
            }
        }

        private void Init()
        {
            messageInfoDic.Add(typeof(TestReqMessage), 0);
            generateDic.Add(typeof(TestReqMessage), new Func<TestReqMessage>(() => new TestReqMessage()));
            messageInfoDic.Add(typeof(TestResMessage), 1);
            generateDic.Add(typeof(TestResMessage), new Func<TestResMessage>(() => new TestResMessage()));
        }
    }
}