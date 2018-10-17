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
        int bulldozerX;
        int bulldozerY;
        int unitSize = 80;
        Sprite[,] game;


        public SokobanGame():base()
        {
            LoadLevel(1);
        }

        public void LoadLevel(int n)
        {
            Canvas.Children.Clear();
            String[] lines = System.IO.File.ReadAllLines("Level" + n + ".txt");
            int h = lines.Length;
            int w = lines[0].Length;
            game = new Sprite[h, w];
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    char letter = lines[j][i];
                    if (letter == 'X')
                    {
                        ImageSprite a = new ImageSprite(Image.FromFile("acorn.png"), i * unitSize, j * unitSize);
                        game[j, i] = a;
                        a.Width = unitSize;
                        a.Height = unitSize;
                        Canvas.Children.Add(a);
                    }
                    if (letter == 'B')
                    {
                        bulldozer = new PhysicsSprite(Image.FromFile("acorn.png"), i * unitSize, j * unitSize);
                        game[j, i] = bulldozer;
                        bulldozer.Width = unitSize * .5;
                        bulldozer.Height = unitSize * .5;
                        Canvas.Children.Add(bulldozer);
                        bulldozerX = i;
                        bulldozerY = j;
                    }
                }
            }

        }

        public override void Key_Down(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && game[bulldozerY, bulldozerX - 1] == null)
            {
                bulldozer.TargetX -= unitSize;
                game[bulldozerY, bulldozerX - 1] = game[bulldozerY, bulldozerX];
                game[bulldozerY, bulldozerX] = null;
                bulldozerX--;
            }
            if (e.KeyCode == Keys.D && game[bulldozerY, bulldozerX + 1] == null)
            {
                bulldozer.TargetX += unitSize;
                game[bulldozerY, bulldozerX + 1] = game[bulldozerY, bulldozerX];
                game[bulldozerY, bulldozerX] = null;
                bulldozerX++;
            }
            if (e.KeyCode == Keys.D && game[bulldozerY, bulldozerX + 1] != null && game[bulldozerY, bulldozerX + 2] ==null)
            {
                bulldozer.TargetX += unitSize;
                game[bulldozerY, bulldozerX + 1].X += unitSize;
                game[bulldozerY, bulldozerX + 2] = game[bulldozerY, bulldozerX + 1];
                game[bulldozerY, bulldozerX + 1] = game[bulldozerY, bulldozerX];
                game[bulldozerY, bulldozerX] = null;
                bulldozerX++;
            }
            if (e.KeyCode == Keys.W) bulldozer.TargetY -= unitSize;
            if (e.KeyCode == Keys.S) bulldozer.TargetY += unitSize;
        }

        public override void Mouse_Down(MouseEventArgs e)
        {
            LoadLevel(2);
        }

    }
}
