using System.Diagnostics;
using System.Text.RegularExpressions;
using TagLib;

namespace SoogbadMusic
{

    public partial class DownloadSongForm : Form
    {

        private string filePath = "";
        private string setProgressTextInMainThread = "";
        private bool finishUpInMainThread = false;
        private bool closeFormInMainThread = false;
        public DownloadSongForm()
        {
            InitializeComponent();
            System.Windows.Forms.Timer timer = new() { Interval = 10 };
            timer.Tick += OnTimerTick;
            timer.Start();
            URLTextBox.Select();
        }

        public void OnDownloadButtonMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && !string.IsNullOrEmpty(URLTextBox.Text))
            {
                DownloadButton.Enabled = false;
                string nodejsPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Replace(" (x86)", "") + "\\nodejs\\node.exe";
                if(!System.IO.File.Exists(nodejsPath))
                {
                    MessageBox.Show("ERROR: Node.js is not installed. It is needed to download from youtube. Please install it and place in Program Files.");
                    DownloadButton.Enabled = true;
                }
                string ffmpegPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\FFmpeg\\bin\\ffmpeg.exe";
                if(!System.IO.File.Exists(ffmpegPath))
                {
                    MessageBox.Show("ERROR: FFmpeg is not installed. It is needed to process the audio. Please install it and place in your user folder.");
                    DownloadButton.Enabled = true;
                }
                string url = string.Concat(URLTextBox.Text.Where(c => { return !char.IsWhiteSpace(c); }));
                string musicDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                SaveSongDialog.InitialDirectory = musicDirectory;
                if(SaveSongDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = SaveSongDialog.FileName;
                    if(!string.IsNullOrEmpty(filePath) && filePath.EndsWith(".mp3"))
                    {
                        string? directory = Path.GetDirectoryName(filePath);
                        if(!string.IsNullOrEmpty(directory) && directory.Equals(musicDirectory, StringComparison.OrdinalIgnoreCase))
                        {
                            DownloadButton.Visible = false; LoadingGIFPictureBox.Visible = true;
                            Utility.RunCommandlineTool("yt-dlp", $"-t mp3 --audio-quality 192K --newline --no-playlist --no-check-format --no-warnings --js-runtimes \"node:{nodejsPath}\" --ffmpeg-location \"{ffmpegPath}\" -o \"{filePath}\" \"{url}\"", OnYTDLPOutputReceived, OnYTDLPProcessExited, false);
                            ProgressLabel.Text = "Initializing...";
                        }
                        else
                        {
                            MessageBox.Show("File must be saved in " + musicDirectory);
                            DownloadButton.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid file");
                        DownloadButton.Enabled = true;
                    }
                }
            }
        }

        [GeneratedRegex(@"(\d+(?:\.\d+)?)%")]
        private static partial Regex ProgressRegex();
        public void OnYTDLPOutputReceived(object? sender, DataReceivedEventArgs e)
        {
            SetProgressFromOutput(e.Data, "Downloading");
        }
        public void OnMP3GainOutputReceived(object sender, DataReceivedEventArgs e)
        {
            SetProgressFromOutput(e.Data, "Normalizing");
        }
        private void SetProgressFromOutput(string? output, string operation)
        {
            if(output != null)
            {
                Match match = ProgressRegex().Match(output);
                if(match.Success && double.TryParse(match.Groups[1].Value, out double progress))
                    setProgressTextInMainThread = $"{operation}... {Math.Round(progress)}%";
            }
        }
        public void OnYTDLPProcessExited(object? sender, Utility.ProcessExitedEventArgs e)
        {
            if(e.ExitCode == 0)
                Utility.RunCommandlineTool("mp3gain", $"/k /r /d 6 \"{filePath}\"", OnMP3GainOutputReceived, OnMP3GainProcessExited, true);
            else
                closeFormInMainThread = true;
        }
        public void OnMP3GainProcessExited(object? sender, Utility.ProcessExitedEventArgs e)
        {
            finishUpInMainThread = true;
        }

        private void FinishUp()
        {
            ProgressLabel.Text = "Finalizing...";
            TagLib.File file = TagLib.File.Create(filePath);
            file.RemoveTags(TagTypes.AllTags);
            file.Save();
            Song song = new(filePath);
            LoadingGIFPictureBox.Visible = false;
            Playlist.Songs.Add(song);
            MainForm? mainForm = Utility.GetMainForm();
            if(mainForm != null)
            {
                mainForm.RefreshSongList();
                mainForm.ScrollToSong(song);
            }
            if(OpenAudacityCheckbox.Checked)
            {
                string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Replace(" (x86)", "");
                if(!System.IO.File.Exists(programFiles + "\\Audacity\\Audacity.exe"))
                    MessageBox.Show("ERROR: Audacity is not installed. Please install it and place in Program Files.");
                else
                    Utility.RunCommand(programFiles + "\\Audacity\\Audacity.exe", $"\"{filePath}\"");
            }
            Close();
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            if(closeFormInMainThread)
            {
                closeFormInMainThread = false;
                Close();
            }
            if(!string.IsNullOrEmpty(setProgressTextInMainThread))
            {
                ProgressLabel.Text = setProgressTextInMainThread;
                setProgressTextInMainThread = "";
            }
            if(finishUpInMainThread)
            {
                finishUpInMainThread = false;
                FinishUp();
            }    
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Utility.SetWindowTitleBarColor(Handle);
        }

    }

}
