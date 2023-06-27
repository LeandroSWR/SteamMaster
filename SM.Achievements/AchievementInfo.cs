using System;
using System.Drawing;

namespace SteamMaster.Achievements
{
    [Serializable]
    public class AchievementInfo
    {
        public string ID { get; }
        public string Name { get; }
        public string Description { get; }
        public Image Icon { get; }
        public bool UnlockState { get; set; }
        public bool CurrentUnlockState { get; private set; }

        public AchievementInfo(string id, string name, string description, Image icon, bool currentState)
        {
            ID = id;
            Name = name;
            Description = description;
            Icon = icon;
            CurrentUnlockState = currentState;
            UnlockState = currentState;
        }

        public void SetCurrentUnlockState()
        {
            CurrentUnlockState = UnlockState;
        }
    }
}