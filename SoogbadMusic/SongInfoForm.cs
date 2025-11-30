using TagLib;

namespace SoogbadMusic
{
    public partial class SongInfoForm : Form
    {

        public static bool WindowExists(Song song)
        {
            foreach(Form form in Application.OpenForms)
                if(form.Text == "Song Info - " + song.Path)
                    return true;
            return false;
        }

        public SongInfoForm(Song song)
        {
            InitializeComponent();
            Song = song;
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

        public Song Song { get; private set; }

        private void OnCancelButtonMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                Close();
        }
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if(saving)
                saving = false;
            else
                e.Cancel = !Cancel();
        }
        private bool Cancel()
        {
            return (TitleTextBox.Text == Song.Data.Title && ArtistTextBox.Text == Song.Data.Artist && AlbumTextBox.Text == Song.Data.Album && YearTextBox.Text == Song.Data.Year.ToString() && AlbumCoverPictureButton.Image == Song.Data.AlbumCover && LyricsTextBox.Text == Song.Data.Lyrics) || new ExitDialog().ShowDialog() == DialogResult.OK;
        }
        bool saving = false;
        bool doStuff = false;
        MainForm? mainForm = null;
        bool paused = false;
        double currentTime = 0;
        bool wasPlayed = false;
        int index;
        private void OnSaveButtonMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                SaveButton.Enabled = false;
                mainForm = null;
                foreach(Form form in Application.OpenForms)
                    if(form is MainForm main)
                    {
                        mainForm = main;
                        break;
                    }
                if(PlaybackManager.Player != null && PlaybackManager.Player.Song == Song)
                {
                    wasPlayed = true;
                    paused = PlaybackManager.Player.Paused;
                    currentTime = PlaybackManager.Player.CurrentTime;
                    PlaybackManager.Player.Dispose();
                    PlaybackManager.Player = null;
                }
                TagLib.File file = TagLib.File.Create(Song.Path);
                file.Tag.Title = TitleTextBox.Text == "" ? null : TitleTextBox.Text;
                file.Tag.AlbumArtists = ArtistTextBox.Text == "" ? [] : [ArtistTextBox.Text];
                file.Tag.Performers = file.Tag.AlbumArtists;
                file.Tag.Album = AlbumTextBox.Text == "" ? null : AlbumTextBox.Text;
                file.Tag.Year = YearTextBox.Text == "" ? 0 : uint.Parse(YearTextBox.Text);
                file.Tag.Track = YearTextBox.Text == "" ? 0 : uint.Parse(YearTextBox.Text);
                file.Tag.Pictures = AlbumCoverPictureButton.Image == null ? [] : [new Picture(new ByteVector((byte[]?)new ImageConverter().ConvertTo(AlbumCoverPictureButton.Image, typeof(byte[]))))];
                file.Tag.Lyrics = LyricsTextBox.Text == "" ? null : LyricsTextBox.Text;
                new Thread(() =>
                {
                    int i = 0;
                    while(true)
                    {
                        bool worked = true;
                        try
                        {
                            file.Save();
                        }
                        catch(IOException)
                        {
                            worked = false;
                        }
                        if(worked)
                            break;
                        i++;
                    }
                    file.Dispose();
                    index = Playlist.Songs.IndexOf(Song);
                    Playlist.Songs[index].Refresh();
                    doStuff = true;
                }).Start();
            }
        }
        private void OnTimerTick(object? sender, EventArgs e)
        {
            if(doStuff)
            {
                doStuff = false;
                if(wasPlayed)
                {
                    PlaybackManager.Player = new Player(Playlist.Songs[index]) { CurrentTime = currentTime };
                    PlaybackManager.Player.PlaybackStopped += PlaybackManager.OnPlaybackStopped;
                    if(!paused)
                        PlaybackManager.Player.Play();
                    PlaybackManager.RaiseSongChanged();
                }
                if(mainForm != null)
                {
                    SongList songList = mainForm.GetSongList();
                    if(songList.TempSongList == null)
                        Playlist.Songs.Sort(new SongComparer());
                    else
                        songList.TempSongList.Sort(new SongComparer());
                    songList.ChangeIndex(songList.Index, songList.ScrollPixelsOffset);
                }
                saving = true;
                Close();
            }
        }

        private void OnYearTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void OnAlbumCoverPictureButtonMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && OpenAlbumCoverDialog.ShowDialog() == DialogResult.OK)
                AlbumCoverPictureButton.Image = Image.FromFile(OpenAlbumCoverDialog.FileName);
        }

        private void OnTextBoxTextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            textBox.RightToLeft = Utility.ContainsRTLCharacters(textBox.Text) ? RightToLeft.Yes : RightToLeft.No;
        }

    }

}
