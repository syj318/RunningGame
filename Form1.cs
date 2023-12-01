using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Running_game
{
    // 추상 클래스: GameObject (게임 오브젝트를 나타내는 추상 클래스)
    public abstract class GameObject
    {
        // 프로퍼티: PictureBox와 Random
        protected PictureBox PictureBox { get; private set; }
        protected Random Random { get; private set; }

        // 프로퍼티: X 좌표
        protected int X { get; set; }

        // GameObject 클래스의 생성자: PictureBox와 Random을 초기화
        public GameObject(PictureBox pictureBox, Random random)
        {
            PictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));
            Random = random ?? throw new ArgumentNullException(nameof(random));
        }

        // 추상 메서드: 게임 오브젝트를 이동시키는 역할
        public abstract void Move(int speed);

        // 메서드: 게임 오브젝트의 위치를 재설정
        public void ResetLocation(int minX, int maxX)
        {
            X = Random.Next(minX, maxX);
            PictureBox.Location = new Point(X, 0);
        }

        // 메서드: 게임 오브젝트에 연결된 PictureBox를 반환
        public PictureBox GetPictureBox()
        {
            return PictureBox;
        }
    }

    // Form1 클래스: Form, IMovable 인터페이스 상속
    public partial class Form1 : Form
    {
        // 상수: 게임 영역의 높이 및 이동 라인의 시작 위치
        const int Height = 840;
        const int LineStartTop = -210;

        // 수집한 하트 개수를 나타내는 변수
        int collectedheart = 0;

        // 랜덤 숫자를 생성하는 데 사용되는 Random 객체
        Random r = new Random();

        // 다양한 게임 오브젝트를 저장하는 리스트
        List<GameObject> gameObjects;

        // Form1 클래스의 생성자: 게임 초기화 및 게임 오브젝트 초기화
        public Form1()
        {
            InitializeComponent();
            InitializeGameObjects();
        }

        // 게임 오브젝트 초기화 메서드: 다양한 게임 오브젝트를 생성하고 리스트에 추가
        private void InitializeGameObjects()
        {
            gameObjects = new List<GameObject>
            {
                new Obstacle(pictureBox_object1, r),
                new Obstacle(pictureBox_object2, r),
                new Heart(pictureBox_heart1, r),
                new Heart(pictureBox_heart2, r),
                new Heart(pictureBox_heart3, r)
            };
        }

        // Timer의 Tick 이벤트 핸들러: 게임 상태를 진행
        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(10); // 이동하는 라인 이동
            gameObjects.ForEach(go => go.Move(10)); // 모든 게임 오브젝트 이동
            gameover(); // 게임 오버 상태 확인
            heartCollection(); // 하트 수집 확인
        }

        // 게임 오버 상태 확인 메서드
        private void gameover()
        {
            if (PictureBox_Man.Bounds.IntersectsWith(pictureBox_object1.Bounds) ||
                PictureBox_Man.Bounds.IntersectsWith(pictureBox_object2.Bounds))
            {
                timer1.Enabled = false; // 타이머 중지
                label.Visible = true; // 게임 오버 레이블 표시
            }
        }

        // 하트 수집 및 UI 업데이트 메서드
        private void heartCollection()
        {
            foreach (var heart in gameObjects.OfType<Heart>())
            {
                if (PictureBox_Man.Bounds.IntersectsWith(heart.GetPictureBox().Bounds))
                {
                    collectedheart++;
                    label_hearts.Text = "♥ = " + collectedheart.ToString();
                    heart.ResetLocation(0, 400);
                }
            }
        }

        // 이동하는 라인 이동 메서드
        private void moveline(int speed)
        {
            //... 기존 코드 ...
        }

        // 키다운 이벤트 핸들러: 플레이어 캐릭터 이동
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (PictureBox_Man.Left > 0)
                    PictureBox_Man.Left += -10;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (PictureBox_Man.Right < 845 - PictureBox_Man.Width / 2)
                    PictureBox_Man.Left += 10;
            }
        }

        // 폼 로드 이벤트 핸들러
        private void Form1_Load(object sender, EventArgs e)
        {
            //... 기존 코드 ...
        }

        // 레이블 클릭 이벤트 핸들러
        private void label_Click(object sender, EventArgs e)
        {
            //... 기존 코드 ...
        }

        // Obstacle 클래스: 게임에서의 장애물을 나타내는 클래스
        private class Obstacle : GameObject
        {
            // 생성자: 장애물을 초기화
            public Obstacle(PictureBox pictureBox, Random random) : base(pictureBox, random) { }

            // 장애물을 이동하는 메서드의 구현
            public override void Move(int speed)
            {
                if (PictureBox.Top >= Height)
                {
                    ResetLocation(0, 700);
                }
                else
                {
                    PictureBox.Top += speed;
                }
            }
        }

        // Heart 클래스: 게임에서의 수집 가능한 하트를 나타내는 클래스
        private class Heart : GameObject
        {
            // 생성자: 하트를 초기화
            public Heart(PictureBox pictureBox, Random random) : base(pictureBox, random) { }

            // 하트를 이동하는 메서드의 구현
            public override void Move(int speed)
            {
                if (PictureBox.Top >= Height)
                {
                    ResetLocation(0, 400);
                }
                else
                {
                    PictureBox.Top += speed;
                }
            }
        }
    }
}