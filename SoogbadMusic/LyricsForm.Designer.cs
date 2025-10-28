namespace SoogbadMusic
{
    partial class LyricsForm
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LyricsForm));
            this.LyricsLabel = new System.Windows.Forms.Label();
            this.Panel = new System.Windows.Forms.Panel();
            this.SongNameLabel = new System.Windows.Forms.Label();
            this.SongInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LyricsLabel
            // 
            this.LyricsLabel.AutoSize = true;
            this.LyricsLabel.Font = new System.Drawing.Font("Calibri", 11.08383F);
            this.LyricsLabel.ForeColor = System.Drawing.Color.White;
            this.LyricsLabel.Location = new System.Drawing.Point(20, 18);
            this.LyricsLabel.Name = "LyricsLabel";
            this.LyricsLabel.Size = new System.Drawing.Size(0, 18);
            this.LyricsLabel.TabIndex = 1;
            this.LyricsLabel.UseMnemonic = false;
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(80)))));
            this.Panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.16018F);
            this.Panel.Location = new System.Drawing.Point(0, 86);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1259, 530);
            this.Panel.TabIndex = 2;
            // 
            // SongNameLabel
            // 
            this.SongNameLabel.AutoSize = true;
            this.SongNameLabel.Font = new System.Drawing.Font("Calibri", 17.5494F, System.Drawing.FontStyle.Bold);
            this.SongNameLabel.ForeColor = System.Drawing.Color.White;
            this.SongNameLabel.Location = new System.Drawing.Point(20, 18);
            this.SongNameLabel.Name = "SongNameLabel";
            this.SongNameLabel.Size = new System.Drawing.Size(0, 29);
            this.SongNameLabel.TabIndex = 3;
            this.SongNameLabel.UseMnemonic = false;
            // 
            // SongInfoLabel
            // 
            this.SongInfoLabel.AutoSize = true;
            this.SongInfoLabel.Font = new System.Drawing.Font("Calibri", 13.85479F);
            this.SongInfoLabel.ForeColor = System.Drawing.Color.White;
            this.SongInfoLabel.Location = new System.Drawing.Point(20, 49);
            this.SongInfoLabel.Name = "SongInfoLabel";
            this.SongInfoLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SongInfoLabel.Size = new System.Drawing.Size(0, 23);
            this.SongInfoLabel.TabIndex = 4;
            this.SongInfoLabel.UseMnemonic = false;
            // 
            // LyricsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1259, 617);
            this.Controls.Add(this.SongInfoLabel);
            this.Controls.Add(this.SongNameLabel);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.LyricsLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LyricsForm";
            this.Text = "SoogbadMusic";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LyricsLabel;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Label SongNameLabel;
        private System.Windows.Forms.Label SongInfoLabel;
    }
}