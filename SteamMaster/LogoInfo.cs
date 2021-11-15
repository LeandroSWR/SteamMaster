using System.Drawing;

namespace SteamMaster
{
    class LogoInfo
    {
        public uint Id { get; }
        public Bitmap Logo { get; }

        public LogoInfo(uint id, Bitmap bitmap)
        {
            Id = id;
            Logo = bitmap;
        }
    }
}
