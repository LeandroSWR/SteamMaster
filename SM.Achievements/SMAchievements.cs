using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steamworks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace SM.Achievements
{
    public partial class SMAchievements : Form
    {
        public SMAchievements()
        {
            InitializeComponent();
        }

        private void SMAchievements_Load(object sender, EventArgs e)
        {
            populateItems();
        }

        private void populateItems()
        {
            ListItem[] listItems = new ListItem[SteamUserStats.GetNumAchievements()];

            flowLayoutPanel1.Controls.Clear();

            string aName;
            int aImageIndex;

            for (int i = 0; i < listItems.Length; i++)
            {
                aName = SteamUserStats.GetAchievementName((uint)i);
                aImageIndex = SteamUserStats.GetAchievementIcon(aName);

                listItems[i] = new ListItem();
                listItems[i].AchievementName = SteamUserStats.GetAchievementDisplayAttribute(aName, "name");
                listItems[i].AchievementDesc = SteamUserStats.GetAchievementDisplayAttribute(aName, "desc");
                listItems[i].AchievementImg = GetAchievementImage(aImageIndex);

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
    }
}
