namespace SoogbadMusic
{
    partial class DownloadSongForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadSongForm));
            DownloadButton = new Button();
            URLLabel = new Label();
            URLTextBox = new TextBox();
            SuspendLayout();
            // 
            // DownloadButton
            // 
            DownloadButton.Location = new Point(61, 78);
            DownloadButton.Margin = new Padding(4);
            DownloadButton.Name = "DownloadButton";
            DownloadButton.Size = new Size(88, 26);
            DownloadButton.TabIndex = 0;
            DownloadButton.Text = "Download";
            DownloadButton.UseVisualStyleBackColor = true;
            DownloadButton.MouseClick += OnDownloadButtonMouseClick;
            // 
            // URLLabel
            // 
            URLLabel.AutoSize = true;
            URLLabel.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            URLLabel.ForeColor = Color.White;
            URLLabel.Location = new Point(18, 17);
            URLLabel.Margin = new Padding(4, 0, 4, 0);
            URLLabel.Name = "URLLabel";
            URLLabel.Size = new Size(33, 15);
            URLLabel.TabIndex = 1;
            URLLabel.Text = "URL: ";
            // 
            // URLTextBox
            // 
            URLTextBox.BackColor = Color.FromArgb(32, 96, 112);
            URLTextBox.Font = new Font("Calibri", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            URLTextBox.ForeColor = Color.White;
            URLTextBox.Location = new Point(76, 14);
            URLTextBox.Margin = new Padding(4);
            URLTextBox.Name = "URLTextBox";
            URLTextBox.Size = new Size(116, 21);
            URLTextBox.TabIndex = 3;
            // 
            // DownloadSongForm
            // 
            AutoScaleDimensions = new SizeF(6F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 64, 80);
            ClientSize = new Size(212, 121);
            Controls.Add(URLTextBox);
            Controls.Add(URLLabel);
            Controls.Add(DownloadButton);
            Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DownloadSongForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DownloadButton;
        private Label URLLabel;
        private TextBox URLTextBox;
    }
}