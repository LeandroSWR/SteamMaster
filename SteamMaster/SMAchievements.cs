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
    public partial class SMAchievements : Form
    {
        private Dictionary<string, AchievementInfo> achievements;

        public SMAchievements(string appName)
        {
            achievements = new Dictionary<string, AchievementInfo>();

            InitializeComponent();
            this.Text = appName;
        }

        private void SMAchievements_Load(object sender, EventArgs e)
        {
            RequestIconInfo();
            RefreshAchievements();
        }

        private void RequestIconInfo()
        {
            // Request logo icons (For some reason the Steam API doesn't return the correct id for the icon on the first request)
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

            ListItem[] listItems = new ListItem[SteamUserStats.GetNumAchievements()];

            achievements.Clear();
            flowLayoutPanel1.Controls.Clear();

            string aName;
            int aImageIndex;
            bool aUnlocked;

            // Request logo icons (For some reason the Steam API doesn't return the correct id for the icon on the first request)
            for (int i = 0; i < listItems.Length; i++)
            {
                aName = SteamUserStats.GetAchievementName((uint)i);
                // So i do a request but i don't save any info i know wont be correct
                SteamUserStats.GetAchievementIcon(aName);
            }
            Thread.Sleep(100);

            for (int i = 0; i < listItems.Length; i++)
            {
                aName = SteamUserStats.GetAchievementName((uint)i);
                SteamUserStats.GetAchievement(aName, out aUnlocked);

                listItems[i] = new ListItem();
                listItems[i].AchievementUnlocked = aUnlocked;
                listItems[i].AchievementName = SteamUserStats.GetAchievementDisplayAttribute(aName, "name");
                listItems[i].AchievementDesc = SteamUserStats.GetAchievementDisplayAttribute(aName, "desc");
                aImageIndex = SteamUserStats.GetAchievementIcon(aName);
                listItems[i].AchievementImg = GetAchievementImage(aImageIndex);
                listItems[i].BackColor = Color.Black;

                achievements.Add(listItems[i].AchievementName, new AchievementInfo(aName, aUnlocked));

                listItems[i].Achievements = achievements;

                flowLayoutPanel1.Controls.Add(listItems[i]);
            }

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

        private void OnSaveValues(object sender, EventArgs e)
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

                    SteamUserStats.StoreStats();

                    // Magic number so all achievements pop up on the side with no bugs
                    Thread.Sleep(250);
                }
            }

            RefreshAchievements();
        }

        private void UnlockAll(object sender, EventArgs e)
        {
            foreach(AchievementInfo aInfo in achievements.Values)
            {
                SteamUserStats.SetAchievement(aInfo.ID);
                SteamUserStats.StoreStats();
            }
        }

        private void LockAll(object sender, EventArgs e)
        {
            foreach (AchievementInfo aInfo in achievements.Values)
            {
                SteamUserStats.ClearAchievement(aInfo.ID);
            }
            SteamUserStats.StoreStats();
        }
    }
}
