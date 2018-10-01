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
    public class Sprite
    {
        private double width=0;
        public double Width //properties
        {
            get { return width; }
            set { width = value; }
        }

        private double height=0;
        public double Height //properties
        {
            get { return height; }
            set { height = value; }
        }

        private bool visible = true;
        public bool Visible
        {
            get { return visible;}
            set { visible = value; }
        }

        private Matrix m = new Matrix();
        public Matrix M
        {
            get { return m; }
            set { m=value; }
        }

        private List<Sprite> children = new List<Sprite>();
        public List<Sprite> Children
        {
            get { return children; }
        }

        private double scale = 1;
        public double Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        private double angle = 0;
        public double Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        //instance variable
        private double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y;

        public double Y //properties
        {
            get { return y; }
            set { y = value; }
        }

        //width, height


        //constructors
        public Sprite(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual void Draw(Graphics g)
        {

        }

        public void ShowMatrix()
        {
            foreach (Single s in M.Elements) Console.Write(s+",");
            Console.WriteLine();
        }


        //methods/functions
        public void Paint(Graphics g)
        {
            if (!Visible) return;
            M=g.Transform.Clone();
            
            Draw(g);
            g.TranslateTransform((float)X, (float)Y);
            g.ScaleTransform((float)scale, (float)scale);
            g.RotateTransform((float)angle);
            //do nothing for painting myself
            foreach (Sprite child in children)
            {
                child.Paint(g);
            }
            g.Transform = M.Clone();
        }

        public virtual void Act()
        {

        }

        public void Update()
        {
            if (!visible) return;
            Act();
            foreach (Sprite child in children)
            {
                child.Update();
            }
        }

        private bool Contains(int screenX, int screenY)
        {
            PointF point = ScreenToCanvasTransform(screenX, screenY);
            ShowMatrix();
            float x = point.X;
            float y = point.Y;
            Console.WriteLine(point);
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }

        public PointF ScreenToCanvasTransform(float x, float y)
        {

            Console.WriteLine(x+","+y);
            PointF[] points = new PointF[] { new PointF(x, y) };

            
            Matrix q = M.Clone();
            q.Invert();
            q.TransformPoints(points);

            return points[0];
        }

        public virtual void MouseDown(MouseEventArgs e)
        {

        }

        public void ProcessMouseDown(MouseEventArgs e)
        {
            
            if (Contains(e.X, e.Y))
            {
                
                MouseDown(e);
                foreach (Sprite child in children) child.ProcessMouseDown(e);
            }
        }

        public virtual void MouseUp(MouseEventArgs e)
        {

        }

        public void ProcessMouseUp(MouseEventArgs e)
        {
            if (Contains(e.X, e.Y))
            {
                MouseUp(e);
                foreach (Sprite child in children) child.ProcessMouseDown(e);
            }
        }



    }
}
