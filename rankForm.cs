using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Running_game
{
    public partial class RankForm : Form //RankForm 클래스 정의
    {
  
        public RankForm() //RankForm 클래스의 생성자. 
        {
            InitializeComponent(); //RankForm의 구성요소 초기화
            
            string[] sitems = new string[] { Program.userName, GameForm.collectedHeart.ToString() }; //배열 sitems 생성. 첫번째 열에는 Program.userName 사용자 이름, 두번째 열에는 GameForm.collectedHeart 획득한 하트수를 문자열로 저장한다. 
            ListViewItem lvi = new ListViewItem(sitems); //ListView에 추가할 새로운 리스트 아이템을 생성한다. 여기에는 sitems 배열 정보가 반영됨.
            listView1.Items.Add(lvi);//ListView(listView1)에 새로운 리스트 아이템lvi를 추가함. 이를 통해 사용자 이름과 획득한 하트의 수가 나타남.
            List<ListViewItem> list = CSVUtil.LoadCSV(); // CSV파일에서 데이터를 읽어와서 List<ListViewItem> 형태로 저장함.
            list.ForEach(item => { listView1.Items.Add(item); }); //CSV파일에서 읽어온 각각의 리스트 아이템을 ListView에 추가
            listView1.EndUpdate(); //ListView의 업데이트를 종료함.

        }

       
        public void AddMember(string name , string score) //새로운 멤버를 추가하는 메서드
        {
            string[] sitems = new string[] { name, score }; //새로운 멤버의 정보를 담은 배열을 생성. 첫번째 열에는 닉네임, 두번째 열에는 점수가 들어감. 
            ListViewItem lvi = new ListViewItem(sitems); //새로운 리스트 아이템 생성. ListView에 추가될 한 행을 나타낸다.
            listView1.Items.Add(lvi); //listView1에 추가하여 새로운 멤버가 나타남.
            listView1.EndUpdate(); //업데이트를 종료함.
        }

        private void button1_Click(object sender, EventArgs e)//추가버튼인 button1 버튼을 클릭하면 실행되는 이벤트 핸들러.
        {
            listView1.BeginUpdate(); //listView1의 업데이트를 시작한다. 여러 아이템을 추가할때 화면 갱신을 최소화하기 위한 것.
            string name = textBox1.Text.ToString(); //textBox1에 입력된 테스트를 읽어와서 name 변수에 저장한다.
            string score = textBox2.Text.ToString(); //textBox2에 입력된 테스트를 읽어와서 score 변수에 저장한다.
     
            AddMember(name,score);//AddMember 메서드를 호출해서 listView1에 새로운 멤버를 추가한다. name은 첫번째열에 추가하고, score은 두번째 열에 추가한다.
            listView1.EndUpdate(); //listView1의 업데이트를 종료함.
            
        }

        private void btnClose_Click(object sender, EventArgs e) //닫기버튼인 btnClose버튼을 클릭했을때 실행되는 이벤트 핸들러
        {
            Close(); //현재 RankForm을 닫는다.
        }

        private void btnClear_Click_1(object sender, EventArgs e) //삭제버튼인 btnClear버튼을 클릭했을때 실행되는 이벤트 핸들러
        {
            if(listView1.SelectedItems.Count > 0) //선택된 아이템이 있다면
            {
                listView1.Items.Remove(listView1.SelectedItems[0]); //그 선택된 것을 제거한다.
            }
        }

        private void btnFileSave_Click(object sender, EventArgs e) //저장버튼인 btnFileSave을 클릭하면 실행되는 이벤트 핸들러
        {
            List<ListViewItem> listViewItemsList = listView1.Items.Cast<ListViewItem>().ToList(); //listView1의 모든 아이템을 ListViewItem으로 캐스트(다른 데이터 타입으로 변환하는것)하고 리스트로 만든다.
            CSVUtil.SaveCSV(listViewItemsList); //CSVUtil클래스의 SaveCSV메서드를 사용해서 listViewItemsList를 CSV 파일로 저장한다.
        }

        private void button2_Click(object sender, EventArgs e) //수정버튼인 button2버튼을 클릭했을때 실행되는 이벤트 핸들러
        {
            if (listView1.SelectedItems.Count > 0) //listView1에서 선택된 아이템이 하나 이상이면
            {
                listView1.SelectedItems[0].SubItems[0].Text = textBox1.Text; //첫번째 선택된 아이템의 첫번째 하위 항목의 텍스트를 textBox1의 텍스트로 설정한다. 
                listView1.SelectedItems[0].SubItems[1].Text = textBox2.Text; //첫번째 선택된 아이템의 두번째 하위 항목의 텍스트를 textBox2 텍스트로 설정한다. 
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) //listView1에서 선택한 아이템이 변경되었을때 실행되는 이벤트 핸들러
        {
            if (listView1.SelectedItems.Count > 0) //선택된 아이템이 있다면
            {
                textBox1.Text = listView1.SelectedItems[0].Text; //첫번째 선택된 아이템 이름을 textBox1에 표시하고
                textBox2.Text = listView1.SelectedItems[1].Text; //두번째 선택된 아이템 이름을 textBox2에 표시한다.
            }
        }

    }

   
}
