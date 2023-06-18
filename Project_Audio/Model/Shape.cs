using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Audio.Model
{
    public enum ShapeType{
        Triangle,
        Square,
        Circle
    }
    public class Shape
    {
        private Image shape;
        public ShapeType type { get; set; }
        public string shapeName;

        public Shape(string shapeName, ShapeType shapeType)
        {
            this.shape = this.GenerateShape(shapeName);
            this.type = shapeType;
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
            Bitmap squareBitmap = global::Project_Audio.Properties.Resources.Square;
            return ResizeImage (squareBitmap, 50, 50);
        }

        public Bitmap LoadTriangleImage()
        {
            Bitmap triangleBitmap = global::Project_Audio.Properties.Resources.Triangle;
            return ResizeImage(triangleBitmap, 50, 50);
        }

        public Bitmap LoadCircleImage()
        { 
            Bitmap circleBitmap = global::Project_Audio.Properties.Resources.Circle;
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
