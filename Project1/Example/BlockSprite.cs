using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Example
{
    public class BlockSprite:Sprite
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
        private Color color=Color.FromArgb(0,0,0);
        public Color Color //properties
        {
            get { return color; }
            set { color = value; }
        }

        private int i;



        //constructors
        public BlockSprite(int x, int y, int width, int height):base(x,y)
        {
            this.width = width;
            this.height = height;
        }

        //methods/functions
        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(color), (float)X,(float)Y,(float)width,(float)height);
        }

        private bool Contains(int screenX,int screenY)
        {
            PointF[] points = new PointF[] { new PointF(screenX, screenY) };
            Matrix m = M.Clone();
            m.Invert();
            m.TransformPoints(points);
            float x = points[0].X;
            float y = points[0].Y;
            Console.WriteLine(x + "," + y);
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;

        }


        public override void Act()
        {
            int r = (int)(127 + 127 * Math.Sin(Engine.FrameCount / 100.0));
            int g = (int)(127 + 127 * Math.Sin(Engine.FrameCount / 57.0));
            int b = (int)(127 + 127 * Math.Sin(Engine.FrameCount / 69.0));
            if(Engine.IsMouseDown  && Contains(Engine.ClickX,Engine.ClickY))
            {
                r = 0;
                g = 255;
                b = 0;
            }
            color = Color.FromArgb(r, g, b);
        }
    }
}
