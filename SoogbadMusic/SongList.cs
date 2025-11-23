namespace SoogbadMusic
{

    public partial class SongList : UserControl
    {

        private SongListItem[] items;
        private List<Song> tempSongList = null;

        public SongList()
        {
            InitializeComponent();
            items = new SongListItem[] { SongListItem1, SongListItem2, SongListItem3, SongListItem4, SongListItem5, SongListItem6, SongListItem7, SongListItem8Hidden };
            for(int i = 0; i < items.Length; i++)
            {
                foreach(Control label in items[i].GetLabels())
                {
                    label.Name += (i + 1).ToString();
                    label.MouseDown += OnSongListItemMouseDown;
                }
                items[i].MouseDown += OnSongListItemMouseDown;
            }
        }
        private void OnSongListItemMouseDown(object sender, MouseEventArgs e)
        {
            SongListItem item = (SongListItem)(sender is Label ? ((Label)sender).Parent : sender);
            if(item.Song != null)
            {
                bool light = Index % 2 == 0;
                for(int i = 0; i < items.Length; i++)
                {
                    if(items[i].Song == SelectedSong)
                        items[i].BackColor = light ? Color.FromArgb(0, 80, 96) : Color.FromArgb(0, 64, 64);
                    light = !light;
                }
                SelectedSong = item.Song;
                item.BackColor = Color.FromArgb(208, 160, 32);
                if(PlayerManager.Player != null && SelectedSong != PlayerManager.Player.Song)
                {
                    foreach(SongListItem item2 in items)
                        if(item2.Song == PlayerManager.Player.Song)
                            foreach(Control label in item2.GetLabels())
                                label.ForeColor = Color.FromArgb(255, 192, 0);
                }
                else
                    foreach(Control label in item.GetLabels())
                        label.ForeColor = Color.White;
            }
        }

        public int Index { get; private set; } = 0;
        public double ScrollOffsetPixels { get; set; }

        public void ChangeIndex(int index)
        {
            ChangeIndex(index, 0);
        }

        public void ChangeIndex(int index, double scrollPixels)
        {
            Index = index;
            ScrollOffsetPixels = scrollPixels;
            int i = 0;
            bool light = Index % 2 == 0;
            int itemHeight = items.Length > 0 ? (int)Math.Round((double)Height / GetItemCount()) : Height;
            int offsetPixels = (int)Math.Round(ScrollOffsetPixels);
            List<Song> list = tempSongList == null ? Playlist.Songs : tempSongList;
            foreach(SongListItem item in items)
            {
                item.Song = Index + i < list.Count ? list[Index + i] : null;
                item.BackColor = item.Song == SelectedSong && item.Song != null ? Color.FromArgb(208, 160, 32) : (light ? Color.FromArgb(0, 80, 96) : Color.FromArgb(0, 64, 64));
                if(PlayerManager.Player != null)
                {
                    if(item.Song == PlayerManager.Player.Song && item.Song != SelectedSong)
                        foreach(Control label in item.GetLabels())
                            label.ForeColor = Color.FromArgb(255, 192, 0);
                    else
                        foreach(Control label in item.GetLabels())
                            label.ForeColor = Color.White;
                }
                item.Location = new Point(item.Location.X, i * itemHeight - offsetPixels);
                light = !light;
                i++;
            }
            Update();
        }

        public Song SelectedSong { get; set; } = null;

        public void ChangeTempSongList(List<Song> tempSongList)
        {
            SortList();
            this.tempSongList = tempSongList;
            ScrollOffsetPixels = 0;
            ChangeIndex(0);
        }
        public bool IsTempSongListNull()
        {
            return tempSongList == null;
        }
        public List<Song> GetTempSongList()
        {
            return tempSongList == null ? Playlist.Songs : tempSongList;
        }
        public int GetItemCount()
        {
            return items.Length - 1;
        }
        public void SortList()
        {
            Playlist.Songs.Sort(new SongComparer());
            if(tempSongList != null)
                tempSongList.Sort(new SongComparer());
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            if(items == null)
                return;
            Size size = new Size(Width, (int)Math.Round((double)Height / GetItemCount()));
            int offsetPixels = (int)Math.Round(ScrollOffsetPixels);
            int i = 0;
            foreach(SongListItem item in items)
            {
                item.Size = size;
                item.Location = new Point(item.Location.X, i * size.Height - offsetPixels);
                i++;
            }
        }

        public List<Control> GetLabels()
        {
            if(items == null)
                return null;
            List<Control> ret = new List<Control>();
            foreach(SongListItem item in items)
                ret.AddRange(item.GetLabels());
            return ret;
        }

        public bool IsOnScreen(Song song)
        {
            foreach(SongListItem item in items)
                if(item.Song == song)
                    return true;
            return false;
        }

    }

}
