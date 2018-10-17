using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Example
{
    public class BlockSprite:Sprite
    {
       
     
        private Color color=Color.FromArgb(0,0,0);
        public Color Color //properties
        {
            get { return color; }
            set { color = value; }
        }

        private bool isDown=false;

        private int i;



        //constructors
        public BlockSprite(int x, int y, int width, int height):base(x,y)
        {
            Width = width;
            Height = height;
        }

        //methods/functions
        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(color), 0,0,(float)Width,(float)Height);
        }

        public override void MouseDown(MouseEventArgs e)
        {
            isDown = true;
        }
        public override void MouseUp(MouseEventArgs e)
        {
            isDown = false;
        }


        public override void Act()
        {
            /*Width = Engine.Form.ClientRectangle.Width / 4;
            int r = (int)(127 + 127 * Math.Sin(Engine.FrameCount / 100.0));
            int g = (int)(127 + 127 * Math.Sin(Engine.FrameCount / 57.0));
            int b = (int)(127 + 127 * Math.Sin(Engine.FrameCount / 69.0));
            if(isDown)
            {
                r = 0;
                g = 255;
                b = 0;
            }
            color = Color.FromArgb(r, g, b);*/
        }
    }
}
