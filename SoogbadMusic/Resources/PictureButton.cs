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
            string file = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Cursors", "Hand", "default");
            Cursor = file != null && File.Exists(file) ? new Cursor(LoadCursorFromFile(file)) : Cursors.Hand;
        }

        [DllImport("user32.dll")]
        private static extern nint LoadCursorFromFile(string path);

    }

}
