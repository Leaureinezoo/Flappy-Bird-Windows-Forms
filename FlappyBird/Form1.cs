using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class form1 : Form
    {
        int pipeSpeed = 6;
        int gravity = 5;
        double score = 0;
        

        public form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score : " + score;


            if (pipeBottom.Left < -100)
            {
                pipeBottom.Left = 600;
                pipeTop.Left = 600;
                score += 1;
                pipeTop.Location = new Point(321, -129);
                pipeBottom.Location = new Point(321, 368);
                Random random = new Random();
                int randTop = random.Next(0, 6);
                switch (randTop)
                {
                    case 0:
                        pipeTop.Location = new Point(321, -265);
                        pipeBottom.Location = new Point(321, 194);
                        pipeTop.Height = 324;
                        pipeBottom.Height = 335;
                        break;
                    case 1:
                        pipeTop.Location = new Point(321, -205);
                        pipeBottom.Location = new Point(321, 245);
                        pipeTop.Height = 254;
                        pipeBottom.Height = 284;
                        break;
                    case 2:
                        pipeTop.Location = new Point(321, -205);
                        pipeBottom.Location = new Point(321, 245);
                        pipeTop.Height = 322;
                        pipeBottom.Height = 284;
                        break;
                    case 3:
                        pipeTop.Location = new Point(321, -205);
                        pipeBottom.Location = new Point(321, 304);
                        pipeTop.Height = 322;
                        pipeBottom.Height = 225;
                        break;
                    case 4:
                        pipeTop.Location = new Point(321, -75);
                        pipeBottom.Location = new Point(321, 304);
                        pipeTop.Height = 245;
                        pipeBottom.Height = 225;
                        break;
                    case 5:
                        pipeTop.Location = new Point(321, -75);
                        pipeBottom.Location = new Point(321, 367);
                        pipeTop.Height = 245;
                        pipeBottom.Height = 162;
                        break;
                    case 6:
                        pipeTop.Location = new Point(321, -10);
                        pipeBottom.Location = new Point(321, 367);
                        pipeTop.Height = 245;
                        pipeBottom.Height = 162;
                        break;
                    case 7:
                        pipeTop.Location = new Point(321, -10);
                        pipeBottom.Location = new Point(321, 454);
                        pipeTop.Height = 245;
                        pipeBottom.Height = 75;
                        break;
                    case 8:
                        pipeTop.Location = new Point(321, -10);
                        pipeBottom.Location = new Point(321, 454);
                        pipeTop.Height = 366;
                        pipeBottom.Height = 75;
                        break;
                    default:
                        break;
                }
                pipeSpeed += 1;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || 
                flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -35)
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text = "Game Over ! Score : " + score;
            scoreText.BackColor = Color.Red;
        }
    }
}
