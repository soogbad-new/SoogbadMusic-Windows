using System;
using System.Windows.Forms;
using NAudio.Wave;

namespace SoogbadMusic
{

    public class Player : IDisposable
    {

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public event EventHandler<MyStoppedEventArgs> PlaybackStopped;

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
                    throw e;
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
                else
                    return audioFile.CurrentTime.TotalSeconds;
            }
            set
            {
                if(!Stopped && value >= 0 && value < Song.Duration)
                    audioFile.CurrentTime = new TimeSpan(0, 0, (int)Math.Round(value));
            }
        }

        public void Play()
        {
            Paused = false;
            outputDevice.Play();
        }
        public void Pause()
        {
            Paused = true;
            outputDevice.Pause();
        }

        public void Dispose()
        {
            outputDevice.Stop();
        }
        public void Dispose2()
        {
            outputDevice.Stop();
            outputDevice.Dispose();
            audioFile.Dispose();
        }

        public bool Stopped { get; private set; } = false;

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            Stopped = true;
            bool finished = audioFile.TotalTime.TotalSeconds - audioFile.CurrentTime.TotalSeconds < 1;
            PlaybackStopped(sender, new MyStoppedEventArgs(finished, e.Exception));
            outputDevice.Dispose();
            audioFile.Dispose();
        }

    }


    public class MyStoppedEventArgs : StoppedEventArgs
    {

        public MyStoppedEventArgs(bool finished, Exception exception = null) : base(exception)
        {
            Finished = finished;
        }

        public bool Finished { get; }

    }

}