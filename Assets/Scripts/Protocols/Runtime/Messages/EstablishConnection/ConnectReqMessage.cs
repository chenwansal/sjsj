using JackBuffer;
using System;

namespace SJSJ.Protocol
{
    [JackMessageObject]
    public struct ConnectReqMessage : IJackMessage<ConnectReqMessage>
    {
        public string token;
        public void WriteTo(byte[] dst, ref int offset)
        {
            BufferWriter.WriteUTF8String(dst, token, ref offset);
        }

        public void FromBytes(byte[] src, ref int offset)
        {
            token = BufferReader.ReadUTF8String(src, ref offset);
        }

        public int GetEvaluatedSize(out bool isCertain)
        {
            int count = 2;
            isCertain = false;
            if (token != null)
            {
                count += token.Length * 4;
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