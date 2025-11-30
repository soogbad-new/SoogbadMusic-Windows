using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

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
