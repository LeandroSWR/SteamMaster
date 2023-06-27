
namespace SteamMaster
{
    partial class ListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._AchievementImg = new System.Windows.Forms.PictureBox();
            this._AchievementDesc = new System.Windows.Forms.Label();
            this._AchievementName = new System.Windows.Forms.Label();
            this._AchievementUnlocked = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._AchievementImg)).BeginInit();
            this.SuspendLayout();
            // 
            // _AchievementImg
            // 
            this._AchievementImg.Location = new System.Drawing.Point(35, 10);
            this._AchievementImg.Name = "_AchievementImg";
            this._AchievementImg.Size = new System.Drawing.Size(64, 64);
            this._AchievementImg.TabIndex = 0;
            this._AchievementImg.TabStop = false;
            // 
            // _AchievementDesc
            // 
            this._AchievementDesc.AutoEllipsis = true;
            this._AchievementDesc.BackColor = System.Drawing.Color.Transparent;
            this._AchievementDesc.Location = new System.Drawing.Point(106, 35);
            this._AchievementDesc.Name = "_AchievementDesc";
            this._AchievementDesc.Size = new System.Drawing.Size(436, 39);
            this._AchievementDesc.TabIndex = 2;
            this._AchievementDesc.Text = "label2";
            // 
            // _AchievementName
            // 
            this._AchievementName.AutoEllipsis = true;
            this._AchievementName.BackColor = System.Drawing.Color.Transparent;
            this._AchievementName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._AchievementName.ForeColor = System.Drawing.Color.Black;
            this._AchievementName.Location = new System.Drawing.Point(105, 10);
            this._AchievementName.Name = "_AchievementName";
            this._AchievementName.Size = new System.Drawing.Size(437, 23);
            this._AchievementName.TabIndex = 1;
            this._AchievementName.Text = "label1";
            // 
            // _AchievementUnlocked
            // 
            this._AchievementUnlocked.AutoSize = true;
            this._AchievementUnlocked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._AchievementUnlocked.Location = new System.Drawing.Point(10, 35);
            this._AchievementUnlocked.Name = "_AchievementUnlocked";
            this._AchievementUnlocked.Size = new System.Drawing.Size(15, 14);
            this._AchievementUnlocked.TabIndex = 3;
            this._AchievementUnlocked.UseVisualStyleBackColor = true;
            // 
            // ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SteamMaster.Properties.Resources.achievement_bg;
            this.Controls.Add(this._AchievementUnlocked);
            this.Controls.Add(this._AchievementDesc);
            this.Controls.Add(this._AchievementName);
            this.Controls.Add(this._AchievementImg);
            this.Name = "ListItem";
            this.Size = new System.Drawing.Size(469, 84);
            ((System.ComponentModel.ISupportInitialize)(this._AchievementImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _AchievementImg;
        private System.Windows.Forms.Label _AchievementDesc;
        private System.Windows.Forms.Label _AchievementName;
        public System.Windows.Forms.CheckBox _AchievementUnlocked;
    }
}
