
namespace SteamMaster
{
    partial class SMBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMBase));
            this._PanelSideMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._BttIdle = new FontAwesome.Sharp.IconButton();
            this._BttSelectGame = new FontAwesome.Sharp.IconButton();
            this._BttMain = new FontAwesome.Sharp.IconButton();
            this._PanelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._PanelTitleBar = new System.Windows.Forms.Panel();
            this._BttMinimize = new FontAwesome.Sharp.IconButton();
            this._BttMaximize = new FontAwesome.Sharp.IconButton();
            this._BttClose = new FontAwesome.Sharp.IconButton();
            this._NameCurrentTab = new System.Windows.Forms.Label();
            this._IconCurrentTab = new FontAwesome.Sharp.IconPictureBox();
            this._PanelDesktop = new System.Windows.Forms.Panel();
            this._PanelSideMenu.SuspendLayout();
            this._PanelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this._PanelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._IconCurrentTab)).BeginInit();
            this.SuspendLayout();
            // 
            // _PanelSideMenu
            // 
            this._PanelSideMenu.AutoScroll = true;
            this._PanelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this._PanelSideMenu.Controls.Add(this.label1);
            this._PanelSideMenu.Controls.Add(this._BttIdle);
            this._PanelSideMenu.Controls.Add(this._BttSelectGame);
            this._PanelSideMenu.Controls.Add(this._BttMain);
            this._PanelSideMenu.Controls.Add(this._PanelLogo);
            this._PanelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this._PanelSideMenu.Location = new System.Drawing.Point(0, 0);
            this._PanelSideMenu.Margin = new System.Windows.Forms.Padding(4);
            this._PanelSideMenu.Name = "_PanelSideMenu";
            this._PanelSideMenu.Size = new System.Drawing.Size(246, 752);
            this._PanelSideMenu.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 726);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Version 0.1.2";
            // 
            // _BttIdle
            // 
            this._BttIdle.Dock = System.Windows.Forms.DockStyle.Top;
            this._BttIdle.FlatAppearance.BorderSize = 0;
            this._BttIdle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this._BttIdle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this._BttIdle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._BttIdle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BttIdle.ForeColor = System.Drawing.Color.Gainsboro;
            this._BttIdle.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this._BttIdle.IconColor = System.Drawing.Color.Gainsboro;
            this._BttIdle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._BttIdle.IconSize = 32;
            this._BttIdle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BttIdle.Location = new System.Drawing.Point(0, 244);
            this._BttIdle.Name = "_BttIdle";
            this._BttIdle.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this._BttIdle.Size = new System.Drawing.Size(246, 60);
            this._BttIdle.TabIndex = 3;
            this._BttIdle.Text = "Idler";
            this._BttIdle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BttIdle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._BttIdle.UseVisualStyleBackColor = true;
            this._BttIdle.Click += new System.EventHandler(this._BttIdle_Click);
            // 
            // _BttSelectGame
            // 
            this._BttSelectGame.Dock = System.Windows.Forms.DockStyle.Top;
            this._BttSelectGame.FlatAppearance.BorderSize = 0;
            this._BttSelectGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this._BttSelectGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this._BttSelectGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._BttSelectGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BttSelectGame.ForeColor = System.Drawing.Color.Gainsboro;
            this._BttSelectGame.IconChar = FontAwesome.Sharp.IconChar.Steam;
            this._BttSelectGame.IconColor = System.Drawing.Color.Gainsboro;
            this._BttSelectGame.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._BttSelectGame.IconSize = 32;
            this._BttSelectGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BttSelectGame.Location = new System.Drawing.Point(0, 184);
            this._BttSelectGame.Name = "_BttSelectGame";
            this._BttSelectGame.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this._BttSelectGame.Size = new System.Drawing.Size(246, 60);
            this._BttSelectGame.TabIndex = 2;
            this._BttSelectGame.Text = "Select Game";
            this._BttSelectGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BttSelectGame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._BttSelectGame.UseVisualStyleBackColor = true;
            this._BttSelectGame.Click += new System.EventHandler(this._BttSelectGame_Click);
            // 
            // _BttMain
            // 
            this._BttMain.Dock = System.Windows.Forms.DockStyle.Top;
            this._BttMain.FlatAppearance.BorderSize = 0;
            this._BttMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this._BttMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this._BttMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._BttMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BttMain.ForeColor = System.Drawing.Color.Gainsboro;
            this._BttMain.IconChar = FontAwesome.Sharp.IconChar.Home;
            this._BttMain.IconColor = System.Drawing.Color.Gainsboro;
            this._BttMain.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._BttMain.IconSize = 32;
            this._BttMain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BttMain.Location = new System.Drawing.Point(0, 124);
            this._BttMain.Name = "_BttMain";
            this._BttMain.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this._BttMain.Size = new System.Drawing.Size(246, 60);
            this._BttMain.TabIndex = 1;
            this._BttMain.Text = "Main";
            this._BttMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BttMain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._BttMain.UseVisualStyleBackColor = true;
            this._BttMain.Click += new System.EventHandler(this._BttMain_Click);
            // 
            // _PanelLogo
            // 
            this._PanelLogo.Controls.Add(this.pictureBox1);
            this._PanelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this._PanelLogo.Location = new System.Drawing.Point(0, 0);
            this._PanelLogo.Margin = new System.Windows.Forms.Padding(4);
            this._PanelLogo.Name = "_PanelLogo";
            this._PanelLogo.Size = new System.Drawing.Size(246, 124);
            this._PanelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SteamMaster.Properties.Resources.SM_IconText;
            this.pictureBox1.Location = new System.Drawing.Point(12, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(218, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // _PanelTitleBar
            // 
            this._PanelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this._PanelTitleBar.Controls.Add(this._BttMinimize);
            this._PanelTitleBar.Controls.Add(this._BttMaximize);
            this._PanelTitleBar.Controls.Add(this._BttClose);
            this._PanelTitleBar.Controls.Add(this._NameCurrentTab);
            this._PanelTitleBar.Controls.Add(this._IconCurrentTab);
            this._PanelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this._PanelTitleBar.Location = new System.Drawing.Point(246, 0);
            this._PanelTitleBar.Name = "_PanelTitleBar";
            this._PanelTitleBar.Size = new System.Drawing.Size(1253, 54);
            this._PanelTitleBar.TabIndex = 5;
            this._PanelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this._PanelTitleBar_MouseDown);
            // 
            // _BttMinimize
            // 
            this._BttMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._BttMinimize.FlatAppearance.BorderSize = 0;
            this._BttMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this._BttMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this._BttMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._BttMinimize.ForeColor = System.Drawing.Color.Gainsboro;
            this._BttMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this._BttMinimize.IconColor = System.Drawing.Color.Gainsboro;
            this._BttMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._BttMinimize.IconSize = 30;
            this._BttMinimize.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._BttMinimize.Location = new System.Drawing.Point(1139, 12);
            this._BttMinimize.Name = "_BttMinimize";
            this._BttMinimize.Size = new System.Drawing.Size(30, 30);
            this._BttMinimize.TabIndex = 4;
            this._BttMinimize.UseVisualStyleBackColor = true;
            this._BttMinimize.Click += new System.EventHandler(this._BttMinimize_Click);
            // 
            // _BttMaximize
            // 
            this._BttMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._BttMaximize.FlatAppearance.BorderSize = 0;
            this._BttMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this._BttMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this._BttMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._BttMaximize.ForeColor = System.Drawing.Color.Gainsboro;
            this._BttMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this._BttMaximize.IconColor = System.Drawing.Color.Gainsboro;
            this._BttMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._BttMaximize.IconSize = 30;
            this._BttMaximize.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._BttMaximize.Location = new System.Drawing.Point(1175, 12);
            this._BttMaximize.Name = "_BttMaximize";
            this._BttMaximize.Size = new System.Drawing.Size(30, 30);
            this._BttMaximize.TabIndex = 3;
            this._BttMaximize.UseVisualStyleBackColor = true;
            this._BttMaximize.Click += new System.EventHandler(this._BttMaximize_Click);
            // 
            // _BttClose
            // 
            this._BttClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._BttClose.FlatAppearance.BorderSize = 0;
            this._BttClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this._BttClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(74)))));
            this._BttClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._BttClose.ForeColor = System.Drawing.Color.Gainsboro;
            this._BttClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this._BttClose.IconColor = System.Drawing.Color.Gainsboro;
            this._BttClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._BttClose.IconSize = 30;
            this._BttClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._BttClose.Location = new System.Drawing.Point(1211, 12);
            this._BttClose.Name = "_BttClose";
            this._BttClose.Size = new System.Drawing.Size(30, 30);
            this._BttClose.TabIndex = 2;
            this._BttClose.UseVisualStyleBackColor = true;
            this._BttClose.Click += new System.EventHandler(this._BttClose_Click);
            // 
            // _NameCurrentTab
            // 
            this._NameCurrentTab.AutoSize = true;
            this._NameCurrentTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._NameCurrentTab.ForeColor = System.Drawing.Color.Gainsboro;
            this._NameCurrentTab.Location = new System.Drawing.Point(45, 11);
            this._NameCurrentTab.Name = "_NameCurrentTab";
            this._NameCurrentTab.Size = new System.Drawing.Size(86, 31);
            this._NameCurrentTab.TabIndex = 1;
            this._NameCurrentTab.Text = "Home";
            // 
            // _IconCurrentTab
            // 
            this._IconCurrentTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this._IconCurrentTab.ForeColor = System.Drawing.Color.Gainsboro;
            this._IconCurrentTab.IconChar = FontAwesome.Sharp.IconChar.Home;
            this._IconCurrentTab.IconColor = System.Drawing.Color.Gainsboro;
            this._IconCurrentTab.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._IconCurrentTab.Location = new System.Drawing.Point(7, 12);
            this._IconCurrentTab.Name = "_IconCurrentTab";
            this._IconCurrentTab.Size = new System.Drawing.Size(32, 32);
            this._IconCurrentTab.TabIndex = 0;
            this._IconCurrentTab.TabStop = false;
            // 
            // _PanelDesktop
            // 
            this._PanelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this._PanelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PanelDesktop.Location = new System.Drawing.Point(246, 54);
            this._PanelDesktop.Name = "_PanelDesktop";
            this._PanelDesktop.Size = new System.Drawing.Size(1253, 698);
            this._PanelDesktop.TabIndex = 6;
            // 
            // SMBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1499, 752);
            this.Controls.Add(this._PanelDesktop);
            this.Controls.Add(this._PanelTitleBar);
            this.Controls.Add(this._PanelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SMBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steam Master";
            this.Resize += new System.EventHandler(this.SMmain_Resize);
            this._PanelSideMenu.ResumeLayout(false);
            this._PanelSideMenu.PerformLayout();
            this._PanelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this._PanelTitleBar.ResumeLayout(false);
            this._PanelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._IconCurrentTab)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel _PanelSideMenu;
        private System.Windows.Forms.Panel _PanelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel _PanelTitleBar;
        private System.Windows.Forms.Panel _PanelDesktop;
        private FontAwesome.Sharp.IconButton _BttIdle;
        private FontAwesome.Sharp.IconButton _BttSelectGame;
        private FontAwesome.Sharp.IconButton _BttMain;
        private FontAwesome.Sharp.IconPictureBox _IconCurrentTab;
        private System.Windows.Forms.Label _NameCurrentTab;
        private FontAwesome.Sharp.IconButton _BttMinimize;
        private FontAwesome.Sharp.IconButton _BttMaximize;
        private FontAwesome.Sharp.IconButton _BttClose;
        private System.Windows.Forms.Label label1;
    }
}

