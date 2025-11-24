namespace SoogbadMusic
{

    public partial class SongListItem : UserControl
    {

        public SongListItem()
        {
            InitializeComponent();
            ContextMenuStrip = null;
            System.Windows.Forms.Timer timer = new() { Interval = 100 };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private Song? song = null;
        public Song? Song
        {
            get
            {
                return song;
            }
            set
            {
                song = value;
                if(song == null)
                {
                    ContextMenuStrip = null;
                    NameLabel.Text = "";
                    InfoLabel.Text = "";
                    DurationLabel.Text = "";
                    DurationLabel.Left = 919;
                }
                else
                {
                    ContextMenuStrip = SongContextMenuStrip;
                    Utility.ShortenLabelText(NameLabel, Song != null ? Song.Data.Artist + " - " + Song.Data.Title : "", DurationLabel.Left - 50);
                    Utility.ShortenLabelText(InfoLabel, Song != null ? Song.Data.Album + " (" + Song.Data.Year.ToString() + ")" : "", DurationLabel.Left - 50);
                    DurationLabel.Text = Utility.FormatTime(song.Duration);
                }
            }
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            DurationLabel.Left = Width - DurationLabel.Width - 8;
            RemoveFromQueueToolStripMenuItem.Enabled = Song == null || PlayerManager.QueueContains(Song);
        }


        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            Utility.ShortenLabelText(NameLabel, Song != null ? Song.Data.Artist + " - " + Song.Data.Title : "", DurationLabel.Left - 50);
            Utility.ShortenLabelText(InfoLabel, Song != null ? Song.Data.Album + " (" + Song.Data.Year.ToString() + ")" : "", DurationLabel.Left - 50);
        }

        public List<Control> GetLabels()
        {
            return [NameLabel, InfoLabel, DurationLabel];
        }


        private void OnSongListItemMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && Song != null)
                PlayerManager.SwitchSong(Song);
        }

        private void OnAddToQueueToolStripMenuItemMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && Song != null)
                PlayerManager.AddToQueue(Song);
        }
        private void OnRemoveFromQueueToolStripMenuItemMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && Song != null)
                PlayerManager.RemoveFromQueue(Song);
        }
        private void OnSongInfoToolStripMenuItemMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && Song != null && !SongInfoForm.WindowExists(Song))
                new SongInfoForm(Song).Show();
        }

    }

}
