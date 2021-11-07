using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SMmain());
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
