using Running_game.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Running_game
{
    public partial class GameForm : Form
    {

        static public int collectedHeart = 0;

        List<GameObject> Objects = new List<GameObject>();


        public GameForm()
        {
            InitializeComponent();
            InitializeThread();
        }

        private void InitializeThread()
        {
            this.Objects = new List<GameObject> { 
                new ObstacleObjcet(1),
                new ObstacleObjcet(2),
            };

            for(int i = 0; i < 3; i++)
            {
                this.Objects.Add(new HeartObject());
            }

            this.Objects.ForEach(obj => { 
                this.Controls.Add(obj.CreateRamdomPictureBox(this.resources)); 
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.Objects.ForEach(obj => { obj.Move(); });
            foreach (var obj in Objects)
            {
                if (obj is ObstacleObjcet )
                {
                    if (obj.CheckPlayerCollision(PictureBox_Man))
                    {

                        timer1.Enabled = false;
                        label.Visible = true;
                        button1.Visible = true;
                        button2.Visible = true;
                        button3.Visible = true;
                    }
                }
                else
                {
                    if (obj.CheckPlayerCollision(PictureBox_Man))
                    {
                        collectedHeart += 1;
                        label_hearts.Text = $"♥ = {collectedHeart}";
                    }
                }
            }
        }



        private void gameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (PictureBox_Man.Left > 0)
                    PictureBox_Man.Left += -35;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (PictureBox_Man.Right < 845 - PictureBox_Man.Width / 2)
                    PictureBox_Man.Left += 35;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            GameForm form1 = new GameForm();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RankForm form3 = new RankForm();
            form3.Show();
        }

    }
}

