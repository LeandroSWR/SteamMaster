using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SteamMaster.Achievements
{
    public partial class ListItem : UserControl
    {
        public Dictionary<string, AchievementInfo> Achievements { get; set; }

        private string achievementName;
        private string achievementDesc;
        private Image achievementImg;
        private int achievementIndex;

        [Category("Custom Props")]
        public bool AchievementUnlocked
        {
            get => _AchievementUnlocked.Checked;
            set
            {
                _AchievementUnlocked.Checked = value;
            }
        }

        [Category("Custom Props")]
        public string AchievementName
        {
            get => achievementName;
            set
            {
                achievementName = value;
                _AchievementName.Text = value;
            }
        }

        [Category("Custom Props")]
        public string AchievementDesc
        {
            get => achievementDesc;
            set
            {
                achievementDesc = value;
                _AchievementDesc.Text = value;
            }
        }

        [Category("Custom Props")]
        public Image AchievementImg
        {
            get => achievementImg;
            set
            {
                achievementImg = value;
                _AchievementImg.Image = value;
            }
        }

        [Category("Custom Props")]
        public int AchievementIndex
        {
            get => achievementIndex;
            set=> achievementIndex = value;
        }

        public ListItem()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, System.EventArgs e)
        {
            if (Achievements != null)
            {
                Achievements[achievementName].UnlockState = _AchievementUnlocked.Checked;
            }
        }
    }
}
