using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    

    public partial class Form1 : Form
    {
        static bool[,] board = new bool[5, 5];

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            //base.OnPaint(e);
            e.Graphics.RotateTransform(10);
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            e.Graphics.FillRectangle(Brushes.White, 0, 0, w, h);
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (board[i,j]) e.Graphics.FillRectangle(Brushes.Black, w * i / 5, h * j / 5, w / 5, h / 5);
                }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Update();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            int i = e.X / (w / 5);
            int j = e.Y / (h / 5);
            board[i, j] = !board[i, j];
            try { board[i - 1, j] = !board[i - 1, j]; }
            catch (Exception a) { }
            try { board[i + 1, j] = !board[i + 1, j]; }
            catch (Exception a) { }
            try { board[i, j-1] = !board[i, j-1]; }
            catch (Exception a) { }
            try { board[i, j+1] = !board[i , j+1]; }
            catch (Exception a) { }
            this.Refresh();
        }
    }
}
