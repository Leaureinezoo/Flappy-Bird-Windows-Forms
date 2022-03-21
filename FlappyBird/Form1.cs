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
        int score = 0;
        

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
                score += 1;
                pipeTop.Location = new Point(500, -129);
                pipeBottom.Location = new Point(500, 368);
                Random random = new Random();
                int rand = random.Next(0, 9);
                switch (rand)
                {
                    case 0:
                        pipeTop.Location = new Point(500, -265);
                        pipeBottom.Location = new Point(500, 194);
                        pipeTop.Height = 324;
                        pipeBottom.Height = 335;
                        break;
                    case 1:
                        pipeTop.Location = new Point(500, -205);
                        pipeBottom.Location = new Point(500, 245);
                        pipeTop.Height = 254;
                        pipeBottom.Height = 284;
                        break;
                    case 2:
                        pipeTop.Location = new Point(500, -205);
                        pipeBottom.Location = new Point(500, 245);
                        pipeTop.Height = 322;
                        pipeBottom.Height = 284;
                        break;
                    case 3:
                        pipeTop.Location = new Point(500, -205);
                        pipeBottom.Location = new Point(500, 304);
                        pipeTop.Height = 322;
                        pipeBottom.Height = 225;
                        break;
                    case 4:
                        pipeTop.Location = new Point(500, -75);
                        pipeBottom.Location = new Point(500, 304);
                        pipeTop.Height = 245;
                        pipeBottom.Height = 225;
                        break;
                    case 5:
                        pipeTop.Location = new Point(500, -75);
                        pipeBottom.Location = new Point(500, 367);
                        pipeTop.Height = 245;
                        pipeBottom.Height = 162;
                        break;
                    case 6:
                        pipeTop.Location = new Point(500, -10);
                        pipeBottom.Location = new Point(500, 367);
                        pipeTop.Height = 245;
                        pipeBottom.Height = 162;
                        break;
                    case 7:
                        pipeTop.Location = new Point(500, -10);
                        pipeBottom.Location = new Point(500, 454);
                        pipeTop.Height = 245;
                        pipeBottom.Height = 75;
                        break;
                    case 8:
                        pipeTop.Location = new Point(500, -10);
                        pipeBottom.Location = new Point(500, 454);
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
