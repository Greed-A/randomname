using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lines
{
    public enum Item
    {
        none,
        ball,
        jump,
        next,
        path
    }

    public struct Ball
    {
        public int x;
        public int y;
        public int color;
    }
    public delegate void ShowItem(Ball ball, Item item);
    public partial class Form1 : Form
    {
        Game game;
        Form3 form3;
        //Размерность
        public static int score = 0;
        public static int max=32;
        public static int size;
         
        private void Sizep()
        {
            if (max <= 32 && max>28)
            {
                size = 20;
            }
            if (max<28 && max > 24)
            {
                size = 22;
            }
            if (max<24 && max >= 15)
            {
                size = 32;
            }
            if (max<15 && max >= 10)
            {
                size = 45;
            }
            if (max<10 && max >= 8)
            {
                size = 64;
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {

        }
        PictureBox[,]  box;


        public Form1()
        {
            InitializeComponent();
            Sizep();
            CreateBoxes();
            game = new Game(max, ShowItem);
            form3 = new Form3();
            Timer.Enabled = true;
        }


        //Создание ячейки
        public void CreateBoxes()
        {
            box = new PictureBox[max, max];
            for (int x=0;x<max;x++)
                for (int y = 0; y < max; y++)
                {
                    box[x, y] = new PictureBox();
                    panel.Controls.Add(box[x, y]);
                    box[x, y].BorderStyle = BorderStyle.FixedSingle;
                    box[x, y].Size = new Size(size, size);
                    box[x, y].Location = new Point(x * size, y * size);
                    box[x, y].Image = Properties.Resources.empty;
                    box[x, y].SizeMode = PictureBoxSizeMode.Zoom;
                    box[x, y].Click += new EventHandler(this.ClickBox);
                    //сохраняем инфу о координатах
                    box[x, y].Tag = new Point(x, y);
                }
             panel.Size = new Size(max*size, max * size);
            Size = new Size(max * size+150, max * size+90);
            label1.Location = new Point(max*size+30, max*size/2);
        }


        private void ClickBox(object sender, EventArgs e)
        {
            Point xy = (Point)((PictureBox)sender).Tag;
            game.ClickBox(xy.X, xy.Y);
        }

        private Bitmap imgBall(int nr)
        {
            switch (nr)
            {
                case 1:return Properties.Resources._1n;
                case 2: return Properties.Resources._2n;
                case 3: return Properties.Resources._3n;
                case 4: return Properties.Resources._4n;
                case 5: return Properties.Resources._5n;
                case 6: return Properties.Resources._6n;
            }
            return null;
        }

        private Bitmap imgJump(int nr)
        {
            switch (nr)
            {
                case 1: return Properties.Resources._1b;
                case 2: return Properties.Resources._2b;
                case 3: return Properties.Resources._3b;
                case 4: return Properties.Resources._4b;
                case 5: return Properties.Resources._5b;
                case 6: return Properties.Resources._6b;
            }
            return null;
        }

        private Bitmap imgNext(int nr)
        {
            switch (nr)
            {
                case 1: return Properties.Resources._1s;
                case 2: return Properties.Resources._2s;
                case 3: return Properties.Resources._3s;
                case 4: return Properties.Resources._4s;
                case 5: return Properties.Resources._5s;
                case 6: return Properties.Resources._6s;
            }
            return null;
        }

        public void ShowItem(Ball ball, Item item)
        {
            Image img;

            switch (item)
            {
                case Item.none: img = Properties.Resources.empty; break;
                case Item.ball: img = imgBall(ball.color); break;
                case Item.next: img = imgNext(ball.color); break;
                case Item.jump: img = imgJump(ball.color); break;
                case Item.path: img = Properties.Resources.path1; break;
                default       : img = Properties.Resources.empty; break;
            }

            box[ball.x, ball.y].Image = img;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            game.Step();
            TabScore();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        public void TabScore()
        {
            label1.Text = "Your Score: " + score.ToString();
        }
    }
}
