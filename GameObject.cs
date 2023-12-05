using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Running_game.GameForm;
using System.Windows.Forms;
using Running_game.Properties;
using System.Resources;
using System.ComponentModel;

namespace Running_game
{
    public interface IGameObject
    {
        PictureBox CreateRamdomPictureBox(System.ComponentModel.ComponentResourceManager resources); //메서드 : 랜덤으로 이미지가 생성
        bool CheckPlayerCollision(PictureBox PictureBox_Man); //메서드 : 물체와 사람의 충돌을 확인
    }

    public abstract class GameObject : IGameObject //장애물, 하트에 대한 Object추상클래스 생성
    {
        public PictureBox pictureBox; //프로퍼티 : 둘다 이미지 형태
        public Random random;
        public int speed = 10;
        public GameObject()
        {
            this.pictureBox = new PictureBox();
        }
        public void Move() //메서드 : 위에서 아래로 내려오는 기능
        {
            if (this.pictureBox.Top >= 840)
            {
                this.pictureBox.Top = this.random.Next(-100, 0);
                this.pictureBox.Left = this.random.Next(0, 800);
            }
            else
            {
                this.pictureBox.Top += this.speed;
            }
        }

        public abstract bool CheckPlayerCollision(PictureBox PictureBox_Man); //메서드 : 물체와 사람의 충돌을 확인

        public abstract PictureBox CreateRamdomPictureBox(ComponentResourceManager resources);
    }

    public class ObstacleObjcet : GameObject //추상클래스 상속 : 장애물
    {
        public int type;
        public ObstacleObjcet(int type)
        {
            this.type = type;
        }
        public override bool CheckPlayerCollision(PictureBox PictureBox_Man)
        {
            try
            {
                // 수정: 인덱서를 통해 PictureBox_Man의 좌표 가져오기
                if (PictureBox_Man.Bounds.IntersectsWith(this.pictureBox.Bounds))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public override PictureBox CreateRamdomPictureBox(System.ComponentModel.ComponentResourceManager resources)
        {
            if (this.type == 1)
            {
                this.pictureBox.Image = (Image)resources.GetObject("obstacle1");
            }
            else
            {
                this.pictureBox.Image = (Image)resources.GetObject("obstacle2");
            }
            this.random = new Random();

            this.pictureBox.Location = new Point(this.random.Next(0, 800), this.random.Next(-100, 0));
            this.pictureBox.Size = new Size(90, 120);
            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 20;
            return this.pictureBox;
        }

    }

    public class HeartObject : GameObject //추상클래스 상속 : 하트
    {
        public override bool CheckPlayerCollision(PictureBox PictureBox_Man)
        {

            try
            {
                // 수정: 인덱서를 통해 PictureBox_Man의 좌표 가져오기
                if (PictureBox_Man.Bounds.IntersectsWith(this.pictureBox.Bounds))
                {
                    this.pictureBox.Top = this.random.Next(-100, 0);
                    this.pictureBox.Left = this.random.Next(0, 800);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override PictureBox CreateRamdomPictureBox(System.ComponentModel.ComponentResourceManager resources)
        {
            this.random = new Random();

            this.pictureBox.Image = (Image)resources.GetObject("heart");
            this.pictureBox.Location = new Point(this.random.Next(0, 800), this.random.Next(-200, 0));
            this.pictureBox.Size = new Size(35, 35);
            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 20;

            return this.pictureBox;
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
    //private class Obstacle : GameObject<Obstacle>
    //{
    //    public Obstacle(PictureBox pictureBox, Random random) : base(pictureBox, random) { }

    //    public override void Move(int speed)
    //    {
    //        if (PictureBox.Top >= Height)
    //        {
    //            ResetLocation(0, 700);
    //        }
    //        else
    //        {
    //            PictureBox.Top += speed;
    //        }
    //    }
    //}
}


