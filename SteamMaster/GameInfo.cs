using System.Drawing;

namespace SteamMaster
{
    class GameInfo
    {
        public string Name { get; }
        public int ID { get; }
        public int ImageIndex { get; set; }

        public GameInfo(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
