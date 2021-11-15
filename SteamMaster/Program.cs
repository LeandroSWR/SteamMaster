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
        // Do not edit! This is a constant value of the Steam64ID Identifier
        // Provided by valve on https://developer.valvesoftware.com/wiki/SteamID
        const long Steam64IDIdentifier = 0x0110000100000000;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            long steamID64 = 0;
            
            // Checks if the app is being launched from within the steam path
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

            // Try to convert the SteamID3 to SteamID64
            try
            {
                long steamID3 = Convert.ToInt64(
                    Registry.GetValue(
                        @"HKEY_CURRENT_USER\Software\Valve\Steam\ActiveProcess", 
                        "ActiveUser", 
                        0));
                // To convert we just need to add the Identifier to the existing SteamID3
                steamID64 = steamID3 + Steam64IDIdentifier;
            }
            catch
            {
                // If we failed to get the SteamID3 it means Steam is not installed on this machine
                MessageBox.Show(
                    "Steam is not installed. Make you have steam installed and it's running before opening this tool.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Check if the SteamID3 we got wasn't 0
            if (steamID64 != Steam64IDIdentifier)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SMmain(steamID64));
            }
            else
            {
                // It was 0 if Steam was not running
                // We can use this to make sure steam is running when starting the tool
                MessageBox.Show(
                    "Steam is not running. Make sure steam is running before opening this tool.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
