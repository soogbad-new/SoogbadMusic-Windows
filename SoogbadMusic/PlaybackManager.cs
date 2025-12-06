using Windows.Media;
using Windows.Media.Playback;
using Windows.Storage;

namespace SoogbadMusic
{

    public static class PlaybackManager
    {

        public static event EmptyEventHandler SongChanged = new(() => { });
        public static void RaiseSongChanged()
        {
            SongChanged();
            UpdateSystemControlsData();
        }
        public static event EmptyEventHandler PausedValueChanged = new(() => { });

        private static SystemMediaTransportControls? systemControls = null;
        private static List<Song> history = [];
        private static int currentlyPlayedSongIndex = -1;
        public static bool Shuffle { get; set; } = false;
        public static bool Filter { get; set; } = true;
        public static Player? Player { get; set; } = null;

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
                if(systemControls != null)
                    systemControls.PlaybackStatus = Paused ? MediaPlaybackStatus.Paused : MediaPlaybackStatus.Playing;
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
        public static void OnPlaybackStopped(object? sender, MyStoppedEventArgs e)
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
                        RaiseSongChanged();
                    }
                    else if(!paused && Player != null && Player.Stopped)
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
                    RaiseSongChanged();
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
                RaiseSongChanged();
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
                RaiseSongChanged();
            }
        }

        public static void SwitchSong(Song song)
        {
            if(!File.Exists(song.Path) || !SampleRateConstant(song))
                return;
            history.Add(song);
            currentlyPlayedSongIndex = history.Count - 1;
            CreatePlayer();
            RaiseSongChanged();
            Paused = false;
        }

        private static List<Song> queue = [];
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

        private static void UpdateSystemControlsData()
        {
            if(Player == null)
                return;
            if(systemControls == null)
            {
                systemControls = BackgroundMediaPlayer.Current.SystemMediaTransportControls;
                systemControls.DisplayUpdater.AppMediaId = "SoogbadMusic";
                systemControls.DisplayUpdater.Type = MediaPlaybackType.Music;
                systemControls.ButtonPressed += OnSystemControlsButtonPressed;
                systemControls.IsPlayEnabled = true; systemControls.IsPauseEnabled = true; systemControls.IsPreviousEnabled = true; systemControls.IsNextEnabled = true;
            }
            systemControls.DisplayUpdater.Type = MediaPlaybackType.Music;
            systemControls.DisplayUpdater.MusicProperties.Artist = Player.Song.Data.Artist;
            systemControls.DisplayUpdater.MusicProperties.AlbumArtist = Player.Song.Data.Artist;
            systemControls.DisplayUpdater.MusicProperties.Title = Player.Song.Data.Title;
            systemControls.DisplayUpdater.MusicProperties.AlbumTitle = Player.Song.Data.Album;
            if(Player.Song.Data.AlbumCover != null)
            {
                string tempFolder = Path.GetTempPath() + "\\SoogbadMusic";
                if(!Directory.Exists(tempFolder))
                    Directory.CreateDirectory(tempFolder);
                Player.Song.Data.AlbumCover.Save(tempFolder + "\\thumb.png");
                StorageFile thumbFile = StorageFile.GetFileFromPathAsync(tempFolder + "\\thumb.png").AsTask().GetAwaiter().GetResult();
                systemControls.DisplayUpdater.Thumbnail = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(thumbFile);
            }
            systemControls.DisplayUpdater.Update();
        }
        public static bool RequestPreviousSongFromMainThread { get; set; } = false;
        public static bool RequestNextSongFromMainThread { get; set; } = false;
        private static void OnSystemControlsButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs e)
        {
            switch(e.Button)
            {
                case SystemMediaTransportControlsButton.Play: Paused = false; break;
                case SystemMediaTransportControlsButton.Pause: Paused = true; break;
                case SystemMediaTransportControlsButton.Previous: RequestPreviousSongFromMainThread = true; break;
                case SystemMediaTransportControlsButton.Next: RequestNextSongFromMainThread = true; break;
                case SystemMediaTransportControlsButton.Stop: Environment.Exit(0); break;
            }
        }

        private static bool SampleRateConstant(Song song)
        {
            Player testPlayer = new(song);
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
