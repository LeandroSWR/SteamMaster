
namespace SteamMaster
{
    partial class SMMain
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
            this._PanelDesktop = new System.Windows.Forms.Panel();
            this._TimeText = new System.Windows.Forms.Label();
            this._DateText = new System.Windows.Forms.Label();
            this._Timer = new System.Windows.Forms.Timer(this.components);
            this._AppLogo = new System.Windows.Forms.Label();
            this._PanelDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // _PanelDesktop
            // 
            this._PanelDesktop.AutoSize = true;
            this._PanelDesktop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._PanelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this._PanelDesktop.Controls.Add(this._AppLogo);
            this._PanelDesktop.Controls.Add(this._DateText);
            this._PanelDesktop.Controls.Add(this._TimeText);
            this._PanelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PanelDesktop.Location = new System.Drawing.Point(0, 0);
            this._PanelDesktop.Name = "_PanelDesktop";
            this._PanelDesktop.Size = new System.Drawing.Size(683, 387);
            this._PanelDesktop.TabIndex = 0;
            // 
            // _TimeText
            // 
            this._TimeText.AutoEllipsis = true;
            this._TimeText.BackColor = System.Drawing.Color.Transparent;
            this._TimeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this._TimeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TimeText.ForeColor = System.Drawing.Color.Gainsboro;
            this._TimeText.Location = new System.Drawing.Point(0, 0);
            this._TimeText.Name = "_TimeText";
            this._TimeText.Padding = new System.Windows.Forms.Padding(0, 80, 0, 0);
            this._TimeText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._TimeText.Size = new System.Drawing.Size(683, 387);
            this._TimeText.TabIndex = 2;
            this._TimeText.Text = "13:37:00";
            this._TimeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _DateText
            // 
            this._DateText.BackColor = System.Drawing.Color.Transparent;
            this._DateText.Dock = System.Windows.Forms.DockStyle.Fill;
            this._DateText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._DateText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._DateText.ForeColor = System.Drawing.Color.Gainsboro;
            this._DateText.Location = new System.Drawing.Point(0, 0);
            this._DateText.Name = "_DateText";
            this._DateText.Padding = new System.Windows.Forms.Padding(0, 160, 0, 0);
            this._DateText.Size = new System.Drawing.Size(683, 387);
            this._DateText.TabIndex = 3;
            this._DateText.Text = "Thursday, December 19, 2021";
            this._DateText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Timer
            // 
            this._Timer.Enabled = true;
            this._Timer.Interval = 1000;
            this._Timer.Tick += new System.EventHandler(this.OnSecondPassed);
            // 
            // _AppLogo
            // 
            this._AppLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._AppLogo.ForeColor = System.Drawing.Color.Gainsboro;
            this._AppLogo.Image = global::SteamMaster.Properties.Resources.SM_IconText;
            this._AppLogo.Location = new System.Drawing.Point(0, 0);
            this._AppLogo.Name = "_AppLogo";
            this._AppLogo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 80);
            this._AppLogo.Size = new System.Drawing.Size(683, 387);
            this._AppLogo.TabIndex = 4;
            this._AppLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(683, 387);
            this.Controls.Add(this._PanelDesktop);
            this.Name = "SMMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SMMain_Load);
            this._PanelDesktop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _PanelDesktop;
        private System.Windows.Forms.Timer _Timer;
        private System.Windows.Forms.Label _DateText;
        private System.Windows.Forms.Label _TimeText;
        private System.Windows.Forms.Label _AppLogo;
    }
}