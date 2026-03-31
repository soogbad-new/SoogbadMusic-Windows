using System.Diagnostics;
using TagLib;

namespace SoogbadMusic
{
    public partial class SongInfoForm : ResponsiveForm
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
            YearTextBox.Text = Song.Data.Year == 0 ? "" : Song.Data.Year.ToString();
            AlbumCoverPictureButton.Image = Song.Data.AlbumCover;
            LyricsTextBox.Text = Song.Data.Lyrics;
            System.Windows.Forms.Timer timer = new() { Interval = 50 };
            timer.Tick += OnTimerTick;
            timer.Start();
            LocationChanged += OnLocationChanged;
            BlacklistControlTop(LoadingGIFPictureBox); BlacklistControlLeft(LoadingGIFPictureBox); BlacklistControlTop(ProgressLabel); BlacklistControlLeft(ProgressLabel);
            ResponsiveClientSizeChanged += OnResponsiveClientSizeChanged;
            StartPosition = FormStartPosition.CenterScreen;
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

        private bool returnToMainThreadToSave = false;
        private string setProgressTextInMainThread = "";
        private bool callUpdateMainForm = false;
        private void OnSaveButtonMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
                return;
            if(HasMadeChanges())
            {
                SaveButton.Enabled = false;
                LoadingGIFPictureBox.Visible = true;
                ProgressLabel.Text = "Initializing... 0%";
                TrimWhitespaces(TitleTextBox); TrimWhitespaces(ArtistTextBox); TrimWhitespaces(AlbumTextBox); TrimLyricsWhitespaces();
                Utility.RunCommandlineTool("mp3gain", $"/k /r /d 6 \"{Song.Path}\"", OnMP3GainOutputReceived, OnMP3GainProcessExited, true);
            }
            else
            {
                finishedSaving = true;
                Close();
            }
        }
        
        public void OnMP3GainOutputReceived(object sender, DataReceivedEventArgs e)
        {
            if(e.Data == null)
                return;
            int progress = Utility.GetCommandToolProgressFromOutput(e.Data);
            if(progress >= 0 && e.Data.Contains("analyz", StringComparison.CurrentCultureIgnoreCase))
                setProgressTextInMainThread = $"Normalizing... {progress}%";
        }
        public void OnMP3GainProcessExited(object? sender, Utility.ProcessExitedEventArgs e)
        {
            returnToMainThreadToSave = true;
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
                UpdateMainForm();
            }
            if(!string.IsNullOrEmpty(setProgressTextInMainThread))
            {
                ProgressLabel.Text = setProgressTextInMainThread;
                setProgressTextInMainThread = "";
            }
        }

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
            ProgressLabel.Text = "Saving...";
            Utility.SaveFileTag(file, (sender, e) => { callUpdateMainForm = true; }, false);
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
                PlaybackManager.Player.Dispose();
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

        private bool HasMadeChanges()
        {
            return TitleTextBox.Text != Song.Data.Title || ArtistTextBox.Text != Song.Data.Artist || AlbumTextBox.Text != Song.Data.Album
                || (YearTextBox.Text != Song.Data.Year.ToString() && !(YearTextBox.Text == "" && Song.Data.Year == 0))
                || AlbumCoverPictureButton.Image != Song.Data.AlbumCover || LyricsTextBox.Text != Song.Data.Lyrics;
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

        private Rectangle currentBounds;
        private void OnLocationChanged(object? sender, EventArgs e)
        {
            Rectangle bounds = Screen.GetBounds(this);
            if(bounds != currentBounds)
            {
                currentBounds = bounds;
                Size defaultWindowSize = new(1118, 617); Size defaultScreenSize = new(1920, 1080);
                double widthScale = (double)bounds.Width / defaultScreenSize.Width;
                double heightScale = (double)bounds.Height / defaultScreenSize.Height;
                int newWidth = (int)Math.Max(1, defaultWindowSize.Width * widthScale);
                int newHeight = (int)Math.Max(1, defaultWindowSize.Height * heightScale);
                if(newWidth != Size.Width || newHeight != Size.Height)
                {
                    Size = new Size(newWidth, newHeight);
                }
            }
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Rectangle workingArea = Screen.FromControl(this).WorkingArea;
            int x = workingArea.Left + Math.Max(0, (workingArea.Width - Width) / 2);
            int y = workingArea.Top + Math.Max(0, (workingArea.Height - Height) / 2);
            SetDesktopLocation(x, y);
        }
        private void OnResponsiveClientSizeChanged()
        {
            ProgressLabel.Top = ClientSize.Height - ProgressLabel.Height - 40;
            ProgressLabel.Left = ClientSize.Width / 2 - ProgressLabel.Width / 2;
            LoadingGIFPictureBox.Top = ProgressLabel.Top - ProgressLabel.Height - LoadingGIFPictureBox.Height;
            LoadingGIFPictureBox.Left = ClientSize.Width / 2 - LoadingGIFPictureBox.Width / 2;
        }

        private static void TrimWhitespaces(System.Windows.Forms.TextBox textBox)
        {
            string newText = Utility.RemoveTrailingLeadingAndDoubleSpaces(textBox.Text);
            if(newText != textBox.Text)
                textBox.Text = newText;
        }
        private void TrimLyricsWhitespaces()
        {
            string newText = Utility.RemoveTrailingAndLeadingNewlines(LyricsTextBox.Text).ReplaceLineEndings();
            string newText2 = "";
            foreach(string line in newText.Split(Environment.NewLine))
                newText2 += Utility.RemoveTrailingLeadingAndDoubleSpaces(line);
            if(newText != LyricsTextBox.Text)
                LyricsTextBox.Text = newText;
        }

    }

}
