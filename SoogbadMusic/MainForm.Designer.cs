namespace SoogbadMusic
{
    partial class MainForm
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
            if(PlaybackManager.Player != null)
                PlaybackManager.Player.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ProgressBarBackground = new PictureButton();
            ProgressBar = new PictureButton();
            CurrentTimeLabel = new Label();
            DurationLabel = new Label();
            PlayPauseButton = new PictureButton();
            PreviousButton = new PictureButton();
            NextButton = new PictureButton();
            SongListScrollBar = new VScrollBar();
            SearchTextBox = new TextBox();
            SongNameLabel = new Label();
            SongInfoLabel = new Label();
            SongList = new SongList(SongListScrollBar);
            AlbumCoverPictureBox = new PictureBox();
            AdvancedSearchButton = new PictureButton();
            MenuStrip = new MenuStrip();
            LyricsButton = new ToolStripMenuItem();
            ShuffleButton = new ToolStripMenuItem();
            FilterButton = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)ProgressBarBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProgressBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayPauseButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreviousButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NextButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AlbumCoverPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AdvancedSearchButton).BeginInit();
            MenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ProgressBarBackground
            // 
            ProgressBarBackground.BackColor = Color.Black;
            ProgressBarBackground.Font = new Font("Microsoft Sans Serif", 8.25F);
            ProgressBarBackground.Location = new Point(0, 120);
            ProgressBarBackground.Name = "ProgressBarBackground";
            ProgressBarBackground.Size = new Size(944, 35);
            ProgressBarBackground.SizeMode = PictureBoxSizeMode.Zoom;
            ProgressBarBackground.TabIndex = 3;
            ProgressBarBackground.TabStop = false;
            ProgressBarBackground.MouseDown += OnProgressBarBackgroundMouseDown;
            // 
            // ProgressBar
            // 
            ProgressBar.BackColor = Color.FromArgb(15, 100, 50);
            ProgressBar.Font = new Font("Microsoft Sans Serif", 8.25F);
            ProgressBar.Location = new Point(0, 120);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(1, 35);
            ProgressBar.SizeMode = PictureBoxSizeMode.Zoom;
            ProgressBar.TabIndex = 4;
            ProgressBar.TabStop = false;
            ProgressBar.Visible = false;
            ProgressBar.MouseDown += OnProgressBarMouseDown;
            // 
            // CurrentTimeLabel
            // 
            CurrentTimeLabel.AutoSize = true;
            CurrentTimeLabel.BackColor = Color.Transparent;
            CurrentTimeLabel.Font = new Font("Calibri", 8.25F);
            CurrentTimeLabel.ForeColor = Color.White;
            CurrentTimeLabel.Location = new Point(0, 103);
            CurrentTimeLabel.Name = "CurrentTimeLabel";
            CurrentTimeLabel.Size = new Size(28, 13);
            CurrentTimeLabel.TabIndex = 5;
            CurrentTimeLabel.Text = "0:00";
            // 
            // DurationLabel
            // 
            DurationLabel.AutoSize = true;
            DurationLabel.BackColor = Color.Transparent;
            DurationLabel.Font = new Font("Calibri", 8.25F);
            DurationLabel.ForeColor = Color.White;
            DurationLabel.Location = new Point(911, 103);
            DurationLabel.Name = "DurationLabel";
            DurationLabel.Size = new Size(28, 13);
            DurationLabel.TabIndex = 6;
            DurationLabel.Text = "0:00";
            // 
            // PlayPauseButton
            // 
            PlayPauseButton.BackColor = Color.Transparent;
            PlayPauseButton.Enabled = false;
            PlayPauseButton.Font = new Font("Microsoft Sans Serif", 8.25F);
            PlayPauseButton.Image = Properties.Resources.Play;
            PlayPauseButton.Location = new Point(462, 80);
            PlayPauseButton.Name = "PlayPauseButton";
            PlayPauseButton.Size = new Size(21, 21);
            PlayPauseButton.SizeMode = PictureBoxSizeMode.Zoom;
            PlayPauseButton.TabIndex = 10;
            PlayPauseButton.TabStop = false;
            PlayPauseButton.MouseDown += OnPlayPauseButtonMouseDown;
            // 
            // PreviousButton
            // 
            PreviousButton.BackColor = Color.Transparent;
            PreviousButton.Enabled = false;
            PreviousButton.Font = new Font("Microsoft Sans Serif", 8.25F);
            PreviousButton.Image = Properties.Resources.Previous;
            PreviousButton.Location = new Point(411, 80);
            PreviousButton.Name = "PreviousButton";
            PreviousButton.Size = new Size(20, 20);
            PreviousButton.SizeMode = PictureBoxSizeMode.Zoom;
            PreviousButton.TabIndex = 11;
            PreviousButton.TabStop = false;
            PreviousButton.MouseDown += OnPreviousButtonMouseDown;
            // 
            // NextButton
            // 
            NextButton.BackColor = Color.Transparent;
            NextButton.Enabled = false;
            NextButton.Font = new Font("Microsoft Sans Serif", 8.25F);
            NextButton.Image = Properties.Resources.Next;
            NextButton.Location = new Point(512, 80);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(20, 20);
            NextButton.SizeMode = PictureBoxSizeMode.Zoom;
            NextButton.TabIndex = 12;
            NextButton.TabStop = false;
            NextButton.MouseDown += OnNextButtonMouseDown;
            // 
            // SongListScrollBar
            // 
            SongListScrollBar.Font = new Font("Microsoft Sans Serif", 8.25F);
            SongListScrollBar.LargeChange = 1;
            SongListScrollBar.Location = new Point(927, 155);
            SongListScrollBar.Maximum = 0;
            SongListScrollBar.Name = "SongListScrollBar";
            SongListScrollBar.Size = new Size(17, 315);
            SongListScrollBar.TabIndex = 14;
            // 
            // SearchTextBox
            // 
            SearchTextBox.BackColor = Color.FromArgb(32, 96, 112);
            SearchTextBox.BorderStyle = BorderStyle.FixedSingle;
            SearchTextBox.Enabled = false;
            SearchTextBox.Font = new Font("Calibri", 9F);
            SearchTextBox.ForeColor = Color.White;
            SearchTextBox.Location = new Point(0, 475);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(920, 22);
            SearchTextBox.TabIndex = 23;
            SearchTextBox.TextChanged += OnSearchTextBoxTextChanged;
            SearchTextBox.Enter += OnSearchTextBoxFocusEnter;
            SearchTextBox.Leave += OnSearchTextBoxFocusLeave;
            // 
            // SongNameLabel
            // 
            SongNameLabel.AutoSize = true;
            SongNameLabel.Font = new Font("Calibri", 11.25F, FontStyle.Bold);
            SongNameLabel.ForeColor = Color.White;
            SongNameLabel.Location = new Point(88, 23);
            SongNameLabel.Name = "SongNameLabel";
            SongNameLabel.RightToLeft = RightToLeft.No;
            SongNameLabel.Size = new Size(0, 18);
            SongNameLabel.TabIndex = 24;
            SongNameLabel.UseMnemonic = false;
            // 
            // SongInfoLabel
            // 
            SongInfoLabel.AutoSize = true;
            SongInfoLabel.Font = new Font("Calibri", 9F);
            SongInfoLabel.ForeColor = Color.White;
            SongInfoLabel.Location = new Point(88, 43);
            SongInfoLabel.Name = "SongInfoLabel";
            SongInfoLabel.Size = new Size(0, 14);
            SongInfoLabel.TabIndex = 25;
            SongInfoLabel.UseMnemonic = false;
            // 
            // SongList
            // 
            SongList.Font = new Font("Microsoft Sans Serif", 8.25F);
            SongList.Location = new Point(0, 155);
            SongList.Margin = new Padding(4);
            SongList.Name = "SongList";
            SongList.HighlightedSong = null;
            SongList.Size = new Size(927, 315);
            SongList.TabIndex = 26;
            // 
            // AlbumCoverPictureBox
            // 
            AlbumCoverPictureBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            AlbumCoverPictureBox.Location = new Point(10, 25);
            AlbumCoverPictureBox.Name = "AlbumCoverPictureBox";
            AlbumCoverPictureBox.Size = new Size(70, 70);
            AlbumCoverPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            AlbumCoverPictureBox.TabIndex = 27;
            AlbumCoverPictureBox.TabStop = false;
            // 
            // AdvancedSearchButton
            // 
            AdvancedSearchButton.BackColor = Color.Transparent;
            AdvancedSearchButton.Font = new Font("Microsoft Sans Serif", 8.25F);
            AdvancedSearchButton.Image = Properties.Resources.AdvancedSearchOff;
            AdvancedSearchButton.Location = new Point(923, 476);
            AdvancedSearchButton.Name = "AdvancedSearchButton";
            AdvancedSearchButton.Size = new Size(18, 18);
            AdvancedSearchButton.SizeMode = PictureBoxSizeMode.Zoom;
            AdvancedSearchButton.TabIndex = 29;
            AdvancedSearchButton.TabStop = false;
            AdvancedSearchButton.MouseDown += OnAdvancedSearchButtonMouseDown;
            // 
            // MenuStrip
            // 
            MenuStrip.AutoSize = false;
            MenuStrip.BackColor = Color.FromArgb(15, 100, 50);
            MenuStrip.Font = new Font("Segoe UI", 9F);
            MenuStrip.Items.AddRange(new ToolStripItem[] { LyricsButton, ShuffleButton, FilterButton });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(944, 16);
            MenuStrip.TabIndex = 32;
            MenuStrip.MouseDown += OnMenuStripMouseDown;
            // 
            // LyricsButton
            // 
            LyricsButton.AutoSize = false;
            LyricsButton.BackgroundImage = Properties.Resources.Lyrics;
            LyricsButton.BackgroundImageLayout = ImageLayout.Stretch;
            LyricsButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            LyricsButton.Margin = new Padding(5, 0, 0, 0);
            LyricsButton.Name = "LyricsButton";
            LyricsButton.Size = new Size(12, 12);
            LyricsButton.MouseDown += OnLyricsButtonMouseDown;
            // 
            // ShuffleButton
            // 
            ShuffleButton.AutoSize = false;
            ShuffleButton.BackgroundImage = Properties.Resources.ShuffleOff;
            ShuffleButton.BackgroundImageLayout = ImageLayout.Stretch;
            ShuffleButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ShuffleButton.Margin = new Padding(15, 0, 0, 0);
            ShuffleButton.Name = "ShuffleButton";
            ShuffleButton.Size = new Size(12, 12);
            ShuffleButton.MouseDown += OnShuffleButtonMouseDown;
            // 
            // FilterButton
            // 
            FilterButton.AutoSize = false;
            FilterButton.BackgroundImage = Properties.Resources.FilterOn;
            FilterButton.BackgroundImageLayout = ImageLayout.Stretch;
            FilterButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            FilterButton.Margin = new Padding(15, 0, 0, 0);
            FilterButton.Name = "FilterButton";
            FilterButton.Size = new Size(11, 11);
            FilterButton.MouseDown += OnFilterButtonMouseDown;
            // 
            // MainForm
            // 
            BackColor = Color.FromArgb(0, 64, 80);
            ClientSize = new Size(944, 501);
            Controls.Add(AdvancedSearchButton);
            Controls.Add(AlbumCoverPictureBox);
            Controls.Add(SongList);
            Controls.Add(SongInfoLabel);
            Controls.Add(SongNameLabel);
            Controls.Add(SearchTextBox);
            Controls.Add(SongListScrollBar);
            Controls.Add(NextButton);
            Controls.Add(PreviousButton);
            Controls.Add(PlayPauseButton);
            Controls.Add(DurationLabel);
            Controls.Add(CurrentTimeLabel);
            Controls.Add(ProgressBar);
            Controls.Add(ProgressBarBackground);
            Controls.Add(MenuStrip);
            Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MenuStrip;
            MinimumSize = new Size(960, 540);
            Name = "MainForm";
            Text = "SoogbadMusic";
            WindowState = FormWindowState.Maximized;
            FormClosed += OnFormClosed;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)ProgressBarBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProgressBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayPauseButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreviousButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)NextButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)AlbumCoverPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)AdvancedSearchButton).EndInit();
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private PictureButton ProgressBarBackground;
        private PictureButton ProgressBar;
        private System.Windows.Forms.Label CurrentTimeLabel;
        private System.Windows.Forms.Label DurationLabel;
        private PictureButton PlayPauseButton;
        private PictureButton PreviousButton;
        private PictureButton NextButton;
        private System.Windows.Forms.VScrollBar SongListScrollBar;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label SongNameLabel;
        private System.Windows.Forms.Label SongInfoLabel;
        private SongList SongList;
        private System.Windows.Forms.PictureBox AlbumCoverPictureBox;
        private PictureButton AdvancedSearchButton;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem LyricsButton;
        private ToolStripMenuItem ShuffleButton;
        private ToolStripMenuItem FilterButton;
    }
}

