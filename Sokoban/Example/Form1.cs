using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;

namespace Example
{
    

    public partial class Engine : Form
    {


        static Sprite canvas = new Sprite(0, 0);
        public static Sprite Canvas
        {
            get { return canvas; }
        }

        private static int frameCount = 0;
        public static int FrameCount
        {
            get { return frameCount; }
        }

        

        public Engine()
        {
            InitializeComponent();
            DoubleBuffered = true;

            /*slider = new PhysicsSprite(Image.FromFile("acorn.png"), 0, 0);
            slider.Width = 50;
            slider.Height = 50;
            slider.TargetX = 100;
            slider.TargetY = 100;
            //slider.Speed = 30;
            canvas.Children.Add(slider);

            animatedSprite = new Dude(Image.FromFile("character.png"), 0, 0, 108, 140);
            Animation a = new Animation();
            a.IList =new int[]{ 0,1,2,3,4,5,6,7};
            a.JList= new int[] { 0,0,0,0,0,0,0,0 };
            a.TimeList = new int[] { 2,2,2,2,2,2,2,2 };
            animatedSprite.Animations.Add("run_right", a);

            Animation b = new Animation();
            b.IList = new int[] { 7,6,5,4,3,2,1,0 };
            b.JList = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            b.TimeList = new int[] { 2, 2, 2, 2, 2, 2, 2, 2 };
            animatedSprite.Animations.Add("run_left", b);

            animatedSprite.State = "run_right";
            canvas.Children.Add(animatedSprite);
            //canvas.Children.Add(new BlockSprite(0, 0, 100, 100));
            //BlockSprite b2 = new BlockSprite(0, 0, 100, 100);
            //b2.Y += 120;
            //canvas.Children.Add(b2);

            //canvas.X = 200;
            //canvas.Angle = 30;
            //canvas.Scale = 2;
            //s.Children.Add(new ImageSprite(Image.FromFile("acorn.png"), 100, 0));
            //s.Children.Add(new ImageSprite(Image.FromFile("acorn.png"), -100, 0));
            */
            Timer t = new Timer();
            t.Interval = 33;
            t.Tick += T_Tick;
            t.Start();

        }

        private void T_Tick(object sender, EventArgs e)
        {
            frameCount += 1;
            canvas.Update();
            Refresh();
            //Console.WriteLine(frameCount);
        }

        protected override void OnPaint(PaintEventArgs e)
        { 
            canvas.Paint(e.Graphics);

        }

        public virtual void Resized(EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Resized(e);
            this.Refresh();
        }

        /*private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Resized(e);
            this.Update();
        }*/

        public virtual void Mouse_Down(MouseEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Mouse_Down(e);
            canvas.ProcessMouseDown(e);

        }

        public virtual void Mouse_Move(MouseEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Mouse_Move(e);
        }


        public virtual void Mouse_Wheel(MouseEventArgs e)
        {

        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            Mouse_Wheel(e);
            Refresh();
        }

        public virtual void Mouse_Up(MouseEventArgs e)
        {

        }

        private void Engine_MouseUp(object sender, MouseEventArgs e)
        {
            Mouse_Up(e);
            canvas.ProcessMouseUp(e);
        }

        public virtual void Key_Down(KeyEventArgs e)
        {

        }
        private void Engine_KeyDown(object sender, KeyEventArgs e)
        {
            Key_Down(e);
        }
    }
}
