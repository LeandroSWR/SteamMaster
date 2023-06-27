using System;
using System.Collections.Generic;
using System.Drawing;
using Steamworks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;

namespace SteamMaster.Achievements
{
    using Pipes;
    using System.IO.Pipes;
    using System.Windows.Markup;

    public partial class SMAchievementHandler : Form
    {
        private ClientPipe client;
        private Dictionary<string, AchievementInfo> achievements;

        public SMAchievementHandler(string appName)
        {
            achievements = new Dictionary<string, AchievementInfo>();

            InitializeComponent();
            this.Text = appName;
        }

        private void SMAchievements_Load(object sender, EventArgs e) 
        {
            _ClientWorker.RunWorkerAsync();
        }

        private void RequestIconInfo()
        {
            // Request logo icons (For some reason the Steam API doesn't return the correct id for the icon on the first request)
            // So we do this first pass to get the correct one next pass
            for (int i = 0; i < SteamUserStats.GetNumAchievements(); i++)
            {
                // So i do a request but i don't save any info i know wont be correct
                SteamUserStats.GetAchievementIcon(SteamUserStats.GetAchievementName((uint)i));
            }
        }

        private void RefreshAchievements()
        {
            // We can't continue while the user stats are not up to date
            SteamUserStats.RequestCurrentStats();
            // Wait's 250ms to make sure we're able to retrieve the stats
            Thread.Sleep(250);

            uint numAchievements = SteamUserStats.GetNumAchievements();

            achievements.Clear();

            string aName;
            int aImageIndex;
            bool aUnlocked;

            // Request logo icons (For some reason the Steam API doesn't return the correct id for the icon on the first request)
            for (uint i = 0; i < numAchievements; i++)
            {
                aName = SteamUserStats.GetAchievementName(i);
                // So i do a request but i don't save any info i know wont be correct
                SteamUserStats.GetAchievementIcon(aName);
            }
            Thread.Sleep(100);

            for (uint i = 0; i < numAchievements; i++)
            {
                aName = SteamUserStats.GetAchievementName(i);
                SteamUserStats.GetAchievement(aName, out aUnlocked);

                // Get the Image Index
                aImageIndex = SteamUserStats.GetAchievementIcon(aName);
                // Create the achievement Info
                AchievementInfo toSend = new AchievementInfo(
                        aName,
                        SteamUserStats.GetAchievementDisplayAttribute(aName, "name"),
                        SteamUserStats.GetAchievementDisplayAttribute(aName, "desc"),
                        GetAchievementImage(aImageIndex),
                        aUnlocked);

                // Add it to the dictionary
                achievements.Add(toSend.Name, toSend);
                // Send the data
                //SendData(toSend);
            }

            SendData(achievements);
            //SendData(PipeRequest.AchievementsLoaded);
        }

        public Image GetAchievementImage(int aImageIndex)
        {
            Image ret = null;
            uint imageWidth;
            uint imageHeight;

            if (SteamUtils.GetImageSize(aImageIndex, out imageWidth, out imageHeight))
            {
                byte[] iBytes = new byte[imageWidth * imageHeight * 4];

                if (SteamUtils.GetImageRGBA(aImageIndex, iBytes, (int)(imageWidth * imageHeight * 4)))
                {
                    using (var bmp = new Bitmap((int)imageWidth, (int)imageHeight, PixelFormat.Format32bppArgb))
                    {
                        Rectangle rectData = new Rectangle(0, 0, bmp.Width, bmp.Height);
                        BitmapData bmpData = bmp.LockBits(rectData, ImageLockMode.WriteOnly, bmp.PixelFormat);
                        IntPtr pNative = bmpData.Scan0;

                        Marshal.Copy(iBytes, 0, pNative, iBytes.Length);

                        bmp.UnlockBits(bmpData);

                        ret = bmp.Clone(rectData, PixelFormat.Format32bppRgb);
                    }
                }
            }

            return ret;
        }

        private void SaveAchievements()
        {
            foreach(AchievementInfo aInfo in achievements.Values)
            {
                if (aInfo.CurrentUnlockState != aInfo.UnlockState)
                {
                    if (aInfo.UnlockState)
                    {
                        SteamUserStats.SetAchievement(aInfo.ID);
                    }
                    else
                    {
                        SteamUserStats.ClearAchievement(aInfo.ID);
                    }

                    aInfo.SetCurrentUnlockState();
                    SteamUserStats.StoreStats();

                    // Magic number so all achievements pop up on the side with no bugs
                    Thread.Sleep(250);
                }
            }
        }

        private void UnlockAll()
        {
            foreach(AchievementInfo aInfo in achievements.Values)
            {
                SteamUserStats.SetAchievement(aInfo.ID);
                SteamUserStats.StoreStats();
            }
        }

        private void LockAll()
        {
            foreach (AchievementInfo aInfo in achievements.Values)
            {
                SteamUserStats.ClearAchievement(aInfo.ID);
            }
            SteamUserStats.StoreStats();
        }

        private void SendData<T>(T data)
        {
            label1.Text = data.ToString();
            client.WriteBytes(PipeDataHandler.SerializeToBytes<T>(data));
        }

        private void _ClientWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                client = new ClientPipe(".", "SteamMasterSV", p => p.StartByteReaderAsync());
                client.DataReceived += (sndr, args) => this.BeginInvoke((Action)(() =>
                RecieveData(sndr, args)));

                client.Connect();
                label1.Text = "Connected";

                RequestIconInfo();
                RefreshAchievements();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    "Error!" + ex.Message,
                    "Error:",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                // Connection failed
            }
        }

        /// <summary>
        /// We can recieve to types of data AchievementInfo or Image
        /// </summary>
        private void RecieveData(object sender, PipeEventArgs args)
        {
            AchievementInfo aInfo;
            PipeRequest request;

            try
            {
                if (PipeDataHandler.DeserializeFromBytes(args.Data, out aInfo))
                {
                    // Update the unlockstat for the recieved achievement
                    lock (achievements)
                    {
                        achievements[aInfo.Name].UnlockState = aInfo.UnlockState;
                    }
                }
                else if (PipeDataHandler.DeserializeFromBytes(args.Data, out request))
                {
                    switch (request)
                    {
                        case PipeRequest.RefreshAchievements:
                            RefreshAchievements();
                            break;
                        case PipeRequest.SaveAchievements:
                            SaveAchievements();
                            break;
                        case PipeRequest.LockAll:
                            LockAll();
                            break;
                        case PipeRequest.UnlockAll:
                            UnlockAll();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    "Error!" + ex.Message,
                    "Error:",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                // Connection failed
            }
            
        }
    }
}
