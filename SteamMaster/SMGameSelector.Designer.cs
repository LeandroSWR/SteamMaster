
namespace SteamMaster
{
    partial class SMGameSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._GameLogoList = new System.Windows.Forms.ImageList(this.components);
            this._LogoWorker = new System.ComponentModel.BackgroundWorker();
            this._LoadGames = new System.ComponentModel.BackgroundWorker();
            this._TotalTime = new System.Windows.Forms.Label();
            this._GamesListView = new SteamMaster.DoubleBufferedListView();
            this._PanelDesktop = new System.Windows.Forms.Panel();
            this._PanelDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // _GameLogoList
            // 
            this._GameLogoList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this._GameLogoList.ImageSize = new System.Drawing.Size(184, 69);
            this._GameLogoList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // _LogoWorker
            // 
            this._LogoWorker.WorkerSupportsCancellation = true;
            this._LogoWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DownloadLogo);
            this._LogoWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnLogoDownloaded);
            // 
            // _LoadGames
            // 
            this._LoadGames.WorkerSupportsCancellation = true;
            this._LoadGames.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DownloadGamesList);
            this._LoadGames.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnGamesDownloadFinished);
            // 
            // _TotalTime
            // 
            this._TotalTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._TotalTime.AutoSize = true;
            this._TotalTime.BackColor = System.Drawing.Color.White;
            this._TotalTime.Location = new System.Drawing.Point(-3, 437);
            this._TotalTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._TotalTime.Name = "_TotalTime";
            this._TotalTime.Size = new System.Drawing.Size(35, 13);
            this._TotalTime.TabIndex = 4;
            this._TotalTime.Text = "label2";
            // 
            // _GamesListView
            // 
            this._GamesListView.BackColor = System.Drawing.Color.Black;
            this._GamesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._GamesListView.ForeColor = System.Drawing.Color.White;
            this._GamesListView.HideSelection = false;
            this._GamesListView.LargeImageList = this._GameLogoList;
            this._GamesListView.Location = new System.Drawing.Point(0, 0);
            this._GamesListView.Margin = new System.Windows.Forms.Padding(4);
            this._GamesListView.MultiSelect = false;
            this._GamesListView.Name = "_GamesListView";
            this._GamesListView.Size = new System.Drawing.Size(800, 450);
            this._GamesListView.SmallImageList = this._GameLogoList;
            this._GamesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this._GamesListView.TabIndex = 1;
            this._GamesListView.TileSize = new System.Drawing.Size(184, 69);
            this._GamesListView.UseCompatibleStateImageBehavior = false;
            this._GamesListView.VirtualMode = true;
            this._GamesListView.ItemActivate += new System.EventHandler(this.OnGameChosen);
            this._GamesListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnSelectChange);
            this._GamesListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this._GamesListView_RetrieveVirtualItem);
            this._GamesListView.SearchForVirtualItem += new System.Windows.Forms.SearchForVirtualItemEventHandler(this._GamesListView_SearchForVirtualItem);
            // 
            // _PanelDesktop
            // 
            this._PanelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this._PanelDesktop.Controls.Add(this._TotalTime);
            this._PanelDesktop.Controls.Add(this._GamesListView);
            this._PanelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PanelDesktop.Location = new System.Drawing.Point(0, 0);
            this._PanelDesktop.Name = "_PanelDesktop";
            this._PanelDesktop.Size = new System.Drawing.Size(800, 450);
            this._PanelDesktop.TabIndex = 5;
            // 
            // SMGameSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._PanelDesktop);
            this.Name = "SMGameSelector";
            this.Text = "Form1";
            this._PanelDesktop.ResumeLayout(false);
            this._PanelDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferedListView _GamesListView;
        private System.Windows.Forms.ImageList _GameLogoList;
        private System.ComponentModel.BackgroundWorker _LogoWorker;
        private System.ComponentModel.BackgroundWorker _LoadGames;
        private System.Windows.Forms.Label _TotalTime;
        private System.Windows.Forms.Panel _PanelDesktop;
    }
}