using System;

namespace SteamMaster.Pipes
{
    [Serializable]
    public enum PipeRequest
    {
        None,
        AchievementsLoaded,
        RefreshAchievements,
        SaveAchievements,
        LockAll,
        UnlockAll
    }
}
