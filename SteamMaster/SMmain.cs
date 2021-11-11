using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Steamworks;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Concurrent;

namespace SteamMaster
{
    public struct stats
    {
        public int i;
        public int id;
        public Thread thread;

        public stats(int i, int id, Thread thread)
        {
            this.i = i;
            this.id = id;
            this.thread = thread;
        }
    }

    public partial class SMmain : Form
    {
        Dictionary<int, string> games = new Dictionary<int, string>();
        List<Thread> threads = new List<Thread>();
        JToken token;

        object safe = new object();

        public SMmain()
        {
            InitializeComponent();

            //lblOutput.Text = SteamUserStats.GetAchievementDisplayAttribute(SteamUserStats.GetAchievementName(1), "name");
            //lblOutput.Text += " "  + SteamUserStats.GetAchievementDisplayAttribute(SteamUserStats.GetAchievementName(1), "desc");

            lblTests.Text = "";

            _LoadGames.RunWorkerAsync();
        }

        private void AddToDictionary(object values)
        {
            using (WebClient client = new WebClient())
            {
                 try
                 {
                    if (client.DownloadString($"https://api.steampowered.com/ISteamUserStats/GetGlobalAchievementPercentagesForApp/v2/?gameid={((stats)values).id}") != "")
                    {
                        games.Add(((stats)values).id, (string)token[((stats)values).i].SelectToken("name"));
                        lock(safe)
                        {
                            _LoadGames.ReportProgress(((stats)values).id);
                        }
                        
                        ((stats)values).thread.Join();
                    }
                 }
                 catch {
                    ((stats)values).thread.Join();
                 }
                ((stats)values).thread.Join();
            }
            ((stats)values).thread.Join();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (WebClient webClient = new WebClient())
            {
                string json = webClient.DownloadString("https://api.steampowered.com/ISteamApps/GetAppList/v2/");

                token = JObject.Parse(json).SelectToken("applist.apps");

                for (int i = 0; i < token.Count(); i++)
                {
                    int currentID = (int)token[i].SelectToken("appid");

                    if (!games.ContainsKey(currentID) &&
                        SteamApps.BIsSubscribedApp(new AppId_t((uint)currentID)))
                    {
                        threads.Add(new Thread(new ParameterizedThreadStart(AddToDictionary)));
                        threads[threads.Count - 1].Start(new stats(i, currentID, threads[threads.Count - 1]));
                    }
                }
            }

            bool joined = false;

            do
            {
                for (int i = 0; i < threads.Count - 1; i++)
                {
                    if (threads[i].ThreadState != ThreadState.WaitSleepJoin)
                    {
                        joined = false;
                        break;
                    }
                    else
                    {
                        joined = true;
                    }
                }
            } while (!joined);
        }

        private void _LoadGames_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblTests.Text += games[e.ProgressPercentage] + ":" + e.ProgressPercentage + ", ";
        }

        private void _LoadGames_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
