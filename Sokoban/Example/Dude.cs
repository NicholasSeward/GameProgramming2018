using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    public class Dude:AnimatedSprite
    {
        public Dude(Image spriteSheet, int x, int y, int width, int height) : base(spriteSheet, x, y, width, height)
        {
        }

        public override void MouseDown(MouseEventArgs e)
        {
            State = "run_left";
        }
        public override void MouseUp(MouseEventArgs e)
        {
            State = "run_right";
        }
    }
}
