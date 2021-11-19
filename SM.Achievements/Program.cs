using System;
using System.Diagnostics;
using System.Windows.Forms;
using Steamworks;

namespace SM.Achievements
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            long appID;

            if (args.Length == 0)
            {
                Process.Start("SteamMaster.exe");
                return;
            }

            if (!long.TryParse(args[0], out appID))
            {
                MessageBox.Show(
                    "Application ID is invalid.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Environment.SetEnvironmentVariable("SteamAppID", $"{appID}");
            SteamAPI.Init();

            if (SteamAPI.IsSteamRunning())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SMAchievements());
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