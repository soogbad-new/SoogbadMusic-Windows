using SoogbadMusic.Resources;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoogbadMusic
{

    public partial class SongListItem : UserControl
    {

        public SongListItem()
        {
            InitializeComponent();
            ContextMenuStrip = null;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = 100 };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private Song song = null;
        public Song Song
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
                    NameLabel.Text = song.Data.Artist + " - " + song.Data.Title;
                    InfoLabel.Text = song.Data.Album + " (" + song.Data.Year.ToString() + ")";
                    DurationLabel.Text = Utility.FormatTime(song.Duration);
                }
            }
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            DurationLabel.Left = Width - DurationLabel.Width - 8;
            RemoveFromQueueToolStripMenuItem.Enabled = Song == null || PlayerManager.QueueContains(Song);
        }

        public List<Control> GetLabels()
        {
            return new List<Control> { NameLabel, InfoLabel, DurationLabel };
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
