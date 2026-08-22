using Microsoft.Win32;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace SoogbadMusic
{

    public class PictureButton : PictureBox
    {

        private static readonly ImageAttributes _activeAttrs = CreateActiveAttrs();
        private static readonly ColorMatrix activeColorColorMatrix = new ColorMatrix(new float[][]
        {
            new float[] { AppColors..R / 255f, 0,   0,   0, 0 }, new float[] { 0,  AppColors..G / 255f,  0,   0, 0 }, new float[] { 0,  0,   AppColors..B / 255f,  0, 0 }, new float[] { 0,  0,   0,   1, 0 }, new float[] { 0,  0,   0,   0, 1 },
        }
        );

        public PictureButton()
        {
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private bool active;
        public void SetColorTint(bool active)
        {
            this.active = active;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if(active)
                e.Graphics.DrawImage(Image, new Rectangle(0, 0, ClientSize.Width, ClientSize.Height), 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, new ImageAttributes { ColorMatrix = activeColorColorMatrix });
            else
                base.OnPaint(e);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            string? filePath = Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Cursors", "Hand", "default") as string;
            Cursor = !string.IsNullOrEmpty(filePath) && File.Exists(filePath) ? new Cursor(LoadCursorFromFile(filePath)) : Cursors.Hand;
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern nint LoadCursorFromFile(string path);

    }

}
