using System;
using JackBuffer;

namespace SJSJ.Protocol
{
    [JackMessageObject]
    public struct ConnectResMessage : IJackMessage<ConnectResMessage>
    {
        public string token;
        public int connID;
        public byte status;
        public void WriteTo(byte[] dst, ref int offset)
        {
            BufferWriter.WriteUTF8String(dst, token, ref offset);
            BufferWriter.WriteInt32(dst, connID, ref offset);
            BufferWriter.WriteUInt8(dst, status, ref offset);
        }

        public void FromBytes(byte[] src, ref int offset)
        {
            token = BufferReader.ReadUTF8String(src, ref offset);
            connID = BufferReader.ReadInt32(src, ref offset);
            status = BufferReader.ReadUInt8(src, ref offset);
        }

        public int GetEvaluatedSize(out bool isCertain)
        {
            int count = 7;
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