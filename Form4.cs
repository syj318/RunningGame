using System;
using System.Windows.Forms;

namespace Running_game
{
    public partial class Form4 : Form
    {
        
    
        public Form4()
        {
            InitializeComponent();
            Shown += form_shown;
        }

        private void form_shown(object sender, EventArgs e)
        {
            txtID.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("닉네임을 입력해주세요.");
            }
            else
            {
                MessageBox.Show("게임을 시작합니다.");
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

    }
}

