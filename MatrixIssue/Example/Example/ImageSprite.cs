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
            this.Width = image.Width;
            this.Height = image.Height;
        }

        //methods/functions
        public override void Draw(Graphics g)
        {
            g.DrawImage(image, (float)(X-Width/2), (float)(Y - Height / 2), (float)Width, (float)Height);
        }
    }
}
