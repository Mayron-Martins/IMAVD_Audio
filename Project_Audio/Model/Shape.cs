using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Audio.Model
{
    public class Shape
    {
        private Image shape;
        private string type;

        public Shape(String shape)
        {
            this.shape = this.GenerateShape(shape);
            this.type = shape;
        }

        public Shape()
        {

        }

        public Image GenerateShape(String shape)
        {
            Image shapeImage = null;

            if (shape.Equals("square", StringComparison.OrdinalIgnoreCase))
            {
                shapeImage = LoadSquareImage();
            }
            else if (shape.Equals("triangle", StringComparison.OrdinalIgnoreCase))
            {
                shapeImage = LoadTriangleImage();
            }
            else if (shape.Equals("circle", StringComparison.OrdinalIgnoreCase))
            {
                shapeImage = LoadCircleImage();
            }

            return shapeImage;
        }

        public Bitmap LoadSquareImage()
        {
            string imagePath = @"C:\Users\eddu_\OneDrive - Instituto Superior de Engenharia do Porto\Documentos\ISEP\IMAVD\IMAVD_Audio\Project_Audio\View\Icons\Shapes\Square.png";
            Bitmap squareBitmap = new Bitmap(imagePath);
            return ResizeImage (squareBitmap, 50, 50);
        }

        public Bitmap LoadTriangleImage()
        {
            string imagePath = @"C:\Users\eddu_\OneDrive - Instituto Superior de Engenharia do Porto\Documentos\ISEP\IMAVD\IMAVD_Audio\Project_Audio\View\Icons\Shapes\Triangle.png";
            Bitmap triangleBitmap = new Bitmap(imagePath);
            return ResizeImage(triangleBitmap, 50, 50);
        }

        public Bitmap LoadCircleImage()
        {
            string imagePath = @"C:\Users\eddu_\OneDrive - Instituto Superior de Engenharia do Porto\Documentos\ISEP\IMAVD\IMAVD_Audio\Project_Audio\View\Icons\Shapes\Circle.png";
            Bitmap circleBitmap = new Bitmap(imagePath);
            return ResizeImage(circleBitmap, 50, 50);
            
        }

        public Bitmap ResizeImage(Bitmap originalImage, int newWidth, int newHeight)
        {
            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }
    }
}
