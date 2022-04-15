using JackBuffer;
using System;

namespace SJSJ.Protocol
{
    [JackMessageObject]
    public struct TestResMessage : IJackMessage<TestResMessage>
    {
        public byte status;
        public void WriteTo(byte[] dst, ref int offset)
        {
            BufferWriter.WriteUInt8(dst, status, ref offset);
        }

        public void FromBytes(byte[] src, ref int offset)
        {
            status = BufferReader.ReadUInt8(src, ref offset);
        }

        public int GetEvaluatedSize(out bool isCertain)
        {
            int count = 1;
            isCertain = true;
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