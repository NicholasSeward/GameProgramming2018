using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class PhysicsSprite : ImageSprite
    {
        public static List<PhysicsSprite> sprites = new List<PhysicsSprite>();
        private bool isStatic = false;




        public PhysicsSprite(Image image, int x, int y) : base(image, x, y)
        {
            sprites.Add(this);
        }
        public PhysicsSprite(Image image, int x, int y,bool isStatic) : base(image, x, y)
        {
            sprites.Add(this);
            this.isStatic = isStatic;
        }

        private double vx = 0;
        public double VX
        {
            get { return vx; }
            set { vx = value; }
        }
        private double vy = 0;
        public double VY
        {
            get { return vy; }
            set { vy = value; }
        }
        private double ax = 0;
        public double AX
        {
            get { return ax; }
            set { ax = value; }
        }
        private double ay = 2;
        public double AY
        {
            get { return ay; }
            set { ay = value; }
        }


        //F=m*a
        //k*dist=a
        //k*dist=dv/dt
        //k*dist=dv
        public static HashSet<PhysicsSprite> CollisionSet(double x, double y, double w, double h)
        {
            HashSet<PhysicsSprite> output = new HashSet<PhysicsSprite>();
            foreach (PhysicsSprite s in sprites)
            {
                double x1 = s.X;
                double x2 = x;
                double y1 = s.Y;
                double y2 = y;

                double w1 = s.Width;
                double w2 = w;
                double h1 = s.Height;
                double h2 = h;

                if (Math.Abs(2 * x1 + w1 - 2 * x2 - w2) < w1 + w2 && Math.Abs(2 * y1 + h1 - 2 * y2 - h2) < h1 + h2) output.Add(s);
            }
            return output;
        }


        public HashSet<PhysicsSprite> CollisionSet()
        {
            HashSet< PhysicsSprite > output= new HashSet<PhysicsSprite>();
            foreach (PhysicsSprite s in sprites)
            {
                if (s == this) continue;
                double x1 = s.X;
                double x2 = this.X;
                double y1 = s.Y;
                double y2 = this.Y;

                double w1 = s.Width;
                double w2 = this.Width;
                double h1 = s.Height;
                double h2 = this.Height;

                if (Math.Abs(2 * x1 + w1 - 2 * x2 - w2) < w1 + w2 && Math.Abs(2 * y1 + h1 - 2 * y2 - h2) < h1 + h2) output.Add(s);
            }
            return output;
        }

        public virtual void Collision(HashSet<PhysicsSprite> sprites)
        {

        }

        public override void Update()
        {
            HashSet<PhysicsSprite> sprites = new HashSet<PhysicsSprite>();
            if (!isStatic)
            {
                vx += ax;
                X += vx;
                HashSet<PhysicsSprite> xsprites = CollisionSet();
                if (xsprites.Count > 0)
                {
                    sprites.UnionWith(xsprites);
                    X -= vx;
                    vx = 0;
                }


                vy += ay;
                Y += vy;
                HashSet<PhysicsSprite> ysprites = CollisionSet();
                if (ysprites.Count > 0)
                {
                    sprites.UnionWith(ysprites);
                    Y -= vy;
                    vy = 0;
                }
            }
            if(sprites.Count>0)Collision(sprites);
            base.Update();
        }

    }
}
