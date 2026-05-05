namespace SoogbadMusic
{
    partial class SongInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongInfoForm));
            TitleTextBox = new TextBox();
            TitleLabel = new Label();
            ArtistLabel = new Label();
            ArtistTextBox = new TextBox();
            AlbumLabel = new Label();
            AlbumTextBox = new TextBox();
            YearLabel = new Label();
            YearTextBox = new TextBox();
            AlbumCoverLabel = new Label();
            OpenAlbumCoverDialog = new OpenFileDialog();
            LyricsTextBox = new TextBox();
            CancelButton = new Button();
            SaveButton = new Button();
            AlbumCoverPictureButton = new PictureButton();
            LoadingGIFPictureBox = new PictureBox();
            ProgressLabel = new Label();
            GenreLabel = new Label();
            GenreTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)AlbumCoverPictureButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LoadingGIFPictureBox).BeginInit();
            SuspendLayout();
            // 
            // TitleTextBox
            // 
            TitleTextBox.BackColor = Color.FromArgb(32, 96, 112);
            TitleTextBox.Font = new Font("Calibri", 8.25F);
            TitleTextBox.ForeColor = Color.White;
            TitleTextBox.Location = new Point(76, 14);
            TitleTextBox.Margin = new Padding(4);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(116, 21);
            TitleTextBox.TabIndex = 1;
            TitleTextBox.WordWrap = false;
            TitleTextBox.TextChanged += OnTextBoxTextChanged;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Calibri", 9.75F);
            TitleLabel.ForeColor = Color.White;
            TitleLabel.Location = new Point(18, 17);
            TitleLabel.Margin = new Padding(4, 0, 4, 0);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(34, 15);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Title:";
            // 
            // ArtistLabel
            // 
            ArtistLabel.AutoSize = true;
            ArtistLabel.Font = new Font("Calibri", 9.75F);
            ArtistLabel.ForeColor = Color.White;
            ArtistLabel.Location = new Point(18, 73);
            ArtistLabel.Margin = new Padding(4, 0, 4, 0);
            ArtistLabel.Name = "ArtistLabel";
            ArtistLabel.Size = new Size(39, 15);
            ArtistLabel.TabIndex = 2;
            ArtistLabel.Text = "Artist:";
            // 
            // ArtistTextBox
            // 
            ArtistTextBox.BackColor = Color.FromArgb(32, 96, 112);
            ArtistTextBox.Font = new Font("Calibri", 8.25F);
            ArtistTextBox.ForeColor = Color.White;
            ArtistTextBox.Location = new Point(76, 69);
            ArtistTextBox.Margin = new Padding(4);
            ArtistTextBox.Name = "ArtistTextBox";
            ArtistTextBox.Size = new Size(116, 21);
            ArtistTextBox.TabIndex = 3;
            ArtistTextBox.WordWrap = false;
            ArtistTextBox.TextChanged += OnTextBoxTextChanged;
            // 
            // AlbumLabel
            // 
            AlbumLabel.AutoSize = true;
            AlbumLabel.Font = new Font("Calibri", 9.75F);
            AlbumLabel.ForeColor = Color.White;
            AlbumLabel.Location = new Point(18, 128);
            AlbumLabel.Margin = new Padding(4, 0, 4, 0);
            AlbumLabel.Name = "AlbumLabel";
            AlbumLabel.Size = new Size(45, 15);
            AlbumLabel.TabIndex = 4;
            AlbumLabel.Text = "Album:";
            // 
            // AlbumTextBox
            // 
            AlbumTextBox.BackColor = Color.FromArgb(32, 96, 112);
            AlbumTextBox.Font = new Font("Calibri", 8.25F);
            AlbumTextBox.ForeColor = Color.White;
            AlbumTextBox.Location = new Point(76, 125);
            AlbumTextBox.Margin = new Padding(4);
            AlbumTextBox.Name = "AlbumTextBox";
            AlbumTextBox.Size = new Size(116, 21);
            AlbumTextBox.TabIndex = 5;
            AlbumTextBox.WordWrap = false;
            AlbumTextBox.TextChanged += OnTextBoxTextChanged;
            // 
            // YearLabel
            // 
            YearLabel.AutoSize = true;
            YearLabel.Font = new Font("Calibri", 9.75F);
            YearLabel.ForeColor = Color.White;
            YearLabel.Location = new Point(18, 184);
            YearLabel.Margin = new Padding(4, 0, 4, 0);
            YearLabel.Name = "YearLabel";
            YearLabel.Size = new Size(33, 15);
            YearLabel.TabIndex = 6;
            YearLabel.Text = "Year:";
            // 
            // YearTextBox
            // 
            YearTextBox.BackColor = Color.FromArgb(32, 96, 112);
            YearTextBox.Font = new Font("Calibri", 8.25F);
            YearTextBox.ForeColor = Color.White;
            YearTextBox.Location = new Point(76, 180);
            YearTextBox.Margin = new Padding(4);
            YearTextBox.MaxLength = 4;
            YearTextBox.Name = "YearTextBox";
            YearTextBox.ShortcutsEnabled = false;
            YearTextBox.Size = new Size(116, 21);
            YearTextBox.TabIndex = 7;
            YearTextBox.WordWrap = false;
            YearTextBox.TextChanged += OnTextBoxTextChanged;
            YearTextBox.KeyPress += OnYearTextBoxKeyPress;
            // 
            // AlbumCoverLabel
            // 
            AlbumCoverLabel.AutoSize = true;
            AlbumCoverLabel.Font = new Font("Calibri", 9.75F);
            AlbumCoverLabel.ForeColor = Color.White;
            AlbumCoverLabel.Location = new Point(88, 291);
            AlbumCoverLabel.Margin = new Padding(4, 0, 4, 0);
            AlbumCoverLabel.Name = "AlbumCoverLabel";
            AlbumCoverLabel.Size = new Size(79, 15);
            AlbumCoverLabel.TabIndex = 10;
            AlbumCoverLabel.Text = "Album Cover:";
            // 
            // OpenAlbumCoverDialog
            // 
            OpenAlbumCoverDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";
            OpenAlbumCoverDialog.SupportMultiDottedExtensions = true;
            // 
            // LyricsTextBox
            // 
            LyricsTextBox.AcceptsReturn = true;
            LyricsTextBox.BackColor = Color.FromArgb(32, 96, 112);
            LyricsTextBox.Font = new Font("Calibri", 12F);
            LyricsTextBox.ForeColor = Color.White;
            LyricsTextBox.HideSelection = false;
            LyricsTextBox.Location = new Point(337, 17);
            LyricsTextBox.Margin = new Padding(4);
            LyricsTextBox.Multiline = true;
            LyricsTextBox.Name = "LyricsTextBox";
            LyricsTextBox.ScrollBars = ScrollBars.Vertical;
            LyricsTextBox.Size = new Size(746, 415);
            LyricsTextBox.TabIndex = 11;
            LyricsTextBox.WordWrap = false;
            LyricsTextBox.TextChanged += OnTextBoxTextChanged;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Calibri", 9F);
            CancelButton.Location = new Point(997, 534);
            CancelButton.Margin = new Padding(4);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(88, 26);
            CancelButton.TabIndex = 13;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.MouseClick += OnCancelButtonMouseClick;
            // 
            // SaveButton
            // 
            SaveButton.Font = new Font("Calibri", 9F);
            SaveButton.Location = new Point(18, 534);
            SaveButton.Margin = new Padding(4);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(88, 26);
            SaveButton.TabIndex = 14;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.MouseClick += OnSaveButtonMouseClick;
            // 
            // AlbumCoverPictureButton
            // 
            AlbumCoverPictureButton.BorderStyle = BorderStyle.FixedSingle;
            AlbumCoverPictureButton.Font = new Font("Segoe UI", 9F);
            AlbumCoverPictureButton.Location = new Point(76, 317);
            AlbumCoverPictureButton.Margin = new Padding(4);
            AlbumCoverPictureButton.Name = "AlbumCoverPictureButton";
            AlbumCoverPictureButton.Size = new Size(117, 115);
            AlbumCoverPictureButton.SizeMode = PictureBoxSizeMode.StretchImage;
            AlbumCoverPictureButton.TabIndex = 10;
            AlbumCoverPictureButton.TabStop = false;
            AlbumCoverPictureButton.MouseClick += OnAlbumCoverPictureButtonMouseClick;
            // 
            // LoadingGIFPictureBox
            // 
            LoadingGIFPictureBox.Font = new Font("Segoe UI", 9F);
            LoadingGIFPictureBox.Image = Properties.Resources.Loading;
            LoadingGIFPictureBox.Location = new Point(532, 514);
            LoadingGIFPictureBox.Margin = new Padding(4);
            LoadingGIFPictureBox.Name = "LoadingGIFPictureBox";
            LoadingGIFPictureBox.Size = new Size(40, 40);
            LoadingGIFPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            LoadingGIFPictureBox.TabIndex = 15;
            LoadingGIFPictureBox.TabStop = false;
            LoadingGIFPictureBox.Visible = false;
            // 
            // ProgressLabel
            // 
            ProgressLabel.AutoSize = true;
            ProgressLabel.Font = new Font("Calibri", 9F);
            ProgressLabel.ForeColor = Color.White;
            ProgressLabel.Location = new Point(492, 556);
            ProgressLabel.Margin = new Padding(4, 0, 4, 0);
            ProgressLabel.MaximumSize = new Size(119, 0);
            ProgressLabel.MinimumSize = new Size(119, 0);
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new Size(119, 14);
            ProgressLabel.TabIndex = 12;
            ProgressLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GenreLabel
            // 
            GenreLabel.AutoSize = true;
            GenreLabel.Font = new Font("Calibri", 9.75F);
            GenreLabel.ForeColor = Color.White;
            GenreLabel.Location = new Point(18, 238);
            GenreLabel.Margin = new Padding(4, 0, 4, 0);
            GenreLabel.Name = "GenreLabel";
            GenreLabel.RightToLeft = RightToLeft.No;
            GenreLabel.Size = new Size(42, 15);
            GenreLabel.TabIndex = 8;
            GenreLabel.Text = "Genre:";
            // 
            // GenreTextBox
            // 
            GenreTextBox.BackColor = Color.FromArgb(32, 96, 112);
            GenreTextBox.Font = new Font("Calibri", 8.25F);
            GenreTextBox.ForeColor = Color.White;
            GenreTextBox.Location = new Point(76, 235);
            GenreTextBox.Margin = new Padding(4);
            GenreTextBox.Name = "GenreTextBox";
            GenreTextBox.Size = new Size(116, 21);
            GenreTextBox.TabIndex = 9;
            GenreTextBox.WordWrap = false;
            // 
            // SongInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 64, 80);
            ClientSize = new Size(1102, 578);
            Controls.Add(GenreTextBox);
            Controls.Add(GenreLabel);
            Controls.Add(ProgressLabel);
            Controls.Add(LoadingGIFPictureBox);
            Controls.Add(SaveButton);
            Controls.Add(CancelButton);
            Controls.Add(LyricsTextBox);
            Controls.Add(AlbumCoverLabel);
            Controls.Add(AlbumCoverPictureButton);
            Controls.Add(YearLabel);
            Controls.Add(YearTextBox);
            Controls.Add(AlbumLabel);
            Controls.Add(AlbumTextBox);
            Controls.Add(ArtistLabel);
            Controls.Add(ArtistTextBox);
            Controls.Add(TitleLabel);
            Controls.Add(TitleTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimumSize = new Size(1118, 617);
            Name = "SongInfoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Song Info";
            FormClosing += OnFormClosing;
            ((System.ComponentModel.ISupportInitialize)AlbumCoverPictureButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)LoadingGIFPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label ArtistLabel;
        private System.Windows.Forms.TextBox ArtistTextBox;
        private System.Windows.Forms.Label AlbumLabel;
        private System.Windows.Forms.TextBox AlbumTextBox;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.TextBox YearTextBox;
        private PictureButton AlbumCoverPictureButton;
        private System.Windows.Forms.Label AlbumCoverLabel;
        private System.Windows.Forms.OpenFileDialog OpenAlbumCoverDialog;
        private System.Windows.Forms.TextBox LyricsTextBox;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private PictureBox LoadingGIFPictureBox;
        private Label ProgressLabel;
        private Label GenreLabel;
        private TextBox GenreTextBox;
    }
}