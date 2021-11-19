namespace SM.Achievements
{
    public class AchievementInfo
    {
        public string ID { get; }
        public bool UnlockState { get; set; }
        public bool CurrentUnlockState { get; }

        public AchievementInfo(string id, bool currentState)
        {
            ID = id;
            CurrentUnlockState = currentState;
            UnlockState = currentState;
        }
    }
}