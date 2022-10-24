namespace SteamMaster.Pipes
{
    public class PipeEventArgs
    {
        public byte[] Data { get; protected set; }
        public int Len { get; protected set; }
        public string String { get; protected set; }

        public PipeEventArgs(string str)
        {
            String = str;
        }

        public PipeEventArgs(byte[] data, int len)
        {
            Data = data;
            Len = len;
        }
    }
}
