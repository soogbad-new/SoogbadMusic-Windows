using System.Runtime.InteropServices;

namespace SoogbadMusic
{

    public partial class MainForm : ResponsiveForm
    {

        private bool songReady = true;
        private bool advancedSearch = false;

        public MainForm()
        {
            InitializeComponent();
            BlacklistControlTop(SearchTextBox);
            BlacklistControlWidth(ProgressBar); BlacklistControlWidth(SongListScrollBar); BlacklistControlWidth(SongList);
            BlacklistControlLeft(SongListScrollBar); BlacklistControlLeft(DurationLabel);
            List<Control>? labels = SongList.GetLabels();
            AddInvisibleControls(labels);
            if(labels != null)
                foreach(Control label in labels)
                    if(label.Name.Contains("Duration"))
                        BlacklistControlLeft(label);
            CurrentTimeLabel.Text = ""; DurationLabel.Text = "";
            SongList.SetScrollBar(SongListScrollBar);
            MenuStrip.Renderer = new Utility.NoHighlightToolStripRenderer();
            AddInvisibleToolStripMenuItems([.. MenuStrip.Items.Cast<ToolStripMenuItem>()]);
            Playlist.Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            Playlist.RefreshSongs();
            PlaybackManager.SongChanged += OnSongChanged;
            PlaybackManager.PausedValueChanged += OnPausedValueChanged;
            System.Windows.Forms.Timer timer = new() { Interval = 10 };
            timer.Tick += OnTimerTick;
            timer.Start();
            ResponsiveClientSizeChanged += OnResponsiveClientSizeChanged;
            SetOnControlMouseUpEvents(this);
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            DurationLabel.Left = ClientSize.Width - DurationLabel.Width - 5;
            SearchTextBox.Top = (int)Math.Round(SongList.Top + SongList.Height + 0.5 * (ClientSize.Height - (SongList.Top + SongList.Height)) - 0.5 * SearchTextBox.Height);
            UpdateProgressBar();
            if(Playlist.RefreshSongsComplete)
                OnRefreshSongsComplete();
            if(PlaybackManager.RequestPreviousSongFromMainThread)
            {
                PlaybackManager.RequestPreviousSongFromMainThread = false;
                PlaybackManager.PreviousSong();
            }
            if(PlaybackManager.RequestNextSongFromMainThread)
            {
                PlaybackManager.RequestNextSongFromMainThread = false;
                PlaybackManager.NextSong();
            }
        }
        private void UpdateProgressBar()
        {
            if(Playlist.IsAccessingRefreshSongsProgress)
                return;
            double refreshProgress = Playlist.RefreshSongsProgress;
            if(refreshProgress > 0)
            {
                ProgressBar.Visible = true;
                CurrentTimeLabel.Text = ""; DurationLabel.Text = "";
                if(ProgressBar.Width <= ClientSize.Width)
                    ProgressBar.Width = (int)Math.Round(refreshProgress * ClientSize.Width);
            }
            else if(PlaybackManager.Player != null)
            {
                ProgressBar.Visible = true;
                if(ProgressBar.Width <= ClientSize.Width)
                {
                    int width = (int)Math.Round(PlaybackManager.Player.CurrentTime / PlaybackManager.Player.Song.Duration * ClientSize.Width);
                    ProgressBar.Width = width == 0 ? 1 : width;
                    CurrentTimeLabel.Text = Utility.FormatTime(PlaybackManager.Player.CurrentTime);
                    DurationLabel.Text = Utility.FormatTime(PlaybackManager.Player.Song.Duration);
                }
            }
            else
            {
                ProgressBar.Visible = false;
                CurrentTimeLabel.Text = ""; DurationLabel.Text = "";
            }
        }
        private void OnRefreshSongsComplete()
        {
            Playlist.RefreshSongsComplete = false;
            Playlist.RefreshSongsProgress = 0;
            PlayPauseButton.Enabled = true; PreviousButton.Enabled = true; NextButton.Enabled = true; SearchTextBox.Enabled = true;
            SongList.SetScrollBarMaximum(Playlist.Songs.Count);
            SongList.ChangeIndex(0, 0);
            SearchTextBox.Font = new Font(SearchTextBox.Font, FontStyle.Italic);
            SearchTextBox.ForeColor = Color.LightGray;
            SearchTextBox.Text = "Search " + Playlist.Songs.Count + " Songs";
        }

        private void OnSongChanged()
        {
            if(PlaybackManager.Player == null)
                return;
            AlbumCoverPictureBox.Select();
            SearchTextBox.Font = new Font(SearchTextBox.Font, FontStyle.Italic);
            SearchTextBox.ForeColor = Color.LightGray;
            SearchTextBox.Text = "Search " + Playlist.Songs.Count + " Songs";
            ProgressBar.Width = 1;
            ScrollToSong(PlaybackManager.Player.Song);
            SongNameLabel.Text = PlaybackManager.Player.Song.Data.Artist + " - " + PlaybackManager.Player.Song.Data.Title;
            SongInfoLabel.Text = PlaybackManager.Player.Song.Data.Album + " (" + PlaybackManager.Player.Song.Data.Year.ToString() + ")";
            AlbumCoverPictureBox.Image = PlaybackManager.Player.Song.Data.AlbumCover;
            SongNameLabel.Update(); SongInfoLabel.Update(); AlbumCoverPictureBox.Update();
            ShortenLabelsText();
            songReady = true;
        }

        private void OnProgressBarBackgroundMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                ChangeTime(e.X);
        }
        private void OnProgressBarMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                ChangeTime(e.X);
        }
        private void ChangeTime(int posX)
        {
            if(PlaybackManager.Player != null && !Playlist.IsAccessingRefreshSongsProgress && Playlist.RefreshSongsProgress == 0)
            {
                double time = (double)posX / ClientSize.Width * PlaybackManager.Player.Song.Duration;
                if(time > PlaybackManager.Player.Song.Duration - 1)
                    time = PlaybackManager.Player.Song.Duration - 1;
                if(time < 0)
                    time = 0;
                if(PlaybackManager.Player.Stopped)
                    PlaybackManager.SwitchSong(PlaybackManager.Player.Song);
                PlaybackManager.Player.CurrentTime = time;
            }
        }

        private void OnShuffleButtonMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                PlaybackManager.Shuffle = !PlaybackManager.Shuffle;
                if(PlaybackManager.Shuffle)
                    ShuffleButton.BackgroundImage = Properties.Resources.ShuffleOn;
                else
                    ShuffleButton.BackgroundImage = Properties.Resources.ShuffleOff;
            }
        }
        private void OnFilterButtonMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                PlaybackManager.Filter = !PlaybackManager.Filter;
                if(PlaybackManager.Filter)
                    FilterButton.BackgroundImage = Properties.Resources.FilterOn;
                else
                    FilterButton.BackgroundImage = Properties.Resources.FilterOff;
                SongList.HighlightedSong = null;
                Playlist.RefreshSongs();
            }
        }
        private void OnDownloadButtonMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                new DownloadSongForm().Show();
        }

        private void OnPlayPauseButtonMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                PlaybackManager.Paused = !PlaybackManager.Paused;
        }
        private void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && !e.Control && !e.Alt && !e.Shift)
            {
                e.Handled = true;
                PlaybackManager.Paused = !PlaybackManager.Paused;
            }
        }
        private void OnPausedValueChanged()
        {
            PlayPauseButton.Image = PlaybackManager.Paused ? Properties.Resources.Play : Properties.Resources.Pause;
        }

        private void OnPreviousButtonMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && songReady)
            {
                songReady = false;
                PlaybackManager.PreviousSong();
            }
        }
        private void OnNextButtonMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && songReady)
            {
                songReady = false;
                PlaybackManager.NextSong();
            }
        }

        private void OnSearchTextBoxTextChanged(object? sender, EventArgs? e)
        {
            if(SearchTextBox.Text == "" || SearchTextBox.Font.Italic)
            {
                if(SongList.TempSongList != null)
                {
                    Playlist.Songs.Sort(new SongComparer());
                    SongList.TempSongList = null;
                    SongList.SetScrollBarMaximum(Playlist.Songs.Count);
                    if(PlaybackManager.Player != null)
                        SongList.SetScrollBarValue(Playlist.Songs.IndexOf(PlaybackManager.Player.Song));
                }
            }
            else
            {
                List<Song> songs = [];
                foreach(Song song in Playlist.Songs)
                    if(song.Data.Contains(SearchTextBox.Text, advancedSearch))
                        songs.Add(song);
                songs.Sort(new SongComparer());
                SongList.TempSongList = songs;
                SongList.SetScrollBarMaximum(songs.Count);
                SongList.ChangeIndex(0, 0);
            }
        }
        private void OnSearchTextBoxFocusEnter(object sender, EventArgs e)
        {
            if(SearchTextBox.Font.Italic)
            {
                SearchTextBox.Font = new Font(SearchTextBox.Font, FontStyle.Regular);
                SearchTextBox.ForeColor = Color.White;
                SearchTextBox.Text = "";
            }
        }
        private void OnSearchTextBoxFocusLeave(object sender, EventArgs e)
        {
            if(SearchTextBox.Text == "")
            {
                SearchTextBox.Font = new Font(SearchTextBox.Font, FontStyle.Italic);
                SearchTextBox.ForeColor = Color.LightGray;
                SearchTextBox.Text = "Search " + Playlist.Songs.Count + " Songs";
            }
        }

        private void OnLyricsButtonMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                bool exists = false;
                foreach(Form form in Application.OpenForms)
                    if(form is LyricsForm)
                    {
                        exists = true;
                        form.WindowState = FormWindowState.Maximized;
                    }
                if(!exists)
                    new LyricsForm().Show();
            }
        }

        private void OnAdvancedSearchButtonMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                advancedSearch = !advancedSearch;
                if(advancedSearch)
                    AdvancedSearchButton.Image = Properties.Resources.AdvancedSearchOn;
                else
                    AdvancedSearchButton.Image = Properties.Resources.AdvancedSearchOff;
                OnSearchTextBoxTextChanged(null, null);
            }
        }


        public void RefreshSongList()
        {
            if(SongList.TempSongList == null)
                Playlist.Songs.Sort(new SongComparer());
            else
                SongList.TempSongList.Sort(new SongComparer());
            SongList.ChangeIndex(SongList.Index, SongList.ScrollPixelsOffset);
        }
        public void ScrollToSong(Song song)
        {
            SongList.HighlightedSong = song;
            if(!SongList.IsOnScreen(song))
                SongList.SetScrollBarValue(Playlist.Songs.IndexOf(song));
            else
                SongList.ChangeIndex(SongList.Index, SongList.ScrollPixelsOffset);
        }

        private void ShortenLabelsText()
        {
            Utility.ShortenLabelText(SongNameLabel, PlaybackManager.Player != null ? PlaybackManager.Player.Song.Data.Artist + " - " + PlaybackManager.Player.Song.Data.Title : "", ClientSize.Width - 50);
            Utility.ShortenLabelText(SongInfoLabel, PlaybackManager.Player != null ? PlaybackManager.Player.Song.Data.Album + " (" + PlaybackManager.Player.Song.Data.Year.ToString() + ")" : "", ClientSize.Width - 50);
        }

        private void SetOnControlMouseUpEvents(Control control)
        {
            control.MouseUp += OnControlMouseUp;
            foreach(Control c in control.Controls)
                if(control.Name != "SearchTextBox")
                    SetOnControlMouseUpEvents(c);
        }
        private void OnControlMouseUp(object? sender, MouseEventArgs e)
        {
            if(sender != null && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
                ((Control)sender).Select();
        }

        bool closed = false;
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if(!closed)
            {
                closed = true;
                Environment.Exit(0);
            }
        }

        private void OnResponsiveClientSizeChanged()
        {
            if(WindowState == FormWindowState.Minimized)
                return;
            SongListScrollBar.Left = ClientSize.Width - SongListScrollBar.Width;
            SongList.Width = ClientSize.Width - SongListScrollBar.Width;
            ShortenLabelsText();
        }

        [DllImport("user32.dll")]
        private static extern void ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1, HTCAPTION = 0x2;
        public void OnMenuStripMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                _ = SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); // Allow dragging the window by the menu strip
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Utility.SetWindowTitleBarColor(Handle);
        }

    }

}
