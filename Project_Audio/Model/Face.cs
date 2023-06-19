using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Audio.Model
{
    public class Face
    {
        public Image image;
        public int x = 0,y = 0;

        public Face(Image image)
        {
            this.image = Face.ResizeFace(image, 50, 50);
        }

        public static Bitmap ResizeFace(Image originalImage, int newWidth, int newHeight)
        {
            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        public void moveFace(int x, int y)
        {
            this.x = this.x + x;
            this.y = this.y + y;
        }
    }
}
