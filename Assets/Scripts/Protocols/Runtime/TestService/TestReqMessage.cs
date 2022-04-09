using JackBuffer;
using System;

namespace ActSample.Protocol
{
    [JackMessageObject]
    public struct TestReqMessage : IJackMessage<TestReqMessage>
    {
        public string msg;
        public void WriteTo(byte[] dst, ref int offset)
        {
            BufferWriter.WriteUTF8String(dst, msg, ref offset);
        }

        public void FromBytes(byte[] src, ref int offset)
        {
            msg = BufferReader.ReadUTF8String(src, ref offset);
        }

        public int GetEvaluatedSize(out bool isCertain)
        {
            int count = 2;
            isCertain = false;
            if (msg != null)
            {
                count += msg.Length * 4;
            }

            return count;
        }

        public byte[] ToBytes()
        {
            int count = GetEvaluatedSize(out bool isCertain);
            int offset = 0;
            byte[] src = new byte[count];
            WriteTo(src, ref offset);
            if (isCertain)
            {
                return src;
            }
            else
            {
                byte[] dst = new byte[offset];
                Buffer.BlockCopy(src, 0, dst, 0, offset);
                return dst;
            }
        }
    }
}