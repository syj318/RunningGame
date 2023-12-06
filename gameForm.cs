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
    public partial class GameForm : Form //GameForm 클래스 정의
    {

        static public int collectedHeart = 0; //GameForm 클래스 내에서 정적으로 사용되는 정수형 프로퍼티, collectedHeart 선언하고 초기값을 0으로 설정한다. 게임중 획득한 하트의 개수를 저장하는 변수이다.

        List<GameObject> Objects = new List<GameObject>(); //GameObject 클래스의 인스턴스들을 저장하는 List를 선언하고 초기화한다. 게임 내에서 움직이는 여러 객체를 관리하기 위한 리스트.


        public GameForm() //GameForm 클래스의 생성자
        {
            InitializeComponent();
            InitializeThread();
        }

        public RankForm RankForm
        {
            get => default;
            set
            {
            }
        }

        private void InitializeThread() //게임 객체들을 초기화하는 메서드. 장애물과 하트 객체들을 초기화 하고 폼에 추가한다.
        { 
            this.Objects = new List<GameObject> { 
                new ObstacleObjcet(1),
                new ObstacleObjcet(2),
            }; //게임에 사용될 여러 객체들을 초기화한다.

            for (int i = 0; i < 3; i++) //하트 객체 3개를 추가하는 for문
            {
                this.Objects.Add(new HeartObject());
            }

            this.Objects.ForEach(obj => { 
                this.Controls.Add(obj.CreateRamdomPictureBox(this.resources)); 
            }); //초기화된 객체들을 폼에 추가한다.
        }

        private void timer1_Tick(object sender, EventArgs e) //타이머 이벤트 핸들러. 주기적으로 실행되며 모든 객체를 이동시키고 플레이어과 객체간의 충돌을 체크하고 그에 따른 이벤트를 처리한다.
        {

            this.Objects.ForEach(obj => { obj.Move(); }); //모든 객체들을 이동시킨다.
            foreach (var obj in Objects) //객체와의 충돌을 체크하고 이벤트를 처리함.
            {
                if (obj is ObstacleObjcet )
                {
                    if (obj.CheckPlayerCollision(PictureBox_Man))
                    {
                        //플레이어와 장애물 객체가 충돌하면 게임 종료 메시지 박스를 표시한다.
                        timer1.Enabled = false;
                        label.Visible = true;
                        button1.Visible = true; //장애물 객체1
                        button2.Visible = true; //장애물 객체2
                        button3.Visible = true; //하트 객체
                    }
                }
                else
                {
                    if (obj.CheckPlayerCollision(PictureBox_Man)) //플레이어와 하트객체가 충돌하면
                    {
                        collectedHeart += 1; //하트 개수가 충돌하는 횟수만큼 증가한다.
                        label_hearts.Text = $"♥ = {collectedHeart}"; //하트 라벨은 (♥ = 모인하트개수) 형태로 보인다.
                    }
                }
            }
        }



        private void gameForm_KeyDown(object sender, KeyEventArgs e) //키보드 입력 이벤트 핸들러. 키보드 입력에 따라 플레이어를 좌우로 이동시키는 코드
        {
            if (e.KeyCode == Keys.Left) //왼쪽 화살표 키를 눌렀을때
            {
                if (PictureBox_Man.Left > 0) //플레이어 왼쪽 위치가 0보다 크다면
                    PictureBox_Man.Left += -35; //왼쪽으로 35씩 이동한다.
            }
            if (e.KeyCode == Keys.Right) //오른쪽 화살표 키를 눌렀을때
            {
                if (PictureBox_Man.Right < 845 - PictureBox_Man.Width / 2) //오른쪽 끝에서 플레이어의 너비의 절반을 뺀값보다 작을때
                    PictureBox_Man.Left += 35; //오른쪽으로 35씩 이동한다.
            }
        }



        private void button1_Click(object sender, EventArgs e)//button1을 눌렀을때 실행되는 재시작 기능을하는 코드
        {
            Hide(); //재시작 버튼을 클릭하면 현재의 폼(게임오버된 폼)을 숨긴다.
            GameForm form1 = new GameForm(); //새로운 GameForm 인스턴스를 생성하고
            form1.Show(); //다시 게임실행 폼을 보여준다.
        }

        private void button2_Click(object sender, EventArgs e) //button2를 클릭하면 실행되는 종료 코드
        {
            Close(); //CLOSE 버튼을 누르면 종료되어 화면이 꺼진다.
        }

        private void button3_Click(object sender, EventArgs e)//button3을 클릭하면 실행되는 랭킹버튼 코드
        {
            RankForm form3 = new RankForm(); //랭킹폼을 생성하고
            form3.Show(); //랭킹폼을 보여준다.
        }

    }
}

