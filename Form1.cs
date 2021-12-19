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
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;
            //When the pipes are gone, they wont come back
            if(pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;

            }
            if(pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }
            if(FlappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                FlappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                    FlappyBird.Bounds.IntersectsWith(ground.Bounds)) 
            {
                endGame();
            }
            
            if(score >5)
            {
                pipeSpeed = 15;
            }

            if(FlappyBird.Top < -25)
            {
                endGame();
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "Game Over!!!";

        }

        
        private void scoreText_Click(object sender, EventArgs e)
        {

        }
    }  
    
}
