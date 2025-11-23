using System.Runtime.InteropServices;

namespace SoogbadMusic
{

    public partial class LyricsForm : ResponsiveForm
    {

        public LyricsForm()
        {
            InitializeComponent();
            Panel.HorizontalScroll.Maximum = 0;
            Panel.AutoScroll = false;
            Panel.VerticalScroll.Visible = false;
            Panel.AutoScroll = true;
            Panel.Controls.Add(LyricsLabel);
            AddInvisibleControls(new List<Control>() { LyricsLabel });
            BlacklistControlTop(LyricsLabel);
            AddChangeAnchorControl(SongNameLabel);
            AddChangeAnchorControl(SongInfoLabel);
            AddChangeAnchorControl(LyricsLabel);
            OnSongChanged();
            PlayerManager.SongChanged += OnSongChanged;
        }

        protected override int GetRTLExtraMargin(Control control)
        {
            return control.Name == "LyricsLabel" && IsScrollBarVisible() ? SystemInformation.VerticalScrollBarWidth : 0;
        }
        const int GWL_STYLE = -16;
        const int WS_VSCROLL = 0x00200000;
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        private bool IsScrollBarVisible()
        {
            if(Panel.Disposing || Panel.IsDisposed)
                return false;
            int wndStyle = GetWindowLong(Panel.Handle, GWL_STYLE);
            return (wndStyle & WS_VSCROLL) != 0;
        }

        private void OnSongChanged()
        {
            if(PlayerManager.Player != null)
            {
                SongNameLabel.Text = PlayerManager.Player.Song.Data.Artist + " - " + PlayerManager.Player.Song.Data.Title;
                SongInfoLabel.Text = PlayerManager.Player.Song.Data.Album + " (" + PlayerManager.Player.Song.Data.Year.ToString() + ")";
                LyricsLabel.Text = PlayerManager.Player.Song.Data.Lyrics + "\n" + "\n";
            }
            ScrollToTop();
        }
        private void ScrollToTop()
        {
            using(Control control = new Control() { Parent = Panel, Dock = DockStyle.Top })
            {
                Panel.ScrollControlIntoView(control);
                control.Parent = null;
            }
        }

    }

}
