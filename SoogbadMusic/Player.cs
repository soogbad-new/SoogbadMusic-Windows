using NAudio.Wave;

namespace SoogbadMusic
{

    public class Player : IDisposable
    {

        private WaveOutEvent? outputDevice;
        private AudioFileReader? audioFile;

        public event EventHandler<MyStoppedEventArgs> PlaybackStopped = new((sender, e) => { });

        public Player(Song song)
        {
            Song = song;
            Paused = true;
            try
            {
                audioFile = new AudioFileReader(Song.Path);
            }
            catch(InvalidOperationException e)
            {
                if(e.Message.EndsWith("Mp3FileReader does not support sample rate changes."))
                {
                    MessageBox.Show("The file '" + Song.Path + "' cannot be played because its sample rate is not constant");
                    InitSuccess = false;
                }
                else
                    throw;
            }
            if(InitSuccess)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                outputDevice.Init(audioFile);
                outputDevice.Volume = 1.0f;
            }
        }

        public bool InitSuccess { get; private set; } = true;

        public Song Song { get; private set; }
        public bool Paused { get; private set; }

        public double CurrentTime
        {
            get
            {
                if(Stopped)
                    return Song.Duration;
                else if(audioFile != null)
                    return audioFile.CurrentTime.TotalSeconds;
                else
                    return 0;
            }
            set
            {
                if(!Stopped && value >= 0 && value < Song.Duration && audioFile != null)
                    audioFile.CurrentTime = new TimeSpan(0, 0, (int)Math.Round(value));
            }
        }

        public void Play()
        {
            Paused = false;
            if(outputDevice != null)
                outputDevice.Play();
        }
        public void Pause()
        {
            Paused = true;
            if(outputDevice != null)
                outputDevice.Pause();
        }

        public void Dispose()
        {
            if(outputDevice != null)
                outputDevice.Stop();
            GC.SuppressFinalize(this);
        }
        public void Dispose2()
        {
            if(outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
            }
            if(audioFile != null)
            {
                audioFile.Dispose();
            }
        }

        public bool Stopped { get; private set; } = false;

        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {
            if(audioFile == null || outputDevice == null)
                return;
            Stopped = true;
            bool finished = audioFile.TotalTime.TotalSeconds - audioFile.CurrentTime.TotalSeconds < 1;
            PlaybackStopped(sender, new MyStoppedEventArgs(finished, e.Exception));
            outputDevice.Dispose();
            audioFile.Dispose();
        }

    }


    public class MyStoppedEventArgs(bool finished, Exception? exception = null) : StoppedEventArgs(exception)
    {
        public bool Finished { get; } = finished;

    }

}