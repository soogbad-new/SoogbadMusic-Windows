namespace SoogbadMusic
{

    public partial class SongList : UserControl
    {

        private SongListItem[] items;
        public List<Song>? TempSongList { get; set; } = null;
        public Song? SelectedSong { get; set; } = null;

        public int Index { get; private set; } = 0;
        public int ScrollPixelsOffset { get; set; }
        private const int SCROLL_MULTIPLIER = 3;
        private int ItemHeight { get { return items.Length > 0 ? (int)Math.Round((double)Height / GetVisibleItemsCount()) : Height; } }
        private int ScrollAmount { get { return (int)Math.Round(ItemHeight / (double)SCROLL_MULTIPLIER); } }

        private VScrollBar? scrollBar = null;
        public VScrollBar? ScrollBar
        {
            get { return scrollBar; }
            set
            {
                if(value == null)
                    return;
                scrollBar = value;
                scrollBar.SmallChange = ScrollAmount;
                scrollBar.LargeChange = SCROLL_MULTIPLIER * GetVisibleItemsCount();
                scrollBar.ValueChanged += OnScrollBarValueChanged;
            }
        }

        public SongList()
        {
            InitializeComponent();
            MouseWheel += OnSongListMouseWheel;
            items = [SongListItem1, SongListItem2, SongListItem3, SongListItem4, SongListItem5, SongListItem6, SongListItem7, SongListItem8Hidden];
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

        private void OnSongListItemMouseDown(object? sender, MouseEventArgs e)
        {
            if(sender == null)
                return;
            SongListItem item;
            if(sender is Label senderLabel && senderLabel.Parent != null)
                item = (SongListItem)senderLabel.Parent;
            else
                item = (SongListItem)sender;

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
                if(PlaybackManager.Player != null && SelectedSong != PlaybackManager.Player.Song)
                {
                    foreach(SongListItem item2 in items)
                        if(item2.Song == PlaybackManager.Player.Song)
                            foreach(Control label in item2.GetLabels())
                                label.ForeColor = Color.FromArgb(255, 192, 0);
                }
                else
                    foreach(Control label in item.GetLabels())
                        label.ForeColor = Color.White;
            }
        }

        public void ChangeIndex(int index, int scrollPixelsOffset)
        {
            Index = index;
            ScrollPixelsOffset = scrollPixelsOffset;
            int i = 0;
            bool light = Index % 2 == 0;
            List<Song> currentList = TempSongList == null ? Playlist.Songs : TempSongList;
            foreach(SongListItem item in items)
            {
                item.Song = Index + i < currentList.Count ? currentList[Index + i] : null;
                item.BackColor = item.Song == SelectedSong && item.Song != null ? Color.FromArgb(208, 160, 32) : (light ? Color.FromArgb(0, 80, 96) : Color.FromArgb(0, 64, 64));
                if(PlaybackManager.Player != null)
                {
                    if(item.Song == PlaybackManager.Player.Song && item.Song != SelectedSong)
                        foreach(Control label in item.GetLabels())
                            label.ForeColor = Color.FromArgb(255, 192, 0);
                    else
                        foreach(Control label in item.GetLabels())
                            label.ForeColor = Color.White;
                }
                item.Location = new Point(item.Location.X, i * ItemHeight - scrollPixelsOffset);
                light = !light;
                i++;
            }
            Update();
            SetScrollBarValue(Index);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            if(items == null)
                return;
            int i = 0;
            foreach(SongListItem item in items)
            {
                item.Size = new(Width, ItemHeight);
                item.Location = new Point(item.Location.X, i * item.Size.Height - ScrollPixelsOffset);
                i++;
            }
        }

        private void OnSongListMouseWheel(object? sender, MouseEventArgs e)
        {
            if(Height <= 0 || Playlist.Songs.Count == 0 || e.Delta == 0)
                return;
            int direction = e.Delta < 0 ? 1 : -1;
            int targetScrollOffset = ScrollPixelsOffset + direction * ScrollAmount;
            int targetIndex = Index;
            (targetIndex, targetScrollOffset) = ClampScrollValues(targetIndex, targetScrollOffset);
            if(targetIndex != Index || targetScrollOffset != ScrollPixelsOffset)
                ChangeIndex(targetIndex, targetScrollOffset);
        }

        public void OnScrollBarValueChanged(object? sender, EventArgs e)
        {
            if(Height <= 0 || Playlist.Songs.Count == 0 || ScrollBar == null)
                return;
            int targetScrollOffset = ScrollPixelsOffset + ScrollBar.Value % SCROLL_MULTIPLIER * ScrollAmount;
            int targetIndex = ConvertScrollBarValueToSongIndex(ScrollBar.Value);
            (targetIndex, targetScrollOffset) = ClampScrollValues(targetIndex, targetScrollOffset);
            if(ScrollBar.Value == 0)
                targetScrollOffset = 0;
            if(targetIndex != Index || targetScrollOffset != ScrollPixelsOffset)
                ChangeIndex(targetIndex, targetScrollOffset);
        }

        private (int index, int scrollOffset) ClampScrollValues(int index, int scrollOffset)
        {
            int maxIndex = Math.Max(0, GetCurrentListCount() - GetVisibleItemsCount());
            while(scrollOffset >= ItemHeight && index < maxIndex)
            {
                scrollOffset -= ItemHeight;
                index++;
            }
            while(scrollOffset < 0 && index > 0)
            {
                scrollOffset += ItemHeight;
                index--;
            }
            if(index >= maxIndex || index < 0 || scrollOffset < 0)
                scrollOffset = 0;
            index = Math.Clamp(index, 0, maxIndex);
            return (index, scrollOffset);
        }

        public void SetScrollBarValue(int index)
        {
            if(ScrollBar == null)
                return;
            int targetScroll = ConvertSongIndexToScrollBarValue(index);
            if(targetScroll >= ScrollBar.Maximum)
                targetScroll = ScrollBar.Maximum;
            ScrollBar.Value = targetScroll;
        }
        public void SetScrollBarMaximum(int songsCount)
        {
            if(ScrollBar == null)
                return;
            if(songsCount <= GetVisibleItemsCount())
                songsCount = 0;
            ScrollBar.Maximum = ConvertSongIndexToScrollBarValue(songsCount);
        }

        private int ConvertSongIndexToScrollBarValue(int index)
        {
            return index * SCROLL_MULTIPLIER;
        }
        private int ConvertScrollBarValueToSongIndex(int scrollbarValue)
        {
            return scrollbarValue / SCROLL_MULTIPLIER;
        }

        public int GetCurrentListCount()
        {
            return TempSongList == null ? Playlist.Songs.Count : TempSongList.Count;
        }
        public int GetVisibleItemsCount()
        {
            return items.Length - 1;
        }

        public List<Control>? GetLabels()
        {
            if(items == null)
                return null;
            List<Control> ret = [];
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
