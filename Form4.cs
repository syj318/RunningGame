using System;
using System.Windows.Forms;

namespace Running_game
{
    public partial class Form4 : Form
    {
        public string UserId { get; set; }
        public string Password { get; set; }

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
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtPW.Text))
            {
                MessageBox.Show("로그인 실패!!!");
            }
            else
            {
                MessageBox.Show("로그인 성공");
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            txtID.Focus();
        }
    }
}

