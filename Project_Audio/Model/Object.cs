using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Audio.Model
{
    public class Object
    {
        private Image shape;
        private string type;

        public Object(String shape)
        {
            this.shape = this.GenerateShape(shape);
            this.type = shape;
        }

        private Image GenerateShape(String shape)
        {
            return null;
        }
    }
}
