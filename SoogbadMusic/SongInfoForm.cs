using System.Diagnostics;
using TagLib;

namespace SoogbadMusic
{
    public partial class SongInfoForm : Form
    {

        public Song Song { get; private set; }

        public SongInfoForm(Song song)
        {
            InitializeComponent();
            Song = song;
            if(Song.Data.AlbumCover == null || Song.Data.Lyrics == "")
                Song.LoadAlbumCoverAndLyrics();
            Text = "Song Info - " + Song.Path;
            TitleTextBox.Text = Song.Data.Title;
            ArtistTextBox.Text = Song.Data.Artist;
            AlbumTextBox.Text = Song.Data.Album;
            YearTextBox.Text = Song.Data.Year.ToString();
            AlbumCoverPictureButton.Image = Song.Data.AlbumCover;
            LyricsTextBox.Text = Song.Data.Lyrics;
            System.Windows.Forms.Timer timer = new() { Interval = 50 };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private void OnYearTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void OnAlbumCoverPictureButtonMouseClick(object sender, MouseEventArgs e)
        {
            OpenAlbumCoverDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\Album Covers";
            if(e.Button == MouseButtons.Left && OpenAlbumCoverDialog.ShowDialog() == DialogResult.OK)
                AlbumCoverPictureButton.Image = Image.FromFile(OpenAlbumCoverDialog.FileName);
        }
        private void OnTextBoxTextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            textBox.RightToLeft = Utility.ContainsRTLCharacters(textBox.Text) ? RightToLeft.Yes : RightToLeft.No;
        }

        private bool returnToMainThreadToSave = false;
        private void OnSaveButtonMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
                return;
            if(HasMadeChanges())
            {
                SaveButton.Enabled = false;
                LoadingGIFPictureBox.Visible = true;
                ProgressLabel.Text = "Initializing... 0%";
                Utility.RunCommandlineTool("mp3gain", $"/k /r /d 6 \"{Song.Path}\"", OnMP3GainOutputReceived, OnMP3GainProcessExited, true);
            }
            else
            {
                finishedSaving = true;
                Close();
            }
        }
        private string setProgressTextInMainThread = "";
        public void OnMP3GainOutputReceived(object sender, DataReceivedEventArgs e)
        {
            int progress = Utility.GetCommandToolProgressFromOutput(e.Data);
            if(progress >= 0)
            {
                if(e.Data == null || e.Data.Contains("analyz", StringComparison.CurrentCultureIgnoreCase))
                    setProgressTextInMainThread = $"Initializing... {progress}%";
                else
                    setProgressTextInMainThread = $"Normalizing... {progress}%";
            }
        }
        public void OnMP3GainProcessExited(object? sender, Utility.ProcessExitedEventArgs e)
        {
            returnToMainThreadToSave = true;
        }
        private bool callUpdateMainForm = false;
        private long saveStartTime = -1;
        private void SaveDataToFile()
        {
            TagLib.File file = TagLib.File.Create(Song.Path);
            file = Utility.RemoveAllTags(file, false);
            TagLib.Id3v2.Tag tag = (TagLib.Id3v2.Tag)file.GetTag(TagTypes.Id3v2, true);
            tag.Title = TitleTextBox.Text == "" ? null : TitleTextBox.Text;
            tag.AlbumArtists = ArtistTextBox.Text == "" ? [] : [ArtistTextBox.Text];
            tag.Performers = tag.AlbumArtists;
            tag.Album = AlbumTextBox.Text == "" ? null : AlbumTextBox.Text;
            tag.Year = YearTextBox.Text == "" ? 0 : uint.Parse(YearTextBox.Text);
            tag.Pictures = AlbumCoverPictureButton.Image == null ? [] : [new Picture(new ByteVector((byte[]?)new ImageConverter().ConvertTo(AlbumCoverPictureButton.Image, typeof(byte[]))))];
            tag.Lyrics = LyricsTextBox.Text == "" ? null : LyricsTextBox.Text;
            saveStartTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            ProgressLabel.Text = "Saving... 0%";
            Utility.SaveFileTag(file, (sender, e) => { callUpdateMainForm = true; }, false);
        }

        private bool finishedSaving = false;
        private void OnCancelButtonMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                Close();
        }
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if(finishedSaving)
                e.Cancel = false;
            else
            {
                if(!HasMadeChanges())
                    e.Cancel = false;
                else if(new ExitDialog().ShowDialog() == DialogResult.OK)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        private double previousCurrentTime = 0;
        private bool wasPlaying = false, wasPaused = false;
        private void GetMainFormData()
        {
            if(PlaybackManager.Player != null && PlaybackManager.Player.Song == Song)
            {
                wasPlaying = true;
                wasPaused = PlaybackManager.Player.Paused;
                previousCurrentTime = PlaybackManager.Player.CurrentTime;
                PlaybackManager.Player.Stop();
                PlaybackManager.Player = null;
            }
        }

        private void UpdateMainForm()
        {
            int songIndex = Playlist.Songs.IndexOf(Song);
            Playlist.Songs[songIndex].RefreshData();
            if(wasPlaying)
            {
                PlaybackManager.Player = new Player(Playlist.Songs[songIndex]) { CurrentTime = previousCurrentTime };
                PlaybackManager.Player.PlaybackStopped += PlaybackManager.OnPlaybackStopped;
                if(!wasPaused)
                    PlaybackManager.Player.Play();
                PlaybackManager.RaiseSongChanged();
            }
            Utility.GetMainForm()?.RefreshSongList();
            finishedSaving = true;
            Close();
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            if(returnToMainThreadToSave)
            {
                returnToMainThreadToSave = false;
                GetMainFormData();
                SaveDataToFile();
            }
            if(callUpdateMainForm)
            {
                callUpdateMainForm = false;
                ProgressLabel.Text = "Saving... 100%";
                UpdateMainForm();
            }
            if(!string.IsNullOrEmpty(setProgressTextInMainThread))
            {
                ProgressLabel.Text = setProgressTextInMainThread;
                setProgressTextInMainThread = "";
            }
            if(saveStartTime > 0)
            {
                int progress = (int)Math.Round((DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - saveStartTime) / 5000.0 * 100);
                ProgressLabel.Text = $"Saving... {progress}%";
            }
        }

        private bool HasMadeChanges()
        {
            return TitleTextBox.Text != Song.Data.Title || ArtistTextBox.Text != Song.Data.Artist || AlbumTextBox.Text != Song.Data.Album || YearTextBox.Text != Song.Data.Year.ToString() || AlbumCoverPictureButton.Image != Song.Data.AlbumCover || LyricsTextBox.Text != Song.Data.Lyrics;
        }

        public static bool WindowExists(Song song)
        {
            foreach(Form form in Application.OpenForms)
                if(form.Text == "Song Info - " + song.Path)
                    return true;
            return false;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Utility.SetWindowTitleBarColor(Handle);
        }

    }

}
