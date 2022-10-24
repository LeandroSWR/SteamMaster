
namespace SteamMaster.Achievements
{
    partial class SMAchievements
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._SaveButton = new System.Windows.Forms.Button();
            this._UnlockAll = new System.Windows.Forms.Button();
            this._LockAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(212, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(477, 354);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // _SaveButton
            // 
            this._SaveButton.Location = new System.Drawing.Point(36, 27);
            this._SaveButton.Name = "_SaveButton";
            this._SaveButton.Size = new System.Drawing.Size(145, 134);
            this._SaveButton.TabIndex = 1;
            this._SaveButton.Text = "Save Achievements";
            this._SaveButton.UseVisualStyleBackColor = true;
            this._SaveButton.Click += new System.EventHandler(this.OnSaveValues);
            // 
            // _UnlockAll
            // 
            this._UnlockAll.Location = new System.Drawing.Point(36, 187);
            this._UnlockAll.Name = "_UnlockAll";
            this._UnlockAll.Size = new System.Drawing.Size(145, 67);
            this._UnlockAll.TabIndex = 2;
            this._UnlockAll.Text = "Unlock All!";
            this._UnlockAll.UseVisualStyleBackColor = true;
            this._UnlockAll.Click += new System.EventHandler(this.UnlockAll);
            // 
            // _LockAll
            // 
            this._LockAll.Location = new System.Drawing.Point(36, 275);
            this._LockAll.Name = "_LockAll";
            this._LockAll.Size = new System.Drawing.Size(145, 67);
            this._LockAll.TabIndex = 3;
            this._LockAll.Text = "Lock All!";
            this._LockAll.UseVisualStyleBackColor = true;
            this._LockAll.Click += new System.EventHandler(this.LockAll);
            // 
            // SMAchievements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(689, 354);
            this.Controls.Add(this._LockAll);
            this.Controls.Add(this._UnlockAll);
            this.Controls.Add(this._SaveButton);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "SMAchievements";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SMAchievements_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button _SaveButton;
        private System.Windows.Forms.Button _UnlockAll;
        private System.Windows.Forms.Button _LockAll;
    }
}

