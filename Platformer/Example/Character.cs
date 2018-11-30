using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Example
{
    class Character:PhysicsSprite
    {
        public Character(Image image, int x, int y) : base(image,x, y)
        {
        }

        public override void Act()
        {
            Boolean left = Engine.PressedKeys.Contains(Keys.A);
            Boolean right = Engine.PressedKeys.Contains(Keys.D);
            if (left && right) VX = 0;
            else if (left) VX = -5;
            else if (right) VX = 5;
            else VX = 0;

            if (VX > 0) leftShot = true;
            else if (VX < 0) leftShot = false;


        }
        Boolean leftShot = true;

        public override void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) VY -= 20;
            if (e.KeyCode == Keys.Space)
            {
                if(leftShot)Engine.Canvas.ToAdd.Add(new Bullet(X+Width, Y+Height/2-10, 20,0));
                else Engine.Canvas.ToAdd.Add(new Bullet(X -20, Y + Height / 2 - 10, -20, 0));
                Console.WriteLine("PWEW");
            }
        }
    }
}
