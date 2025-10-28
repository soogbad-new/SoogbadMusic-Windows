using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace SoogbadMusic
{
	
	public static class Playlist
	{
		
		public static string Directory { get; set; }
        public static List<Song> Songs { get; private set; } = new List<Song>();

        private static Thread lastRefreshThread = null;
        private static bool stopLastThread = false;

        public static void RefreshSongs(bool calculateProgress)
        {
            if(lastRefreshThread != null)
            {
                stopLastThread = true;
                while(lastRefreshThread.IsAlive) { }
                stopLastThread = false;
            }
            lastRefreshThread = new Thread(() =>
            {
                Songs = new List<Song>();
                string[] files = System.IO.Directory.GetFiles(Directory); //
                int songsTotal = files.Length;
                if(PlayerManager.Filter)
                {
                    songsTotal = 0;
                    foreach(string file in files) //
                    {
                        if(stopLastThread)
                            return;
                        string[] split = file.ToLower().Split('\\');
                        string filename = split[split.Length - 1];
                        if(file.ToLower().EndsWith(".mp3") && !filename.StartsWith("_")) //
                            songsTotal++;
                    }
                }
                for(int i = 0, j = 0; i < files.Length; i++) //
                {
                    if(stopLastThread)
                        return;
                    string[] split = files[i].ToLower().Split('\\');
                    string filename = split[split.Length - 1];
                    if(files[i].ToLower().EndsWith(".mp3") && (!filename.StartsWith("_") || !PlayerManager.Filter)) //
                    {
                        Songs.Add(new Song(files[i])); //
                        if(calculateProgress)
                        {
                            IsAccessingRefreshSongsProgress = true;
                            RefreshSongsProgress = (double)j / songsTotal;
                            IsAccessingRefreshSongsProgress = false;
                        }
                        j++;
                    }
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