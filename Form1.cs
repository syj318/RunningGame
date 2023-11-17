using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Running_game
{ //test
    public partial class Form1 : Form
    {
        const int Height = 840;
        const int LineStartTop = -210;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //test
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(5);
        }

      
        void moveline(int speed)
        {
            if (pictureBox1.Top >= Height)
            {
                pictureBox1.Top = LineStartTop;
            }
            else
            {
                pictureBox1.Top += speed;
            }

            if (pictureBox2.Top >= Height)
            {
                pictureBox2.Top = LineStartTop;
            }
            else
            {
                pictureBox2.Top += speed;
            }

            if (pictureBox3.Top >= Height)
            {
                pictureBox3.Top = LineStartTop;
            }
            else
            {
                pictureBox3.Top += speed;
            }

            if (pictureBox4.Top >= Height)
            {
                pictureBox4.Top = LineStartTop;
            }
            else
            {
                pictureBox4.Top += speed;
            }

            if (pictureBox7.Top >= Height)
            {
                pictureBox7.Top = LineStartTop;
            }
            else
            {
                pictureBox7.Top += speed;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        

        private void pictureBox_Man_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
