using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Running_game //현재 코드가 속해있는 네임스페이스 정의
{
    public partial class LoginForm : Form //LoginForm 클래스 정의. Form 클래스를 상속받는다.
    {
        
    
        public LoginForm() //LoginForm 클래스의 생성자
        {
            InitializeComponent(); //폼이 생성될때 실행되는 초기화 코드
            Shown += form_shown; //Shown 이벤트에 form_shown 메서드를 추가함.
        }

        private void form_shown(object sender, EventArgs e) //폼이 화면에 표시될때 실행되는 이벤트 핸들러. 
        {
            txtID.Focus(); //txtID 텍스트상자에 포커스를 설정한다.
        }

        private void button1_Click(object sender, EventArgs e) //button1을 클릭할때 실행되는 이벤트 핸들러
        {
            if (string.IsNullOrEmpty(txtID.Text)) //만약 txtID 텍스트상자에 값이 비어있다면
            {
                MessageBox.Show("닉네임을 입력해주세요."); //닉네임을 입력하라는 메세지박스를 띄운다.
            }
            else //그렇지않으면
            {
                Program.userName = txtID.Text; //입력된 닉네임을 Program.userName에 저장한다.
                MessageBox.Show("게임을 시작합니다."); //게임시작을 알리는 메세지박스를 띄운다.
                this.Hide(); //현재 폼을 숨기고
                GameForm form1 = new GameForm(); //GameForm 인스턴스를 생성
                form1.Show(); //생성한 GameForm 인스턴스를 보여줌.
            }
        }

    }
}

