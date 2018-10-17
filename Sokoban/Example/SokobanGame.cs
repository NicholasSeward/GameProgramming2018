using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    public class SokobanGame:Engine
    {

        PhysicsSprite bulldozer;
        int unitSize = 80;


        public SokobanGame():base()
        {
            bulldozer = new PhysicsSprite(Image.FromFile("acorn.png"), unitSize, unitSize);
            bulldozer.Width = unitSize;
            bulldozer.Height = unitSize;
            String[] lines=System.IO.File.ReadAllLines("Level1.txt");
            for(int j=0; j<lines.Length;j++)
            {
                for (int i = 0; i < lines[j].Length; i++) 
                {
                    char letter = lines[j][i];
                    if(letter=='X')
                    {
                        ImageSprite a = new ImageSprite(Image.FromFile("acorn.png"), i*unitSize, j*unitSize);
                        a.Width = unitSize;
                        a.Height = unitSize;
                        Canvas.Children.Add(a);
                    }
                }
            }
            Canvas.Children.Add(bulldozer);
        }

        public override void Key_Down(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) bulldozer.TargetX -= unitSize;
            if (e.KeyCode == Keys.D) bulldozer.TargetX += unitSize;
            if (e.KeyCode == Keys.W) bulldozer.TargetY -= unitSize;
            if (e.KeyCode == Keys.S) bulldozer.TargetY += unitSize;
        }


    }
}
