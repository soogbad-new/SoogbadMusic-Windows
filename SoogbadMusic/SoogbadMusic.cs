using SoogbadMusic.Properties;
using Windows.Media;
using Windows.Media.Playback;
using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using SoogbadMusic.Resources;

namespace SoogbadMusic
{

    public partial class SoogbadMusic : Resources.ResponsiveForm
    {

        private SystemMediaTransportControls systemControls = null;
        private bool songReady = true;
        private bool advancedSearch = false;

        public SoogbadMusic()
        {
            InitializeComponent();
            BlacklistControlWidth(ProgressBar);
            BlacklistControlLeft(DurationLabel);
            BlacklistControlWidth(SongListScrollBar);
            BlacklistControlLeft(SongListScrollBar);
            BlacklistControlWidth(SongList);
            BlacklistControlTop(SearchTextBox);
            List<Control> labels = SongList.GetLabels();
            AddInvisibleControls(labels);
            foreach(Control label in labels)
                if(label.Name.Contains("Duration"))
                    BlacklistControlLeft(label);
            Playlist.Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            Playlist.RefreshSongs();
            PlayerManager.SongChanged += OnSongChanged;
            PlayerManager.PausedValueChanged += OnPausedValueChanged;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = 10 };
            timer.Tick += OnTimerTick;
            timer.Start();
            ResponsiveClientSizeChanged += OnResponsiveClientSizeChanged;
            SongList.MouseWheel += OnSongListMouseWheel;
            SetOnControlMouseUpEvents(this);
        }
        private void SetOnControlMouseUpEvents(Control control)
        {
            control.MouseUp += OnControlMouseUp;
            foreach(Control c in control.Controls)
                if(control.Name != "SearchTextBox")
                    SetOnControlMouseUpEvents(c);
        }

        bool requestPrevious = false, requestNext = false;
        private void OnSystemControlsButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs e)
        {
            if(e.Button == SystemMediaTransportControlsButton.Play)
                PlayerManager.Paused = false;
            else if(e.Button == SystemMediaTransportControlsButton.Pause)
                PlayerManager.Paused = true;
            else if(e.Button == SystemMediaTransportControlsButton.Previous)
                requestPrevious = true;
            else if(e.Button == SystemMediaTransportControlsButton.Next)
                requestNext = true;
            else if(e.Button == SystemMediaTransportControlsButton.Stop)
                Environment.Exit(0);
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

        private void OnTimerTick(object sender, EventArgs e)
        {
            DurationLabel.Left = ClientSize.Width - DurationLabel.Width - 5;
            SearchTextBox.Top = (int)Math.Round(SongList.Top + SongList.Height + 0.5 * (ClientSize.Height - (SongList.Top + SongList.Height)) - 0.5 * SearchTextBox.Height);
            UpdateProgressBar();
            if(Playlist.RefreshSongsComplete)
            {
                Playlist.RefreshSongsComplete = false;
                Playlist.RefreshSongsProgress = 0;
                PlayPauseButton.Enabled = true; PreviousButton.Enabled = true; NextButton.Enabled = true; SearchTextBox.Enabled = true;
                SongListScrollBar.Maximum = Playlist.Songs.Count - 8;
                SongList.ChangeIndex(0);
                SearchTextBox.Font = new Font(SearchTextBox.Font, FontStyle.Italic);
                SearchTextBox.ForeColor = Color.LightGray;
                SearchTextBox.Text = "Search " + Playlist.Songs.Count + " Songs";
            }
            if(requestPrevious)
            {
                requestPrevious = false;
                PlayerManager.PreviousSong();
            }
            if(requestNext)
            {
                requestNext = false;
                PlayerManager.NextSong();
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
                CurrentTimeLabel.Text = "";
                DurationLabel.Text = "";
                if(ProgressBar.Width <= ClientSize.Width)
                    ProgressBar.Width = (int)Math.Round(refreshProgress * ClientSize.Width);
            }
            else if(PlayerManager.Player != null)
            {
                ProgressBar.Visible = true;
                if(ProgressBar.Width <= ClientSize.Width)
                {
                    int width = (int)Math.Round(PlayerManager.Player.CurrentTime / PlayerManager.Player.Song.Duration * ClientSize.Width);
                    ProgressBar.Width = width == 0 ? 1 : width;
                    CurrentTimeLabel.Text = Utility.FormatTime(PlayerManager.Player.CurrentTime);
                    DurationLabel.Text = Utility.FormatTime(PlayerManager.Player.Song.Duration);
                }
            }
            else
            {
                ProgressBar.Visible = false;
                CurrentTimeLabel.Text = "";
                DurationLabel.Text = "";
            }
        }

        private void OnSongChanged()
        {
            AlbumCoverPictureBox.Select();
            SearchTextBox.Font = new Font(SearchTextBox.Font, FontStyle.Italic);
            SearchTextBox.ForeColor = Color.LightGray;
            SearchTextBox.Text = "Search " + Playlist.Songs.Count + " Songs";
            ProgressBar.Width = 1;
            SongList.SelectedSong = PlayerManager.Player.Song;
            if(!SongList.IsOnScreen(PlayerManager.Player.Song))
                SongListScrollBar.Value = Math.Min(Playlist.Songs.IndexOf(PlayerManager.Player.Song), SongListScrollBar.Maximum);
            else
                SongList.ChangeIndex(SongList.Index);
            SongNameLabel.Text = PlayerManager.Player.Song.Data.Artist + " - " + PlayerManager.Player.Song.Data.Title;
            SongInfoLabel.Text = PlayerManager.Player.Song.Data.Album + " (" + PlayerManager.Player.Song.Data.Year.ToString() + ")";
            AlbumCoverPictureBox.Image = PlayerManager.Player.Song.Data.AlbumCover;
            SongNameLabel.Update();
            SongInfoLabel.Update();
            AlbumCoverPictureBox.Update();
            ShortenLabelsText();
            if(systemControls == null)
            {
                systemControls = BackgroundMediaPlayer.Current.SystemMediaTransportControls;
                systemControls.ButtonPressed += OnSystemControlsButtonPressed;
                systemControls.IsPlayEnabled = true; systemControls.IsPauseEnabled = true; systemControls.IsPreviousEnabled = true; systemControls.IsNextEnabled = true;
            }
            UpdateSystemControlsData();
            songReady = true;
        }
        private async void UpdateSystemControlsData()
        {
            systemControls.DisplayUpdater.Type = MediaPlaybackType.Music;
            systemControls.DisplayUpdater.MusicProperties.Artist = PlayerManager.Player.Song.Data.Artist;
            systemControls.DisplayUpdater.MusicProperties.AlbumArtist = PlayerManager.Player.Song.Data.Artist;
            systemControls.DisplayUpdater.MusicProperties.Title = PlayerManager.Player.Song.Data.Title;
            systemControls.DisplayUpdater.MusicProperties.AlbumTitle = PlayerManager.Player.Song.Data.Album;
            if(PlayerManager.Player.Song.Data.AlbumCover != null)
            {
                string tempFolder = Path.GetTempPath() + "\\SoogbadMusic";
                if(!Directory.Exists(tempFolder))
                    Directory.CreateDirectory(tempFolder);
                PlayerManager.Player.Song.Data.AlbumCover.Save(tempFolder + "\\thumb.png");
                systemControls.DisplayUpdater.Thumbnail = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(await Windows.Storage.StorageFile.GetFileFromPathAsync(tempFolder + "\\thumb.png"));
            }
            systemControls.DisplayUpdater.Update();
        }

        private void ShortenLabelsText()
        {
            ShortenLabelText(SongNameLabel, PlayerManager.Player != null ? PlayerManager.Player.Song.Data.Artist + " - " + PlayerManager.Player.Song.Data.Title : "");
            ShortenLabelText(SongInfoLabel, PlayerManager.Player != null ? PlayerManager.Player.Song.Data.Album + " (" + PlayerManager.Player.Song.Data.Year.ToString() + ")" : "");
        }
        private void ShortenLabelText(Label label, string fullText)
        {
            label.Text = fullText;
            for(int i = 1; ; i++)
            {
                if(label.Left + label.Width <= PreviousButton.Left - 25)
                    break;
                label.Text = fullText.Remove(fullText.Length - i) + "...";
            }
        }


        private void OnShuffleButtonMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                PlayerManager.Shuffle = !PlayerManager.Shuffle;
                if(PlayerManager.Shuffle)
                    ShuffleButton.Image = Properties.Resources.ShuffleOn;
                else
                    ShuffleButton.Image = Properties.Resources.ShuffleOff;
            }
        }
        private void OnFilterButtonMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                PlayerManager.Filter = !PlayerManager.Filter;
                if(PlayerManager.Filter)
                    FilterButton.Image = Properties.Resources.FilterOn;
                else
                    FilterButton.Image = Properties.Resources.FilterOff;
                SongListScrollBar.Value = 0;
                SongList.SelectedSong = null;
                Playlist.RefreshSongs();
            }
        }

        private void OnPlayPauseButtonMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                PlayerManager.Paused = !PlayerManager.Paused;
        }
        private void OnPausedValueChanged()
        {
            PlayPauseButton.Image = PlayerManager.Paused ? Properties.Resources.Play : Properties.Resources.Pause;
            systemControls.PlaybackStatus = PlayerManager.Paused ? MediaPlaybackStatus.Paused : MediaPlaybackStatus.Playing;
        }

        private void OnNextButtonMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && songReady)
            {
                songReady = false;
                PlayerManager.NextSong();
            }
        }
        private void OnPreviousButtonMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && songReady)
            {
                songReady = false;
                PlayerManager.PreviousSong();
            }
        }

        private void OnProgressBarBackgroundMouseDown(object sender, MouseEventArgs e)
        {
            ChangeTime(e);
        }
        private void OnProgressBarMouseDown(object sender, MouseEventArgs e)
        {
            ChangeTime(e);
        }
        private void ChangeTime(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && PlayerManager.Player != null && !Playlist.IsAccessingRefreshSongsProgress && Playlist.RefreshSongsProgress == 0)
            {
                double time = (double)e.X / ClientSize.Width * PlayerManager.Player.Song.Duration;
                if(time > PlayerManager.Player.Song.Duration - 1)
                    time = PlayerManager.Player.Song.Duration - 1;
                if(time < 0)
                    time = 0;
                if(PlayerManager.Player.Stopped)
                    PlayerManager.SwitchSong(PlayerManager.Player.Song);
                PlayerManager.Player.CurrentTime = time;
            }
        }


        private void OnSongListScrollBarValueChanged(object sender, EventArgs e)
        {
            SongList.ChangeIndex(SongListScrollBar.Value);
        }
        private void OnSongListMouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta < 0 && SongListScrollBar.Value < SongListScrollBar.Maximum)
                SongListScrollBar.Value++;
            else if(e.Delta > 0 && SongListScrollBar.Value > SongListScrollBar.Minimum)
                SongListScrollBar.Value--;
        }

        private void OnSearchTextBoxTextChanged(object sender, EventArgs e)
        {
            if(SearchTextBox.Text == "" || SearchTextBox.Font.Italic)
            {
                if(!SongList.IsSongListNull())
                {
                    SongList.ChangeSongList(null);
                    SongListScrollBar.Maximum = Playlist.Songs.Count - 8;
                    if(PlayerManager.Player != null && !SongList.IsOnScreen(PlayerManager.Player.Song))
                        SongListScrollBar.Value = Math.Min(Playlist.Songs.IndexOf(PlayerManager.Player.Song), SongListScrollBar.Maximum);
                }
            }
            else
            {
                List<Song> songs = new List<Song>();
                foreach(Song song in Playlist.Songs)
                    if(song.Data.Contains(SearchTextBox.Text, advancedSearch))
                        songs.Add(song);
                SongList.ChangeSongList(songs);
                int maximum = songs.Count - 8;
                if(maximum < 0)
                    maximum = 0;
                SongListScrollBar.Maximum = maximum;
            }
        }
        private void OnControlMouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                ((Control)sender).Select();
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

        private void OnLyricsPictureButtonMouseDown(object sender, MouseEventArgs e)
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

        private void OnAdvancedSearchButtonMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                advancedSearch = !advancedSearch;
                if(advancedSearch)
                    AdvancedSearchButton.Image = Properties.Resources.AdvancedSearchOn;
                else
                    AdvancedSearchButton.Image = Properties.Resources.AdvancedSearchOff;
            }
        }

        public SongList GetSongList()
        {
            return SongList;
        }

        private void SoogbadMusic_Load(object sender, EventArgs e)
        {

        }

    }

}
