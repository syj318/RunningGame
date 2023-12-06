using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Running_game //네임스페이스 정의. 이름은 Running_game
{
    public partial class StartForm : Form //StartForm 클래스 정의. Form 클래스를 상속받는다. 
    {
        public StartForm() //StartForm 클래스의 생성자
        {
            InitializeComponent(); //디자이너에서 생성된 코드 초기화
        }

       
        private void button1_Click(object sender, EventArgs e) //button_1을 클릭할때 실행되는 이벤트 핸들러
        {
            LoginForm form4 = new LoginForm(); //LoginForm 인스턴스를 생성하고
            form4.Show(); //LoginForm 을 화면에 나타낸다.
        }

        private void button2_Click(object sender, EventArgs e) //button_2를 클릭할때 실행되는 이벤트 핸들러
        {
            Close(); //현재폼을 닫는 메서드 Close()를 호출하여 종료한다.
        }
    }
}
