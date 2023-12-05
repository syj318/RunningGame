using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Running_game.GameForm;
using System.Windows.Forms;

namespace Running_game
{

    public abstract class GameObject //장애물, 하트에 대한 Object추상클래스 생성
    {
        public PictureBox pictureBox; //프로퍼티 : 둘다 이미지 형태
        public abstract void Move(); //메서드 : 위에서 아래로 내려오는 기능
        public abstract PictureBox CreateRamdomPictureBox(); //메서드 : 랜덤으로 이미지가 생성
        public abstract void CheckPlayerCollision(); //메서드 : 물체와 사람의 충돌을 확인
        public abstract void RemovePictureBox();
    }

    public class ObstacleObjcet : GameObject //추상클래스 상속 : 장애물
    {
        public override void CheckPlayerCollision()
        {
            
        }

        public override void Move()
        {
            
        }

        public override PictureBox CreateRamdomPictureBox()
        {
            return pictureBox;
        }

        public override void RemovePictureBox()
        {
           
        }
    }

    public class HeartObject : GameObject //추상클래스 상속 : 하트
    {
        public override void CheckPlayerCollision()
        {
            
        }

        public override PictureBox CreateRamdomPictureBox()
        {
            return pictureBox;
        }

        public override void Move()
        {
            
        }

        public override void RemovePictureBox()
        {
           
        }
    }


    //public interface IMovable
    //{
    //    void Move(int speed);
    //}
    //public abstract class GameObject<T> : IMovable
    //{
    //    protected PictureBox PictureBox { get; private set; }
    //    protected Random Random { get; private set; }

    //    protected int X { get; set; }

    //    public GameObject(PictureBox pictureBox, Random random)
    //    {
    //        PictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));
    //        Random = random ?? throw new ArgumentNullException(nameof(random));
    //    }

    //    public abstract void Move(int speed);

    //    public void ResetLocation(int minX, int maxX)
    //    {
    //        X = Random.Next(minX, maxX);
    //        PictureBox.Location = new Point(X, 0);
    //    }

    //    public PictureBox GetPictureBox()
    //    {
    //        return PictureBox;
    //    }


    //}

    //public class Heart : GameObject<Heart>
    //{
    //    // 수정: collectedHeart 필드 추가
    //    private int collectedHeart;

    //    public Heart(PictureBox pictureBox, Random random) : base(pictureBox, random) { }

    //    public override void Move(int speed)
    //    {
    //        if (PictureBox.Top >= Height)
    //        {
    //            ResetLocation(0, 400);
    //        }
    //        else
    //        {
    //            PictureBox.Top += speed;
    //        }
    //    }

    //    // 연산자 중복: 하트 수를 증가시키는 연산자 중복
    //    public static Heart operator +(Heart heart, int value)
    //    {
    //        heart.collectedHeart += value;
    //        return heart;
    //    }

    //    // 수정: collectedHeart 프로퍼티 추가
    //    public int CollectedHeart
    //    {
    //        get { return collectedHeart; }
    //    }
    //}
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
}


