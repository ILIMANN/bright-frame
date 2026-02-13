using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;


namespace BrightFrame.Core
{
    public static class ScreenCapture
    {
        public static void RegionalScreenCapture(Rectangle selection)
        {
            using (Bitmap bmp = new Bitmap(selection.Width, selection.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(selection.Location, Point.Empty, selection.Size);
                }

                string pth = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "screenshot.png");

                bmp.Save(pth,ImageFormat.Png);
            }
        }
    }
}
