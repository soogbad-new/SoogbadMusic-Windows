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
            LyricsLabel = new Label();
            Panel = new Panel();
            SongNameLabel = new Label();
            SongInfoLabel = new Label();
            SuspendLayout();
            // 
            // LyricsLabel
            // 
            LyricsLabel.AutoSize = true;
            LyricsLabel.Font = new Font("Calibri", 11.08383F);
            LyricsLabel.ForeColor = Color.White;
            LyricsLabel.Location = new Point(20, 18);
            LyricsLabel.Name = "LyricsLabel";
            LyricsLabel.Size = new Size(0, 18);
            LyricsLabel.TabIndex = 1;
            LyricsLabel.UseMnemonic = false;
            // 
            // Panel
            // 
            Panel.BackColor = Color.FromArgb(0, 64, 80);
            Panel.Font = new Font("Microsoft Sans Serif", 10.16018F);
            Panel.Location = new Point(0, 86);
            Panel.Name = "Panel";
            Panel.Size = new Size(1259, 530);
            Panel.TabIndex = 2;
            // 
            // SongNameLabel
            // 
            SongNameLabel.AutoSize = true;
            SongNameLabel.Font = new Font("Calibri", 17.5494F, FontStyle.Bold);
            SongNameLabel.ForeColor = Color.White;
            SongNameLabel.Location = new Point(20, 18);
            SongNameLabel.Name = "SongNameLabel";
            SongNameLabel.Size = new Size(0, 29);
            SongNameLabel.TabIndex = 3;
            SongNameLabel.UseMnemonic = false;
            // 
            // SongInfoLabel
            // 
            SongInfoLabel.AutoSize = true;
            SongInfoLabel.Font = new Font("Calibri", 13.85479F);
            SongInfoLabel.ForeColor = Color.White;
            SongInfoLabel.Location = new Point(20, 49);
            SongInfoLabel.Name = "SongInfoLabel";
            SongInfoLabel.RightToLeft = RightToLeft.No;
            SongInfoLabel.Size = new Size(0, 23);
            SongInfoLabel.TabIndex = 4;
            SongInfoLabel.UseMnemonic = false;
            // 
            // LyricsForm
            // 
            AutoScaleDimensions = new SizeF(6F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 48, 64);
            ClientSize = new Size(1259, 617);
            Controls.Add(SongInfoLabel);
            Controls.Add(SongNameLabel);
            Controls.Add(Panel);
            Controls.Add(LyricsLabel);
            Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1275, 656);
            Name = "LyricsForm";
            Text = "SoogbadMusic";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LyricsLabel;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Label SongNameLabel;
        private System.Windows.Forms.Label SongInfoLabel;
    }
}