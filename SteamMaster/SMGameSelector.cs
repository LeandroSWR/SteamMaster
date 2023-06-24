using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace SteamMaster
{
    public partial class SMGameSelector : Form
    {
        Dictionary<int, GameInfo> _Games;
        List<GameInfo> _FilteredGames;
        ConcurrentQueue<GameInfo> _LogoQueue;
        private readonly List<string> _LogosAttempted;
        private int _SelectedIndex;

        private long _UserID;

        public SMGameSelector(long userID)
        {
            _Games = new Dictionary<int, GameInfo>();
            _FilteredGames = new List<GameInfo>();
            _LogosAttempted = new List<string>();
            _LogoQueue = new ConcurrentQueue<GameInfo>();

            this._UserID = userID;

            InitializeComponent();

            var blank = new Bitmap(this._GameLogoList.ImageSize.Width, this._GameLogoList.ImageSize.Height);
            using (var g = Graphics.FromImage(blank))
            {
                g.Clear(Color.DimGray);
            }

            this._GameLogoList.Images.Add("Blank", blank);

            _LoadGames.RunWorkerAsync();
        }

        private void DownloadGamesList(object sender, DoWorkEventArgs e)
        {
            byte[] bytes;
            using (WebClient webClient = new WebClient())
            {
                bytes = webClient.DownloadData($"https://steamcommunity.com/profiles/{_UserID}/games/?tab=all&xml=1");
            }

            using (MemoryStream stream = new MemoryStream(bytes, false))
            {
                XPathDocument document = new XPathDocument(stream);
                XPathNavigator navigator = document.CreateNavigator();
                var nodes = navigator.Select("/gamesList/games/game");

                // For testing purposes
                _Games.Add(480, new GameInfo(480, "Spacewar"));

                Parallel.ForEach(nodes.Cast<XPathNavigator>(), (node, state) =>
                {
                    int currentID = Convert.ToInt32(node.SelectSingleNode("appID").Value);
                    string currentName = node.SelectSingleNode("name").Value;

                    lock (_Games)
                    {
                        _Games.Add(currentID, new GameInfo(currentID, currentName));
                    }
                });
            }
        }

        private void OnGamesDownloadFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            _TotalTime.Text = $"{DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime()} Finished! Total of {_Games.Count} Games";
            
            RefreshGames();
        }

        private void RefreshGames()
        {
            foreach (GameInfo info in this._Games.Values.OrderBy(gi => gi.Name))
            {
                this._FilteredGames.Add(info);
                this.AddGameToLogoQueue(info);
            }

            this._GamesListView.VirtualListSize = this._FilteredGames.Count;
            if (this._GamesListView.Items.Count > 0)
            {
                this._GamesListView.Items[0].Selected = true;
                this._GamesListView.Select();
            }

            DownloadNextLogo();
        }

        private void AddGameToLogoQueue(GameInfo info)
        {
            int imageIndex = _GameLogoList.Images.IndexOfKey(info.ID.ToString());
            if (imageIndex >= 0)
            {
                info.ImageIndex = imageIndex;
            }
            else if (!_LogosAttempted.Contains(info.ID.ToString()))
            {
                _LogosAttempted.Add(info.ID.ToString());
                _LogoQueue.Enqueue(info);
            }
        }

        private void DownloadNextLogo()
        {
            if (_LogoWorker.IsBusy == true)
            {
                return;
            }

            GameInfo info;
            if (!_LogoQueue.TryDequeue(out info))
            {
                return;
            }

            _LogoWorker.RunWorkerAsync(info);
        }

        private void DownloadLogo(object sender, DoWorkEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                GameInfo info = (GameInfo)e.Argument;
                string logoPath = string.Format(
                    CultureInfo.InvariantCulture,
                    $"https://steamcdn-a.akamaihd.net/steam/apps/{info.ID}/header.jpg");

                LogoInfo logoInfo;

                using (var downloader = new WebClient())
                {
                    try
                    {
                        var data = downloader.DownloadData(new Uri(logoPath));
                        using (var stream = new MemoryStream(data, false))
                        {
                            var bitmap = new Bitmap(stream);
                            logoInfo = new LogoInfo((uint)info.ID, bitmap);
                        }
                    }
                    catch (Exception)
                    {
                        logoInfo = new LogoInfo((uint)info.ID, null);
                    }
                }

                if (logoInfo.Logo != null && this._Games.TryGetValue((int)logoInfo.Id, out var gameInfo))
                {
                    if (_GamesListView.InvokeRequired)
                    {
                        _GamesListView.Invoke((MethodInvoker)delegate ()
                        {
                            this._GamesListView.BeginUpdate();
                            var imageIndex = this._GameLogoList.Images.Count;
                            this._GameLogoList.Images.Add(gameInfo.ID.ToString(), logoInfo.Logo);
                            gameInfo.ImageIndex = imageIndex;
                            this._GamesListView.EndUpdate();
                        });
                    }
                }
            });
        }

        private void OnLogoDownloaded(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DownloadNextLogo();
        }

        private void _GamesListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            var info = this._FilteredGames[e.ItemIndex];
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

            var count = this._Games.Count;
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
                index = this._FilteredGames.FindIndex(0, startIndex - 1, predicate);
            }
            else if (startIndex <= 0)
            {
                // starting from the first item in the list
                index = this._FilteredGames.FindIndex(0, count, predicate);
            }
            else
            {
                index = this._FilteredGames.FindIndex(startIndex, count - startIndex, predicate);
                if (index < 0)
                {
                    index = this._FilteredGames.FindIndex(0, startIndex - 1, predicate);
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
            if (_SelectedIndex < 0 || _SelectedIndex >= this._FilteredGames.Count)
            {
                return;
            }

            var info = _FilteredGames[_SelectedIndex];
            if (info == null)
            {
                return;
            }

            try
            {
                Process.Start("SM.Achievements.exe", $"{info.ID} {info.Name}");
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
        private void OpenChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            _PanelDesktop.Controls.Add(childForm);
            _PanelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            childForm.Close();
            childForm.Dispose();
        }
    }
}
