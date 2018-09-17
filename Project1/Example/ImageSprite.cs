using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Example
{
    public class ImageSprite:Sprite
    {
       
        private double width;
        public double Width //properties
        {
            get { return width; }
            set { width = value; }
        }

        private double height;
        public double Height //properties
        {
            get { return height; }
            set { height = value; }
        }

        private Image image;
        public Image Image //properties
        {
            get { return image; }
            set { image = value; }
        }


        //constructors
        public ImageSprite(Image image, int x, int y):base(x,y)
        {
            this.image = image;
            this.width = image.Width;
            this.height = image.Height;
        }

        //methods/functions
        public override void Draw(Graphics g)
        {
            g.DrawImage(image, (float)(X-width/2), (float)(Y - height / 2), (float)width, (float)height);
        }
    }
}
