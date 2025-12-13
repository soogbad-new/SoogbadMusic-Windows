namespace SoogbadMusic
{
	
	public static class Playlist
	{

        public static string Directory { get; set; } = "";
        public static List<Song> Songs { get; private set; } = [];

        private static Thread? lastRefreshThread = null;
        private static bool stopLastThread = false;

        public static void RefreshSongs()
        {
            if(lastRefreshThread != null)
            {
                stopLastThread = true;
                while(lastRefreshThread.IsAlive) { }
                stopLastThread = false;
            }
            lastRefreshThread = new Thread(() =>
            {
                TagLib.Id3v2.Tag.DefaultVersion = 3;
                TagLib.Id3v2.Tag.ForceDefaultVersion = true;
                Songs = [];
                IEnumerable<string> files = PlaybackManager.Filter ? System.IO.Directory.EnumerateFiles(Directory, "*.mp3").Where(file => { return !Path.GetFileName(file).StartsWith('_'); }) : System.IO.Directory.EnumerateFiles(Directory, "*.mp3");
                int count = files.Count();
                int i = 0;
                foreach(string file in files)
                {
                    if(stopLastThread)
                        return;
                    Songs.Add(new Song(file));
                    IsAccessingRefreshSongsProgress = true;
                    RefreshSongsProgress = (double)i / count;
                    IsAccessingRefreshSongsProgress = false;
                    i++;
                }
                Songs.Sort(new SongComparer());
                RefreshSongsComplete = true;
            });
            lastRefreshThread.Start();
        }

        public static bool RefreshSongsComplete { get; set; } = false;
        public static double RefreshSongsProgress { get; set; } = 0;
        public static bool IsAccessingRefreshSongsProgress { get; private set; } = false;

    }
	
}