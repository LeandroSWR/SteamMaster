using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Steamworks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SteamMaster
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool ranFromSteamPath = Application.StartupPath.Contains(
                (string)Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\Software\Valve\Steam", 
                    "InstallPath", 
                    null));

            if (ranFromSteamPath)
            {
                MessageBox.Show(
                    "This tool can't be ran from within the Steam directory.,",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            Steamworks.SteamAPI.Init();

            if (Steamworks.SteamAPI.IsSteamRunning())
            {
                //List<string> achievements = new List<string>();
                //for (uint i = 0; i < SteamUserStats.GetNumAchievements(); i++)
                //{
                //    achievements.Add(SteamUserStats.GetAchievementName(i));
                //    SteamUserStats.ClearAchievement(achievements[(int)i]);
                //}


                //SteamUserStats.SetAchievement(SteamUserStats.GetAchievementName(1));
                //Steamworks.SteamUserStats.ClearAchievement("ACH_WIN_ONE_GAME");
                //Steamworks.SteamUserStats.StoreStats();

                AppId_t appId_T = new AppId_t(480);

                if (SteamApps.BIsSubscribedApp(appId_T))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new SMmain());
                }

            }
            else
            {
                MessageBox.Show(
                    "Steam is not running. Make sure steam is running before opening this tool.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
