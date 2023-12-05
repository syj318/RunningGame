using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Running_game
{
    public partial class GameForm : Form
    {
        const int Height = 840;

        int collectedHeart = 0;

        Random random = new Random();

        List<IMovable> movableObjects;

        public GameForm()
        {
            InitializeComponent();
            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            movableObjects = new List<IMovable>
            {
                new Obstacle(pictureBox_object1, random),
                new Obstacle(pictureBox_object2, random),
                new Heart(pictureBox_heart1, random),
                new Heart(pictureBox_heart2, random),
                new Heart(pictureBox_heart3, random)
            };
        }

        public interface IMovable
        {
            void Move(int speed);
        }

        public abstract class GameObject<T> : IMovable
        {
            protected PictureBox PictureBox { get; private set; }
            protected Random Random { get; private set; }

            protected int X { get; set; }

            public GameObject(PictureBox pictureBox, Random random)
            {
                PictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));
                Random = random ?? throw new ArgumentNullException(nameof(random));
            }

            public abstract void Move(int speed);

            public void ResetLocation(int minX, int maxX)
            {
                X = Random.Next(minX, maxX);
                PictureBox.Location = new Point(X, 0);
            }

            public PictureBox GetPictureBox()
            {
                return PictureBox;
            }

            // 인덱서: PictureBox의 위치를 가져오는 인덱서
            public int this[string coordinate]
            {
                get
                {
                    if (coordinate.ToLower() == "x")
                        return PictureBox.Location.X;
                    else if (coordinate.ToLower() == "y")
                        return PictureBox.Location.Y;
                    else
                        throw new ArgumentException("Invalid coordinate");
                }
            }
        }

        public class Heart : GameObject<Heart>
        {
            // 수정: collectedHeart 필드 추가
            private int collectedHeart;

            public Heart(PictureBox pictureBox, Random random) : base(pictureBox, random) { }

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

            // 연산자 중복: 하트 수를 증가시키는 연산자 중복
            public static Heart operator +(Heart heart, int value)
            {
                heart.collectedHeart += value;
                return heart;
            }

            // 수정: collectedHeart 프로퍼티 추가
            public int CollectedHeart
            {
                get { return collectedHeart; }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveLine(10);
            Parallel.ForEach(movableObjects, obj => obj.Move(10)); // 병렬 처리
            CheckGameOver();
            HeartCollection();
        }

        private void CheckGameOver()
        {
            try
            {
                // 수정: 인덱서를 통해 PictureBox_Man의 좌표 가져오기
                if (PictureBox_Man.Bounds.IntersectsWith(pictureBox_object1.Bounds) ||
                    PictureBox_Man.Bounds.IntersectsWith(pictureBox_object2.Bounds))
                {
                    timer1.Enabled = false;
                    label.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HeartCollection()
        {
            foreach (var heart in movableObjects.OfType<Heart>())
            {
                if (PictureBox_Man.Bounds.IntersectsWith(heart.GetPictureBox().Bounds))
                {
                    // 수정: Heart 클래스에서 수집된 하트 수를 가져와서 업데이트
                    collectedHeart += 1;
                    label_hearts.Text = $"♥ = {collectedHeart}";
                    heart.ResetLocation(0, 400);
                }
            }
        }

        private void MoveLine(int speed)
        {
            //... 기존 코드 ...
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

        private void gameForm_Load(object sender, EventArgs e)
        {
            //... 기존 코드 ...
        }

        private void label_Click(object sender, EventArgs e)
        {
            //... 기존 코드 ...
        }

        private class Obstacle : GameObject<Obstacle>
        {
            public Obstacle(PictureBox pictureBox, Random random) : base(pictureBox, random) { }

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

        // 인덱서: PictureBox의 위치를 가져오는 인덱서
        private int this[string coordinate, PictureBox pictureBox]
        {
            get
            {
                if (coordinate.ToLower() == "x")
                    return pictureBox.Location.X;
                else if (coordinate.ToLower() == "y")
                    return pictureBox.Location.Y;
                else
                    throw new ArgumentException("Invalid coordinate");
            }
        }
    }
}

