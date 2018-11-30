using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Example
{
    public class SokobanGame:Engine
    {

        Character bulldozer;
        MediaPlayer jumpSound = new MediaPlayer();
        
    


        public SokobanGame():base()
        {
            jumpSound.Open(new System.Uri(@"c:\Windows\Media\chimes.wav"));
            bulldozer = new Character(Image.FromFile("acorn.png"), 100, 100);
            bulldozer.Width = 100;
            bulldozer.Height = 100;
            Canvas.Children.Add(bulldozer);
            Random r = new Random();
            for(int i=0;i<100;i++)
            {
                PhysicsSprite block = new PhysicsSprite(Image.FromFile("acorn.png"), i*100, r.Next(200,350), true);
                block.Width = 100;
                block.Height = 100;
                Canvas.Children.Add(block);
            }
            
        }

        public override void Act()
        {

            Canvas.X = -bulldozer.X + this.ClientRectangle.Width / 2 - 100;
            Canvas.Y = -bulldozer.Y + this.ClientRectangle.Height / 2 - 100;

        }

     
  
        
    

    }
}
