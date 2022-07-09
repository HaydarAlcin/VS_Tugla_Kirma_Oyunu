using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecodation_Tugla_Kirma_Oyunu
{
    public partial class Form1 : Form
    {
        int ballX=5; int ballY=5;
        int score=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Left&&player.Left>0)
            {
                player.Left -= 50;
            }
            if (e.KeyCode == Keys.Right&&player.Left<290)
            {
                player.Left += 50;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball_movement();
            Score();

            GameOver();
        }

        private void ball_movement()
        {
            ball.Left += ballX;
            ball.Top += ballY;

            if (ball.Left<10 || ball.Left+ball.Width>ClientSize.Width)
            {
                ballX = -ballX;
            }
            
            if (ball.Top<0 || ball.Bounds.IntersectsWith(player.Bounds))
            {
                ballY = -ballY;
            }
        }

        private void Score()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox&& x.Tag=="block")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        ballY = -ballY;
                        ballX = -ballX;
                        score++;
                        label1.Text = "Score: " + Convert.ToString(score);
                    }
                    
                }
            }
        }

        private void GameOver()
        {
            if (score==18)
            {
                timer1.Stop();
                MessageBox.Show("You Win");
            }

            if (ball.Top>490)
            {
                timer1.Stop();
                MessageBox.Show("You Lost");
            }
        }
    }
}
