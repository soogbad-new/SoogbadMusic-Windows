using TagLib;

namespace SoogbadMusic
{

    public partial class DownloadSongForm : Form
    {

        public DownloadSongForm()
        {
            InitializeComponent();
        }

        public void OnDownloadButtonMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                //
                string filePath = "";

                ClearFileMetadata(filePath);
                Song song = new(filePath);
                Playlist.Songs.Add(song);
                MainForm? mainForm = Utility.GetMainForm();
                if(mainForm != null)
                    mainForm.RefreshSongList();
                new SongInfoForm(song).Show();
            }
        }
        private static void ClearFileMetadata(string filePath)
        {
            TagLib.File file = TagLib.File.Create(filePath);
            file.RemoveTags(TagTypes.AllTags);
            file.Save();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Utility.SetWindowTitleBarColor(Handle);
        }

    }

}
