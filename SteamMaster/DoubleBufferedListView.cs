using System.Windows.Forms;

namespace SteamMaster
{
    internal class DoubleBufferedListView : ListView
    {
        public DoubleBufferedListView()
        {
            base.DoubleBuffered = true;
        }
    }
}
