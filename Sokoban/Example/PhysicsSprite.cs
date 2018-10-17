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
        private double targetX;
        public Double TargetX //properties
        {
            get { return targetX; }
            set { targetX = value; }
        }
        private double targetY;
        public Double TargetY //properties
        {
            get { return targetY; }
            set { targetY = value; }
        }


        public PhysicsSprite(Image image, int x, int y) : base(image, x, y)
        {
            targetX = X;
            targetY = Y;
        }

        double vx = 0;
        double vy = 0;
        double k = 0.2;
        double velocityReduction = .7;

        //F=m*a
        //k*dist=a
        //k*dist=dv/dt
        //k*dist=dv

        public override void Update()
        {
            if (Math.Sqrt((X - targetX) * (X - targetX) + (Y - targetY) * (Y - targetY) )< .1)
            {
                X = TargetX;
                Y = TargetY;
            }
            else
            {
                vx += k * (TargetX - X);
                vy += k * (TargetY - Y);
                vx *= velocityReduction;
                vy *= velocityReduction;
                X += vx;
                Y += vy;
            }


            base.Update();
        }

    }
}
