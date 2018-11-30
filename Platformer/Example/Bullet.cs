using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Example
{
    class Bullet : PhysicsSprite
    {
        public Bullet(double x, double y,double vx, double vy) : base(Image.FromFile("acorn.png"), (int)x, (int)y)
        {
            Width = 20;
            Height = 20;
            VX = vx;
            VY = vy;
            AX = 0;
            AY = 0;
        }

        public override void Collision(HashSet<PhysicsSprite> sprites)
        {
            foreach(PhysicsSprite s in sprites)
            {
                if (s.GetType() == typeof(Character)) continue;
                Engine.Canvas.ToDelete.Add(s);
                PhysicsSprite.sprites.Remove(s);
            }
        }

        public override void Act()
        {
            if (VX * VX + VY * VY < 1)
            {
                Engine.Canvas.ToDelete.Add(this);
                PhysicsSprite.sprites.Remove(this);
            }
           
        }
    }
}
