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
            ((System.ComponentModel.ISupportInitialize)AlbumCoverPictureButton).BeginInit();
            SuspendLayout();
            // 
            // TitleTextBox
            // 
            TitleTextBox.BackColor = Color.FromArgb(32, 96, 112);
            TitleTextBox.Font = new Font("Calibri", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 177);
            TitleTextBox.ForeColor = Color.White;
            TitleTextBox.Location = new Point(76, 14);
            TitleTextBox.Margin = new Padding(4);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(116, 21);
            TitleTextBox.TabIndex = 0;
            TitleTextBox.WordWrap = false;
            TitleTextBox.TextChanged += OnTextBoxTextChanged;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 177);
            TitleLabel.ForeColor = Color.White;
            TitleLabel.Location = new Point(18, 17);
            TitleLabel.Margin = new Padding(4, 0, 4, 0);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(34, 15);
            TitleLabel.TabIndex = 1;
            TitleLabel.Text = "Title:";
            // 
            // ArtistLabel
            // 
            ArtistLabel.AutoSize = true;
            ArtistLabel.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 177);
            ArtistLabel.ForeColor = Color.White;
            ArtistLabel.Location = new Point(18, 73);
            ArtistLabel.Margin = new Padding(4, 0, 4, 0);
            ArtistLabel.Name = "ArtistLabel";
            ArtistLabel.Size = new Size(39, 15);
            ArtistLabel.TabIndex = 3;
            ArtistLabel.Text = "Artist:";
            // 
            // ArtistTextBox
            // 
            ArtistTextBox.BackColor = Color.FromArgb(32, 96, 112);
            ArtistTextBox.Font = new Font("Calibri", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 177);
            ArtistTextBox.ForeColor = Color.White;
            ArtistTextBox.Location = new Point(76, 69);
            ArtistTextBox.Margin = new Padding(4);
            ArtistTextBox.Name = "ArtistTextBox";
            ArtistTextBox.Size = new Size(116, 21);
            ArtistTextBox.TabIndex = 2;
            ArtistTextBox.WordWrap = false;
            ArtistTextBox.TextChanged += OnTextBoxTextChanged;
            // 
            // AlbumLabel
            // 
            AlbumLabel.AutoSize = true;
            AlbumLabel.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 177);
            AlbumLabel.ForeColor = Color.White;
            AlbumLabel.Location = new Point(18, 128);
            AlbumLabel.Margin = new Padding(4, 0, 4, 0);
            AlbumLabel.Name = "AlbumLabel";
            AlbumLabel.Size = new Size(45, 15);
            AlbumLabel.TabIndex = 5;
            AlbumLabel.Text = "Album:";
            // 
            // AlbumTextBox
            // 
            AlbumTextBox.BackColor = Color.FromArgb(32, 96, 112);
            AlbumTextBox.Font = new Font("Calibri", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 177);
            AlbumTextBox.ForeColor = Color.White;
            AlbumTextBox.Location = new Point(76, 125);
            AlbumTextBox.Margin = new Padding(4);
            AlbumTextBox.Name = "AlbumTextBox";
            AlbumTextBox.Size = new Size(116, 21);
            AlbumTextBox.TabIndex = 4;
            AlbumTextBox.WordWrap = false;
            AlbumTextBox.TextChanged += OnTextBoxTextChanged;
            // 
            // YearLabel
            // 
            YearLabel.AutoSize = true;
            YearLabel.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 177);
            YearLabel.ForeColor = Color.White;
            YearLabel.Location = new Point(18, 184);
            YearLabel.Margin = new Padding(4, 0, 4, 0);
            YearLabel.Name = "YearLabel";
            YearLabel.Size = new Size(33, 15);
            YearLabel.TabIndex = 7;
            YearLabel.Text = "Year:";
            // 
            // YearTextBox
            // 
            YearTextBox.BackColor = Color.FromArgb(32, 96, 112);
            YearTextBox.Font = new Font("Calibri", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 177);
            YearTextBox.ForeColor = Color.White;
            YearTextBox.Location = new Point(76, 180);
            YearTextBox.Margin = new Padding(4);
            YearTextBox.MaxLength = 4;
            YearTextBox.Name = "YearTextBox";
            YearTextBox.ShortcutsEnabled = false;
            YearTextBox.Size = new Size(116, 21);
            YearTextBox.TabIndex = 6;
            YearTextBox.WordWrap = false;
            YearTextBox.TextChanged += OnTextBoxTextChanged;
            YearTextBox.KeyPress += OnYearTextBoxKeyPress;
            // 
            // AlbumCoverLabel
            // 
            AlbumCoverLabel.AutoSize = true;
            AlbumCoverLabel.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 177);
            AlbumCoverLabel.ForeColor = Color.White;
            AlbumCoverLabel.Location = new Point(88, 291);
            AlbumCoverLabel.Margin = new Padding(4, 0, 4, 0);
            AlbumCoverLabel.Name = "AlbumCoverLabel";
            AlbumCoverLabel.Size = new Size(79, 15);
            AlbumCoverLabel.TabIndex = 11;
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
            LyricsTextBox.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 177);
            LyricsTextBox.ForeColor = Color.White;
            LyricsTextBox.HideSelection = false;
            LyricsTextBox.Location = new Point(337, 17);
            LyricsTextBox.Margin = new Padding(4);
            LyricsTextBox.Multiline = true;
            LyricsTextBox.Name = "LyricsTextBox";
            LyricsTextBox.ScrollBars = ScrollBars.Vertical;
            LyricsTextBox.Size = new Size(746, 415);
            LyricsTextBox.TabIndex = 12;
            LyricsTextBox.WordWrap = false;
            LyricsTextBox.TextChanged += OnTextBoxTextChanged;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 177);
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
            SaveButton.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 177);
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
            AlbumCoverPictureButton.Location = new Point(76, 317);
            AlbumCoverPictureButton.Margin = new Padding(4);
            AlbumCoverPictureButton.Name = "AlbumCoverPictureButton";
            AlbumCoverPictureButton.Size = new Size(117, 115);
            AlbumCoverPictureButton.SizeMode = PictureBoxSizeMode.StretchImage;
            AlbumCoverPictureButton.TabIndex = 10;
            AlbumCoverPictureButton.TabStop = false;
            AlbumCoverPictureButton.MouseClick += OnAlbumCoverPictureButtonMouseClick;
            // 
            // SongInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 64, 80);
            ClientSize = new Size(1102, 578);
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
            Name = "SongInfoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Song Info";
            FormClosing += OnFormClosing;
            ((System.ComponentModel.ISupportInitialize)AlbumCoverPictureButton).EndInit();
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
    }
}