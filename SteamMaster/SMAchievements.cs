using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace SteamMaster
{
    using Achievements;
    using Pipes;

    public partial class SMAchievements : Form
    {
        private ServerPipe server;
        private Dictionary<string, AchievementInfo> achievements;
        private GameInfo gameInfo;

        public SMAchievements(GameInfo info)
        {
            achievements = new Dictionary<string, AchievementInfo>();
            gameInfo = info;

            InitializeComponent();
            this.Text = info.Name;
            _ServerWorker.RunWorkerAsync();
        }

        private void SMAchievements_Load(object sender, EventArgs e) 
        {
            try
            {
                Process.Start("SteamMaster.Achievements.exe", $"{gameInfo.ID} {gameInfo.Name}");
            }
            catch (Win32Exception)
            {
                MessageBox.Show(
                    this,
                    "Error!",
                    "Failed to start SteamMaster.Achievements.exe.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void RefreshAchievements()
        {
            ListItem[] listItems = new ListItem[achievements.Count];

            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem();
                listItems[i].AchievementUnlocked = achievements.Values.ElementAt(i).UnlockState;
                listItems[i].AchievementName = achievements.Values.ElementAt(i).Name;
                listItems[i].AchievementDesc = achievements.Values.ElementAt(i).Description;
                listItems[i].AchievementImg = achievements.Values.ElementAt(i).Icon;
                listItems[i].BackColor = Color.Black;

                int index = i;
                listItems[index]._AchievementUnlocked.CheckedChanged += (sender, e) => this.BeginInvoke((Action)(() => 
                {
                    achievements.Values.ElementAt(index).UnlockState = listItems[index]._AchievementUnlocked.Checked;
                    SendData(achievements.Values.ElementAt(index));
                }));
                
                flowLayoutPanel1.Controls.Add(listItems[i]);
            }
        }

        private void OnSaveValues(object sender, EventArgs e)
        {
            SendData(PipeRequest.SaveAchievements);
        }

        private void UnlockAll(object sender, EventArgs e)
        {
            SendData(PipeRequest.UnlockAll);

            foreach (AchievementInfo aInfo in achievements.Values)
            {
                aInfo.UnlockState = true;
            }

            RefreshAchievements();
        }

        private void LockAll(object sender, EventArgs e)
        {
            SendData(PipeRequest.LockAll);

            foreach (AchievementInfo aInfo in achievements.Values)
            {
                aInfo.UnlockState = false;
            }

            RefreshAchievements();
        }

        private void SendData<T>(T data)
        {
            server.WriteBytes(PipeDataHandler.SerializeToBytes(data));
        }
        
        private void _ServerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            server = new ServerPipe("SteamMasterSV", p => p.StartByteReaderAsync());

            server.DataReceived += (sndr, args) => this.BeginInvoke((Action)(() =>
                RecieveData(sndr, args)));
        }

        /// <summary>
        /// We can recieve to types of data AchievementInfo or Image
        /// </summary>
        private void RecieveData(object sender, PipeEventArgs args)
        {
            AchievementInfo aInfo;
            PipeRequest request;

            if (PipeDataHandler.DeserializeFromBytes(args.Data, out aInfo))
            {
                lock (achievements)
                {
                    achievements.Add(aInfo.Name, aInfo);
                }
                
            }
            else if (PipeDataHandler.DeserializeFromBytes(args.Data, out request))
            {
                switch (request)
                {
                    case PipeRequest.AchievementsLoaded:
                        RefreshAchievements();
                        break;
                    case PipeRequest.RefreshAchievements:
                        RefreshAchievements();
                        break;
                }
            }
        }
    }
}
