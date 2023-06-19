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
        public Image shape = null;
        public ShapeType type { get; set; }
        public string shapeName;
        public int x=0, y=0;
        public int size;

        public Shape(string shapeName, ShapeType shapeType)
        {
            this.shape = this.GenerateShape(shapeName);
            this.type = shapeType;
        }

        public Shape()
        {

        }

        public Image GenerateShape(String shapeName)
        {
            if (shapeName.Equals("square", StringComparison.OrdinalIgnoreCase))
            {
                shape = LoadSquareImage();
            }
            else if (shapeName.Equals("triangle", StringComparison.OrdinalIgnoreCase))
            {
                shape = LoadTriangleImage();
            }
            else if (shapeName.Equals("circle", StringComparison.OrdinalIgnoreCase))
            {
                shape = LoadCircleImage();
            }
            size = 50;
            return shape;
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

        public static Bitmap ResizeImage(Bitmap originalImage, int newWidth, int newHeight)
        {
            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        public void rotate(RotateFlipType type)
        {
            shape.RotateFlip(type);
        }

        public void moveShape(int x, int y)
        {
            this.x = this.x + x;
            this.y = this.y + y;
        }

        public void ResizeShape(int size)
        {
            if ((this.size == 10 && size == -10) || this.size == 80 && size == 10)
            {
                return;
            }

            this.size = this.size + size;
            Bitmap image = new Bitmap(shape);
            shape = ResizeImage(image, this.size, this.size);
        }

        public void Paint(Color color)
        {
            Bitmap image = new Bitmap(shape);
            int width = shape.Width;
            int height = shape.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color colorPixel = image.GetPixel(x, y);

                    if(colorPixel.A != 0)
                    {
                        image.SetPixel(x, y, color);
                    }
                }
            }

            shape = image;

        }
    }
}
