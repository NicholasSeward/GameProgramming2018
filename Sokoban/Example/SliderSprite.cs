using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class SliderSprite : ImageSprite
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

        //how many pixels to move in one act
        private double speed=2;
        public Double Speed //properties
        {
            get { return speed; }
            set { speed = value; }
        }


        public SliderSprite(Image image, int x, int y) : base(image, x, y)
        {
            targetX = X;
            targetY = Y;
        }


        public override void Update()
        {
            //less speed away then go there
            double dist=Math.Sqrt((TargetX - X) * (TargetX - X) + (TargetY - Y) * (TargetY - Y));
            if (dist <= speed)
            {
                X = TargetX;
                Y = TargetY;
            }
            else
            {
                double angle = Math.Atan2(TargetY - Y, TargetX - X);
                X += Math.Cos(angle) * speed;
                Y += Math.Sin(angle) * speed;
            }

            base.Update();
        }

    }
}
