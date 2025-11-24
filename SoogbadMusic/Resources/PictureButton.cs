using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace SoogbadMusic
{

    public class PictureButton : PictureBox
    {

        public PictureButton()
        {
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            string? filePath = Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Cursors", "Hand", "default") as string;
            Cursor = !string.IsNullOrEmpty(filePath) && File.Exists(filePath)
                ? new Cursor(LoadCursorFromFile(filePath))
                : Cursors.Hand;
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern nint LoadCursorFromFile(string path);

    }

}
