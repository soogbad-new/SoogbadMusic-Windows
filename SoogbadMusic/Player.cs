using NAudio.Wave;

namespace SoogbadMusic
{

    public class Player : IDisposable
    {

        private WaveOutEvent? outputDevice;
        private AudioFileReader? audioFile;
        private bool isTest;
        public event EventHandler<MyStoppedEventArgs> PlaybackStopped = new((sender, e) => { });

        public Player(Song song, bool isTest=false)
        {
            Song = song;
            this.isTest = isTest;
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
            outputDevice?.Play();
        }
        public void Pause()
        {
            Paused = true;
            outputDevice?.Pause();
        }
        
        public bool Stopped { get; private set; } = false;
        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {
            Stopped = true;
            bool finished = false;
            try { finished = audioFile?.TotalTime.TotalSeconds - audioFile?.CurrentTime.TotalSeconds < 1; }
            catch(NullReferenceException) { }
            outputDevice?.Dispose();
            audioFile?.Dispose();
            if(!isTest)
                PlaybackStopped(sender, new MyStoppedEventArgs(finished, e.Exception));
        }

        public void Dispose()
        {
            OnPlaybackStopped(this, new StoppedEventArgs());
            GC.SuppressFinalize(this);
        }

    }

    public class MyStoppedEventArgs(bool finished, Exception? exception = null) : StoppedEventArgs(exception)
    {
        public bool Finished { get; } = finished;
    }

}