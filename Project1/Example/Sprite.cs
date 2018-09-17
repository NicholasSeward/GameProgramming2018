using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Example
{
    public class Sprite
    {
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

        //methods/functions
        public void Paint(Graphics g)
        {
            if (!Visible) return;
            Draw(g);
            m=g.Transform;

            g.TranslateTransform((float)X, (float)Y);
            g.ScaleTransform((float)scale, (float)scale);
            g.RotateTransform((float)angle);
            //do nothing for painting myself
            foreach (Sprite child in children)
            {
                child.Paint(g);
            }
            g.Transform = M;
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
    }
}
