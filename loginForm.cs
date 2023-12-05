using System;
using System.Windows.Forms;

namespace Running_game
{
    public partial class LoginForm : Form
    {
        
    
        public LoginForm()
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
                GameForm form1 = new GameForm();
                form1.Show();
            }
        }

    }
}

