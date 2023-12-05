//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static Running_game.GameForm;
//using System.Windows.Forms;

//namespace Running_game
//{
//    public abstract class GameObject<T> : IMovable
//    {
//        protected PictureBox PictureBox { get; private set; }
//        protected Random Random { get; private set; }

//        protected int X { get; set; }

//        public GameObject(PictureBox pictureBox, Random random)
//        {
//            PictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));
//            Random = random ?? throw new ArgumentNullException(nameof(random));
//        }

//        public abstract void Move(int speed);

//        public void ResetLocation(int minX, int maxX)
//        {
//            X = Random.Next(minX, maxX);
//            PictureBox.Location = new Point(X, 0);
//        }

//        public PictureBox GetPictureBox()
//        {
//            return PictureBox;
//        }

//        // 인덱서: PictureBox의 위치를 가져오는 인덱서
//        public int this[string coordinate]
//        {
//            get
//            {
//                if (coordinate.ToLower() == "x")
//                    return PictureBox.Location.X;
//                else if (coordinate.ToLower() == "y")
//                    return PictureBox.Location.Y;
//                else
//                    throw new ArgumentException("Invalid coordinate");
//            }
//        }
//    }

//    public class Heart : GameObject<Heart>
//    {
//        // 수정: collectedHeart 필드 추가
//        private int collectedHeart;

//        public Heart(PictureBox pictureBox, Random random) : base(pictureBox, random) { }

//        public override void Move(int speed)
//        {
//            if (PictureBox.Top >= Height)
//            {
//                ResetLocation(0, 400);
//            }
//            else
//            {
//                PictureBox.Top += speed;
//            }
//        }

//        // 연산자 중복: 하트 수를 증가시키는 연산자 중복
//        public static Heart operator +(Heart heart, int value)
//        {
//            heart.collectedHeart += value;
//            return heart;
//        }

//        // 수정: collectedHeart 프로퍼티 추가
//        public int CollectedHeart
//        {
//            get { return collectedHeart; }
//        }
//    }
//    private class Obstacle : GameObject<Obstacle>
//    {
//        public Obstacle(PictureBox pictureBox, Random random) : base(pictureBox, random) { }

//        public override void Move(int speed)
//        {
//            if (PictureBox.Top >= Height)
//            {
//                ResetLocation(0, 700);
//            }
//            else
//            {
//                PictureBox.Top += speed;
//            }
//        }
//    }
//}


