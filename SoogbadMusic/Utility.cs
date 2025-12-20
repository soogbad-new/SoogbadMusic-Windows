using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace SoogbadMusic
{

    public delegate void EmptyEventHandler();

    public static partial class Utility
    {

        public static string FormatTime(double seconds)
        {
            int mins = (int)(seconds / 60);
            int secs = (int)(seconds % 60);
            return mins.ToString() + ":" + (secs >= 10 ? "" : "0") + secs.ToString();
        }

        public static bool ContainsRTLCharacters(string str)
        {
            foreach(char c in str)
                if(c > 'א' && c < 'ݿ')
                    return true;
            return false;
        }

        public static void ShortenLabelText(Label label, string fullText, int limitRight)
        {
            label.Text = fullText;
            for(int i = 1; ; i++)
            {
                if(label.Left + label.Width <= limitRight)
                    break;
                label.Text = fullText.Remove(fullText.Length - i) + "...";
            }
        }

        public static MainForm? GetMainForm()
        {
            foreach(Form form in Application.OpenForms)
                if(form is MainForm main)
                    return form as MainForm;
            return null;
        }

        public static void RunCommandlineTool(string command, string arguements, DataReceivedEventHandler onOutputReceived, ProcessExitedEventHandler onProcessExited, bool sendErrorsToOutput)
        {
            new Thread(async () =>
            {
                string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, command + ".exe");
                if(!File.Exists(exePath))
                    throw new FileNotFoundException("ERROR: Could not find commandline tool: " + exePath);
                Process process = new()
                {
                    StartInfo = new ProcessStartInfo() { FileName = exePath, Arguments = arguements, UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true, RedirectStandardError = true }
                };
                process.OutputDataReceived += onOutputReceived;
                if(!sendErrorsToOutput)
                {
                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if(!string.IsNullOrEmpty(e.Data))
                            MessageBox.Show($"ERROR: {command}: " + e.Data);
                    };
                }
                else
                    process.ErrorDataReceived += onOutputReceived;
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                await process.WaitForExitAsync();
                try { onProcessExited(process, new ProcessExitedEventArgs(process.ExitCode)); }
                catch { onProcessExited(null, new ProcessExitedEventArgs(1)); }
                process.Dispose();
            }).Start();
        }
        public class ProcessExitedEventArgs(int exitCode) : EventArgs
        {
            public int ExitCode { get; private set; } = exitCode;
        }
        public delegate void ProcessExitedEventHandler(object? sender, ProcessExitedEventArgs e);
        public static void RunCommand(string command, string arguements)
        {
            new Thread(() =>
            {
                if(!File.Exists(command))
                    throw new FileNotFoundException("ERROR: Could not find command: " + command);
                using Process process = new()
                {
                    StartInfo = new ProcessStartInfo() { FileName = command, Arguments = arguements, UseShellExecute = false }
                };
                process.Start();
            }).Start();
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        private const int DWMWA_CAPTION_COLOR = 35;
        public static void SetWindowTitleBarColor(nint windowHandle)
        {
            int colorRef = ColorTranslator.ToWin32(Color.FromArgb(15, 100, 50));
            _ = DwmSetWindowAttribute(windowHandle, DWMWA_CAPTION_COLOR, ref colorRef, sizeof(int));
        }

        public sealed class NoHighlightToolStripRenderer : ToolStripProfessionalRenderer
        {

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                DrawBackgroundImage(e.Graphics, e.Item.BackgroundImage, e.Item.BackColor, e.Item.BackgroundImageLayout, new Rectangle(Point.Empty, e.Item.Size), new Rectangle(Point.Empty, e.Item.Size));
            }

            private static void DrawBackgroundImage(Graphics g, Image? backgroundImage, Color backColor, ImageLayout backgroundImageLayout, Rectangle bounds, Rectangle clipRect, RightToLeft rightToLeft = RightToLeft.No)
            {
                if(backgroundImage == null)
                    return;
                Rectangle imageRectangle = bounds;
                if(rightToLeft == RightToLeft.Yes && backgroundImageLayout == ImageLayout.None)
                    imageRectangle.X += clipRect.Width - imageRectangle.Width;
                using(SolidBrush brush = new(backColor))
                    g.FillRectangle(brush, clipRect);
                if(!clipRect.Contains(imageRectangle))
                {
                    imageRectangle.Intersect(clipRect);
                    g.DrawImage(backgroundImage, imageRectangle);
                }
                else
                {
                    ImageAttributes imageAttrib = new();
                    imageAttrib.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(backgroundImage, imageRectangle, 0, 0, backgroundImage.Width, backgroundImage.Height, GraphicsUnit.Pixel, imageAttrib);
                    imageAttrib.Dispose();
                }
            }

        }

    }

}
