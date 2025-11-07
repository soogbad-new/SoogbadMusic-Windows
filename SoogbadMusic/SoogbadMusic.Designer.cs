using SoogbadMusic.Resources;

namespace SoogbadMusic
{
    partial class SoogbadMusic
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
            if(PlayerManager.Player != null)
                PlayerManager.Player.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoogbadMusic));
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
            SongList = new SongList();
            AlbumCoverPictureBox = new PictureBox();
            LyricsPictureButton = new PictureButton();
            AdvancedSearchButton = new PictureButton();
            ShuffleButton = new PictureButton();
            pictureButton1 = new PictureButton();
            FilterButton = new PictureButton();
            pictureButton2 = new PictureButton();
            ((System.ComponentModel.ISupportInitialize)ProgressBarBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProgressBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayPauseButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreviousButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NextButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AlbumCoverPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LyricsPictureButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AdvancedSearchButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShuffleButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureButton1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FilterButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureButton2).BeginInit();
            SuspendLayout();
            // 
            // ProgressBarBackground
            // 
            ProgressBarBackground.BackColor = Color.Black;
            ProgressBarBackground.Font = new Font("Microsoft Sans Serif", 8.25F);
            ProgressBarBackground.Location = new Point(0, 75);
            ProgressBarBackground.Name = "ProgressBarBackground";
            ProgressBarBackground.Size = new Size(944, 35);
            ProgressBarBackground.SizeMode = PictureBoxSizeMode.Zoom;
            ProgressBarBackground.TabIndex = 3;
            ProgressBarBackground.TabStop = false;
            ProgressBarBackground.MouseDown += OnProgressBarBackgroundMouseDown;
            // 
            // ProgressBar
            // 
            ProgressBar.BackColor = Color.FromArgb(20, 115, 60);
            ProgressBar.Font = new Font("Microsoft Sans Serif", 8.25F);
            ProgressBar.Location = new Point(0, 75);
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
            CurrentTimeLabel.Location = new Point(5, 58);
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
            DurationLabel.Location = new Point(911, 58);
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
            PlayPauseButton.Location = new Point(462, 27);
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
            PreviousButton.Location = new Point(411, 27);
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
            NextButton.Location = new Point(512, 27);
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
            SongListScrollBar.Location = new Point(927, 110);
            SongListScrollBar.Maximum = 0;
            SongListScrollBar.Name = "SongListScrollBar";
            SongListScrollBar.Size = new Size(17, 360);
            SongListScrollBar.TabIndex = 14;
            SongListScrollBar.ValueChanged += OnSongListScrollBarValueChanged;
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
            SearchTextBox.Size = new Size(917, 22);
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
            SongNameLabel.Location = new Point(113, 5);
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
            SongInfoLabel.Location = new Point(113, 25);
            SongInfoLabel.Name = "SongInfoLabel";
            SongInfoLabel.Size = new Size(0, 14);
            SongInfoLabel.TabIndex = 25;
            SongInfoLabel.UseMnemonic = false;
            // 
            // SongList
            // 
            SongList.Font = new Font("Microsoft Sans Serif", 8.25F);
            SongList.Location = new Point(0, 110);
            SongList.Margin = new Padding(4);
            SongList.Name = "SongList";
            SongList.SelectedSong = null;
            SongList.Size = new Size(927, 360);
            SongList.TabIndex = 26;
            // 
            // AlbumCoverPictureBox
            // 
            AlbumCoverPictureBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            AlbumCoverPictureBox.Location = new Point(45, 7);
            AlbumCoverPictureBox.Name = "AlbumCoverPictureBox";
            AlbumCoverPictureBox.Size = new Size(60, 60);
            AlbumCoverPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            AlbumCoverPictureBox.TabIndex = 27;
            AlbumCoverPictureBox.TabStop = false;
            // 
            // LyricsPictureButton
            // 
            LyricsPictureButton.BackColor = Color.FromArgb(0, 48, 64);
            LyricsPictureButton.BorderStyle = BorderStyle.FixedSingle;
            LyricsPictureButton.Font = new Font("Microsoft Sans Serif", 8.25F);
            LyricsPictureButton.Image = Properties.Resources.Lyrics;
            LyricsPictureButton.Location = new Point(0, 0);
            LyricsPictureButton.Name = "LyricsPictureButton";
            LyricsPictureButton.Size = new Size(25, 25);
            LyricsPictureButton.SizeMode = PictureBoxSizeMode.Zoom;
            LyricsPictureButton.TabIndex = 28;
            LyricsPictureButton.TabStop = false;
            LyricsPictureButton.MouseDown += OnLyricsPictureButtonMouseDown;
            // 
            // AdvancedSearchButton
            // 
            AdvancedSearchButton.BackColor = Color.Transparent;
            AdvancedSearchButton.Font = new Font("Microsoft Sans Serif", 8.25F);
            AdvancedSearchButton.Image = Properties.Resources.AdvancedSearchOff;
            AdvancedSearchButton.Location = new Point(921, 476);
            AdvancedSearchButton.Name = "AdvancedSearchButton";
            AdvancedSearchButton.Size = new Size(20, 20);
            AdvancedSearchButton.SizeMode = PictureBoxSizeMode.Zoom;
            AdvancedSearchButton.TabIndex = 29;
            AdvancedSearchButton.TabStop = false;
            AdvancedSearchButton.MouseDown += OnAdvancedSearchButtonMouseDown;
            // 
            // ShuffleButton
            // 
            ShuffleButton.BackColor = Color.Transparent;
            ShuffleButton.Font = new Font("Microsoft Sans Serif", 8.25F);
            ShuffleButton.Image = Properties.Resources.ShuffleOff;
            ShuffleButton.Location = new Point(854, 27);
            ShuffleButton.Name = "ShuffleButton";
            ShuffleButton.Size = new Size(21, 21);
            ShuffleButton.SizeMode = PictureBoxSizeMode.Zoom;
            ShuffleButton.TabIndex = 30;
            ShuffleButton.TabStop = false;
            ShuffleButton.MouseDown += OnShuffleButtonMouseDown;
            // 
            // pictureButton1
            // 
            pictureButton1.BackColor = Color.Transparent;
            pictureButton1.Enabled = false;
            pictureButton1.Font = new Font("Microsoft Sans Serif", 8.25F);
            pictureButton1.Location = new Point(854, 27);
            pictureButton1.Name = "pictureButton1";
            pictureButton1.Size = new Size(21, 21);
            pictureButton1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureButton1.TabIndex = 30;
            pictureButton1.TabStop = false;
            // 
            // FilterButton
            // 
            FilterButton.BackColor = Color.Transparent;
            FilterButton.Font = new Font("Microsoft Sans Serif", 8.25F);
            FilterButton.Image = Properties.Resources.FilterOn;
            FilterButton.Location = new Point(812, 27);
            FilterButton.Name = "FilterButton";
            FilterButton.Size = new Size(21, 21);
            FilterButton.SizeMode = PictureBoxSizeMode.Zoom;
            FilterButton.TabIndex = 31;
            FilterButton.TabStop = false;
            FilterButton.MouseDown += OnFilterButtonMouseDown;
            // 
            // pictureButton2
            // 
            pictureButton2.BackColor = Color.Transparent;
            pictureButton2.Enabled = false;
            pictureButton2.Font = new Font("Microsoft Sans Serif", 8.25F);
            pictureButton2.Image = Properties.Resources.ShuffleOff;
            pictureButton2.Location = new Point(812, 27);
            pictureButton2.Name = "pictureButton2";
            pictureButton2.Size = new Size(21, 21);
            pictureButton2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureButton2.TabIndex = 31;
            pictureButton2.TabStop = false;
            // 
            // SoogbadMusic
            // 
            BackColor = Color.FromArgb(0, 64, 80);
            ClientSize = new Size(944, 501);
            Controls.Add(FilterButton);
            Controls.Add(ShuffleButton);
            Controls.Add(AdvancedSearchButton);
            Controls.Add(LyricsPictureButton);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(960, 540);
            Name = "SoogbadMusic";
            Text = "SoogbadMusic";
            WindowState = FormWindowState.Maximized;
            FormClosed += OnFormClosed;
            Load += SoogbadMusic_Load;
            ((System.ComponentModel.ISupportInitialize)ProgressBarBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProgressBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayPauseButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreviousButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)NextButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)AlbumCoverPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)LyricsPictureButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)AdvancedSearchButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShuffleButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureButton1).EndInit();
            ((System.ComponentModel.ISupportInitialize)FilterButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureButton2).EndInit();
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
        private PictureButton LyricsPictureButton;
        private PictureButton AdvancedSearchButton;
        private PictureButton ShuffleButton;
        private PictureButton pictureButton1;
        private PictureButton FilterButton;
        private PictureButton pictureButton2;
    }
}

