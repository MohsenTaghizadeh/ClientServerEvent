namespace ClientSocket
{
    internal class NetworkBuffer
    {
        internal byte[] WriteBuffer;

        public byte[] ReadBuffer { get; internal set; }
        public int CurrentWriteByteCount { get; internal set; }
    }
}