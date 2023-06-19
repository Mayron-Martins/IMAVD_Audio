using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Audio.Model
{
    public class Face
    {
        public Image image;
        public int x = 0, y = 0;
        public int size;

        public Face(Image image)
        {
            this.image = Face.ResizeFace(image, 50, 50);
            size = 50;
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

        public void ResizeFace(int size)
        {
            if ((this.size == 10 && size == -10) || this.size == 80 && size == 10)
            {
                return;
            }

            this.size = this.size + size;
            Bitmap image = new Bitmap(this.image);
            this.image = ResizeFace(image, this.size, this.size);
        }

        public void Paint(Color color)
        {
            Bitmap image = new Bitmap(this.image);
            int width = this.image.Width;
            int height = this.image.Height;
            List<(int, int, bool)> list = new List<(int, int, bool)>(); 

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color colorPixel = image.GetPixel(x, y);

                    if (colorPixel.A != 0)
                    {
                        list.Add((x, y, false));
                    }
                    else
                    {
                        list.Add((x, y, true));
                    }
                }
            }

            Color overlayColor = Color.FromArgb(128, color);

            Bitmap overlayImage = new Bitmap(image.Width, image.Height);

            using (Graphics g = Graphics.FromImage(overlayImage))
            {

                g.DrawImage(image, 0, 0);


                using (Brush brush = new SolidBrush(overlayColor))
                {
                    g.FillRectangle(brush, new Rectangle(0, 0, overlayImage.Width, overlayImage.Height));
                }
            }

            foreach((int x, int y, bool overlay) in list)
            {
                if (overlay)
                {
                    overlayImage.SetPixel(x, y, Color.Transparent);
                }
            }

            this.image = overlayImage;
        }
    }
}
