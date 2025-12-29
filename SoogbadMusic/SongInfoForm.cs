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

        private bool callUpdateMainForm = false;        
        private void OnSaveButtonMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
                return;
            SaveButton.Enabled = false;
            GetMainFormData();
            SaveDataToFile();
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
                if(TitleTextBox.Text == Song.Data.Title && ArtistTextBox.Text == Song.Data.Artist && AlbumTextBox.Text == Song.Data.Album && YearTextBox.Text == Song.Data.Year.ToString() && AlbumCoverPictureButton.Image == Song.Data.AlbumCover && LyricsTextBox.Text == Song.Data.Lyrics)
                    e.Cancel = false;
                else if(new ExitDialog().ShowDialog() == DialogResult.OK)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        MainForm? mainForm = null;
        private double previousCurrentTime = 0;
        private bool wasPlaying = false, wasPaused = false;
        private void GetMainFormData()
        {
            mainForm = Utility.GetMainForm();
            if(PlaybackManager.Player != null && PlaybackManager.Player.Song == Song)
            {
                wasPlaying = true;
                wasPaused = PlaybackManager.Player.Paused;
                previousCurrentTime = PlaybackManager.Player.CurrentTime;
                PlaybackManager.Player.Dispose();
                PlaybackManager.Player = null;
            }
        }
        private void OnTimerTick(object? sender, EventArgs e)
        {
            if(callUpdateMainForm)
            {
                callUpdateMainForm = false;
                UpdateMainForm();
            }
        }
        private void UpdateMainForm()
        {
            if(wasPlaying)
            {
                int songIndex = Playlist.Songs.IndexOf(Song);
                Playlist.Songs[songIndex].RefreshData();
                PlaybackManager.Player = new Player(Playlist.Songs[songIndex]) { CurrentTime = previousCurrentTime };
                PlaybackManager.Player.PlaybackStopped += PlaybackManager.OnPlaybackStopped;
                if(!wasPaused)
                    PlaybackManager.Player.Play();
                PlaybackManager.RaiseSongChanged();
            }
            if(mainForm != null)
                mainForm.RefreshSongList();
            finishedSaving = true;
            Close();
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
