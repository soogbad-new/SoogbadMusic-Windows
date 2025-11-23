namespace SoogbadMusic
{

    public static class PlayerManager
    {

        public static event EmptyEventHandler SongChanged;
        public static void RaiseSongChanged()
        {
            SongChanged();
        }
        public static event EmptyEventHandler PausedValueChanged;

        private static List<Song> history = new List<Song>();
        private static int currentlyPlayedSongIndex = -1;

        public static bool Shuffle { get; set; } = false;
        public static bool Filter { get; set; } = true;

        public static Player Player { get; set; } = null;
        private static bool paused = true;
        public static bool Paused
        {
            get
            {
                return paused;
            }
            set
            {
                if(!value && !Shuffle && Player == null && queue.Count == 0)
                    return;
                else if(!value && Player != null && Player.Stopped)
                    return;
                paused = value;
                if(Player == null)
                    NextSong();
                else
                {
                    if(value)
                        Player.Pause();
                    else
                        Player.Play();
                }
                PausedValueChanged();
            }
        }

        private static void CreatePlayer()
        {
            if(Player != null)
                Player.Dispose();
            Player = new Player(history[currentlyPlayedSongIndex]);
            Player.PlaybackStopped += OnPlaybackStopped;
            if(!Paused)
                Player.Play();
        }
        public static void OnPlaybackStopped(object sender, MyStoppedEventArgs e)
        {
            if(e.Finished || e.Exception != null)
                NextSong();
        }

        public static void NextSong()
        {
            if(Playlist.Songs.Count == 0)
            {
                paused = true;
                return;
            }
            if(queue.Count == 0)
            {
                if(currentlyPlayedSongIndex + 1 > history.Count - 1)
                {
                    if(Shuffle)
                    {
                        Song song = Playlist.Songs[new Random().Next(0, Playlist.Songs.Count)];
                        if(!File.Exists(song.Path) || !SampleRateConstant(song))
                        {
                            NextSong();
                            return;
                        }
                        history.Add(song);
                        currentlyPlayedSongIndex = history.Count - 1;
                        CreatePlayer();
                        SongChanged();
                    }
                    else if(!paused && Player.Stopped)
                        Paused = true;
                }
                else
                {
                    currentlyPlayedSongIndex++;
                    if(!File.Exists(history[currentlyPlayedSongIndex].Path) || !SampleRateConstant(history[currentlyPlayedSongIndex]))
                    {
                        history.RemoveAt(currentlyPlayedSongIndex);
                        NextSong();
                        return;
                    }
                    CreatePlayer();
                    SongChanged();
                }
            }
            else
            {
                if(!File.Exists(queue[0].Path) || !SampleRateConstant(queue[0]))
                {
                    queue.RemoveAt(0);
                    NextSong();
                    return;
                }
                history.Add(queue[0]);
                currentlyPlayedSongIndex = history.Count - 1;
                CreatePlayer();
                queue.RemoveAt(0);
                SongChanged();
            }
        }
        public static void PreviousSong()
        {
            if(Playlist.Songs.Count == 0)
                return;
            if(currentlyPlayedSongIndex > 0)
            {
                currentlyPlayedSongIndex--;
                if(!File.Exists(history[currentlyPlayedSongIndex].Path) || !SampleRateConstant(history[currentlyPlayedSongIndex]))
                {
                    history.RemoveAt(currentlyPlayedSongIndex);
                    PreviousSong();
                    return;
                }
                CreatePlayer();
                SongChanged();
            }
        }

        public static void SwitchSong(Song song)
        {
            if(!File.Exists(song.Path) || !SampleRateConstant(song))
                return;
            history.Add(song);
            currentlyPlayedSongIndex = history.Count - 1;
            CreatePlayer();
            SongChanged();
            Paused = false;
        }

        private static List<Song> queue = new List<Song>();
        public static void AddToQueue(Song song)
        {
            queue.Add(song);
        }
        public static void RemoveFromQueue(Song song)
        {
            while(queue.Contains(song))
                queue.Remove(song);
        }
        public static bool QueueContains(Song song)
        {
            return queue.Contains(song);
        }

        private static bool SampleRateConstant(Song song)
        {
            Player testPlayer = new Player(song);
            if(testPlayer.InitSuccess)
            {
                testPlayer.Dispose2();
                return true;
            }
            else
                return false;
        }

    }

}
