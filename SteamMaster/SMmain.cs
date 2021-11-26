using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Xml.XPath;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Globalization;

namespace SteamMaster
{
    public partial class SMmain : Form
    {
        Dictionary<int, GameInfo> games;
        List<GameInfo> filteredGames;
        ConcurrentQueue<GameInfo> logoQueue;
        private readonly List<string> _LogosAttempted;
        private int _SelectedIndex;

        private long userID;

        public SMmain(long userID)
        {
            games = new Dictionary<int, GameInfo>();
            filteredGames = new List<GameInfo>();
            _LogosAttempted = new List<string>();
            logoQueue = new ConcurrentQueue<GameInfo>();

            this.userID = userID;

            InitializeComponent();

            var blank = new Bitmap(this._GameLogoList.ImageSize.Width, this._GameLogoList.ImageSize.Height);
            using (var g = Graphics.FromImage(blank))
            {
                g.Clear(Color.DimGray);
            }

            this._GameLogoList.Images.Add("Blank", blank);

            _LoadGames.RunWorkerAsync();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void DownloadGamesList(object sender, DoWorkEventArgs e)
        {
            byte[] bytes;
            using (WebClient webClient = new WebClient())
            {
                bytes = webClient.DownloadData($"https://steamcommunity.com/profiles/{userID}/games/?tab=all&xml=1");
            }

            using (MemoryStream stream = new MemoryStream(bytes, false))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                var nodes = navigator.Select("/gamesList/games/game");

                // For testing purposes
                games.Add(480, new GameInfo(480, "Spacewar"));

                while (nodes.MoveNext())
                {
                    int currentID = Convert.ToInt32(nodes.Current.SelectSingleNode("appID").Value);

                    games.Add(currentID, new GameInfo(currentID, nodes.Current.SelectSingleNode("name").Value));
                }
            }
        }

        private void OnGamesDownloadFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            _TotalTime.Text = $"{DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime()} Finished! Total of {games.Count} Games";
            RefreshGames();
            DownloadNextLogo();
        }

        private void RefreshGames()
        {
            foreach (GameInfo info in this.games.Values.OrderBy(gi => gi.Name))
            {
                this.filteredGames.Add(info);
                this.AddGameToLogoQueue(info);
            }

            this._GamesListView.VirtualListSize = this.filteredGames.Count;
            if (this._GamesListView.Items.Count > 0)
            {
                this._GamesListView.Items[0].Selected = true;
                this._GamesListView.Select();
            }
        }

        private void AddGameToLogoQueue(GameInfo info)
        {
            // Checks if the current game has a logo
            using (WebClient client = new WebClient())
            {
                try
                {
                    var data = client.DownloadData($"https://steamcdn-a.akamaihd.net/steam/apps/{info.ID}/header.jpg");
                }
                catch
                {
                    return;
                }
            }

            int imageIndex = _GameLogoList.Images.IndexOfKey(info.ID.ToString());
            if (imageIndex >= 0)
            {
                info.ImageIndex = imageIndex;
            }
            else if (!_LogosAttempted.Contains(info.ID.ToString()))
            {
                _LogosAttempted.Add(info.ID.ToString());
                logoQueue.Enqueue(info);
            }
        }

        private void DownloadNextLogo()
        {
            if (_LogoWorker.IsBusy == true)
            {
                return;
            }

            GameInfo info;
            if (!logoQueue.TryDequeue(out info))
            {
                return;
            }

            _LogoWorker.RunWorkerAsync(info);
        }

        private void DownloadLogo(object sender, DoWorkEventArgs e)
        {
            var info = (GameInfo)e.Argument;
            var logoPath = string.Format(
                CultureInfo.InvariantCulture,
                $"https://steamcdn-a.akamaihd.net/steam/apps/{info.ID}/header.jpg");
            using (var downloader = new WebClient())
            {
                try
                {
                    var data = downloader.DownloadData(new Uri(logoPath));
                    using (var stream = new MemoryStream(data, false))
                    {
                        var bitmap = new Bitmap(stream);
                        e.Result = new LogoInfo((uint)info.ID, bitmap);
                    }
                }
                catch (Exception)
                {
                    e.Result = new LogoInfo((uint)info.ID, null);
                }
            }
        }

        private void OnLogoDownloaded(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null || e.Cancelled == true)
            {
                return;
            }

            var logoInfo = (LogoInfo)e.Result;
            if (logoInfo.Logo != null && this.games.TryGetValue((int)logoInfo.Id, out var gameInfo))
            {
                this._GamesListView.BeginUpdate();
                var imageIndex = this._GameLogoList.Images.Count;
                this._GameLogoList.Images.Add(gameInfo.ID.ToString(), logoInfo.Logo);
                gameInfo.ImageIndex = imageIndex;
                this._GamesListView.EndUpdate();
            }

            this.DownloadNextLogo();
        }

        private void _GamesListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            var info = this.filteredGames[e.ItemIndex];
            e.Item = new ListViewItem()
            {
                Text = info.Name,
                ImageIndex = info.ImageIndex,
            };
        }

        private void _GamesListView_SearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
        {
            if (e.Direction != SearchDirectionHint.Down || e.IsTextSearch == false)
            {
                return;
            }

            var count = this.games.Count;
            if (count < 2)
            {
                return;
            }

            var text = e.Text;
            int startIndex = e.StartIndex;

            Predicate<GameInfo> predicate = gi => 
                gi.Name != null && gi.Name.StartsWith(text, StringComparison.CurrentCultureIgnoreCase);

            int index;
            if (e.StartIndex >= count)
            {
                // starting from the last item in the list
                index = this.filteredGames.FindIndex(0, startIndex - 1, predicate);
            }
            else if (startIndex <= 0)
            {
                // starting from the first item in the list
                index = this.filteredGames.FindIndex(0, count, predicate);
            }
            else
            {
                index = this.filteredGames.FindIndex(startIndex, count - startIndex, predicate);
                if (index < 0)
                {
                    index = this.filteredGames.FindIndex(0, startIndex - 1, predicate);
                }
            }

            e.Index = index < 0 ? -1 : index;
        }

        private void OnSelectChange(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            _SelectedIndex = e.ItemIndex;
        }

        private void OnGameChosen(object sender, EventArgs e)
        {
            if (_SelectedIndex < 0 || _SelectedIndex >= this.filteredGames.Count)
            {
                return;
            }

            var info = filteredGames[_SelectedIndex];
            if (info == null)
            {
                return;
            }

            try
            {
                Process.Start("SM.Achievements.exe", info.ID.ToString(CultureInfo.InvariantCulture));
            }
            catch (Win32Exception)
            {
                MessageBox.Show(
                    this,
                    "Failed to start SM.Achievements.exe.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
