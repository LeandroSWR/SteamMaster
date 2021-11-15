using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace SteamMaster
{
    static class Program
    {
        static readonly long Steam64IDIdentifier = 0x0110000100000000;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            long steamID64 = 0;
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

            try
            {
                long steamID3 = Convert.ToInt64(
                    Registry.GetValue(
                        @"HKEY_CURRENT_USER\Software\Valve\Steam\ActiveProcess", 
                        "ActiveUser", 
                        0));

                steamID64 = steamID3 + Steam64IDIdentifier;
            }
            catch
            {
                MessageBox.Show(
                    "Steam is not installed. Make you have steam installed and it's running before opening this tool.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            if (steamID64 != Steam64IDIdentifier)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SMmain(steamID64));
            }
            else
            {
                MessageBox.Show(
                    "Steam is not running. Make sure steam is running before opening this tool.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            

            //Environment.SetEnvironmentVariable("SteamAppID", "480");
            //Steamworks.SteamAPI.Init();


            //List<string> achievements = new List<string>();
            //for (uint i = 0; i < SteamUserStats.GetNumAchievements(); i++)
            //{
            //    achievements.Add(SteamUserStats.GetAchievementName(i));
            //    SteamUserStats.SetAchievement(SteamUserStats.GetAchievementName(i));
            //    //SteamUserStats.ClearAchievement(achievements[(int)i]);
            //}
            //Steamworks.SteamUserStats.StoreStats();

            //SteamUserStats.SetAchievement(SteamUserStats.GetAchievementName(1));
            //Steamworks.SteamUserStats.ClearAchievement("ACH_WIN_ONE_GAME");
            //Steamworks.SteamUserStats.StoreStats();


        }
    }
}
