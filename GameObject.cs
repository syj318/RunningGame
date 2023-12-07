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
    public interface IGameObject //IGameObject 인터페이스 선언
    {
        GameForm GameForm { get; set; }

        PictureBox CreateRamdomPictureBox(System.ComponentModel.ComponentResourceManager resources); //메서드 : 랜덤으로 이미지가 생성되는 메서드 선언
        bool CheckPlayerCollision(PictureBox PictureBox_Man); //메서드 : 물체와 사람의 충돌을 확인하는 메서드 선언
    }

    public abstract class GameObject : IGameObject //추상클래스: 장애물, 하트에 대한 IGameObject 인터페이스를 구현하는 GameObject추상클래스 선언
    {
        public PictureBox pictureBox; //{ get; set; } //프로퍼티 : 장애물, 하트 둘다 이미지 형태
        public Random random; //{ get; set; } //프로퍼티: 장애물, 하트 둘다 랜덤함.
        public int speed = 10; //기본값이 10인 정수형 speed 필드를 선언함.

        public GameForm GameForm { get => throw new NotImplementedException(); set => throw new NotImplementedException(); } //GameForm 속성 정의

        public GameObject() //GameObject 클래스의 생성자
        {
            this.pictureBox = new PictureBox(); //새로운 PictureBox 인스턴스로 초기화함.
        }

        public void Move() //객체를 아래로 움직이는 메서드
        {
            if (this.pictureBox.Top >= 840) //현재 객체의 PictureBox의 Top속성이 840보다 크거나 같으면
            {
                this.pictureBox.Top = this.random.Next(-100, 0); //PictureBox를 화면 위쪽으로 다시 위치시킴. -100부터 0사이의 랜덤한 위치로 설정.
                this.pictureBox.Left = this.random.Next(0, 800); //PictureBox의 Left 속성을 0부터 800 사이의 랜덤한 위치로 설정.
            }
            else //Top이 840보다 크지 않으면
            {
                this.pictureBox.Top += this.speed; //PictureBox를 현재 속도만큼 아래로 이동시킴.
            }
        }

        public abstract bool CheckPlayerCollision(PictureBox PictureBox_Man); //추상메서드 : 물체(PictureBox)와 사람의 충돌을 확인

        public abstract PictureBox CreateRamdomPictureBox(ComponentResourceManager resources); //추상 메서드: 리소스를 사용하여 랜덤한 PictureBox를 생성함.
    }

    public class ObstacleObjcet : GameObject //추상클래스 상속 : 장애물 ObstacleObject 클래스 선언
    {
        public int type; //정수형 type 필드 선언
        public ObstacleObjcet(int type) //ObstacleObject 클래스의 생성자
        {
            this.type = type; //type 필드를 제공된 값으로 초기화함.
        }
        public override bool CheckPlayerCollision(PictureBox PictureBox_Man) //매서드 재정의: 44줄의코드 추상메서드를 재정의하고 있다. 플레이어와의 충돌을 확인하는 매서드
        {
            try //예외처리를 하기위한 try 블록 시작
            {
                if (PictureBox_Man.Bounds.IntersectsWith(this.pictureBox.Bounds)) //Picture_Man의 경계 상자가 현재 객체의 PictureBox의 경계 상자와 교차하는지 확인.
                {
                    return true; //충돌하면 ture 반환 
                }
                return false; //충돌하지않으면 false 반환
            }
            catch (Exception ex) //예외가 발생했을때 처리하기위한 catch블록 시작
            {
                return false; //예외가 발생하면 flase를 반환
            }
        }


        public override PictureBox CreateRamdomPictureBox(System.ComponentModel.ComponentResourceManager resources) //메서드 재정의: 46줄의 추상 메서드를 재정의하고있다.  
        {
            if (this.type == 1) //현재 ObstacleObject 객체의 type 속성이 1인 경우
            {
                this.pictureBox.Image = (Image)resources.GetObject("obstacle1"); //resources에서 obstacle1이라는 이름의 이미지를 가져와서 현재 pictureBox에 설정함.
            }
            else //type이 1이 아닌 경우
            {
                this.pictureBox.Image = (Image)resources.GetObject("obstacle2"); //resources에서 obstacle2라는 이름의 이미지를 가져와서 현재 pictureBox에 설정함.
            }
            this.random = new Random(); //random 속성에 새로운 Random 객체 생성. 위치와 초기화를 무작위로 설정하는데에 사용됨.

            this.pictureBox.Location = new Point(this.random.Next(0, 800), this.random.Next(-100, 0));//pictureBox 위치를 X축은 0부터 800까지 설정하고, Y축은 -100부터 0까지의 무작위 좌표로 설정한다.
            this.pictureBox.Size = new Size(90, 120); //picutreBox 크기를 90,120으로 설정함.
            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; //이미지가 picutreBox에 맞게 조정되도록 SizeMode는 StretchImage로 설정함.
            this.pictureBox.TabIndex = 20; //pictureBox의 TableIndex를 20으로 설정함.
            return this.pictureBox; //구성이 완료된 pictureBox 객체를 반환한다.
        }

    }

    public class HeartObject : GameObject //추상클래스 GameObject 상속 : 하트객체
    {
        public override bool CheckPlayerCollision(PictureBox PictureBox_Man) //추상 메서드 재정의: 하트 객체와 플레이어 객체간의 충돌 확인
        {

            try //예외상황 처리를 위한 try블록
            {
                if (PictureBox_Man.Bounds.IntersectsWith(this.pictureBox.Bounds)) //플레이어 객체와 와 충돌했을때 실행, 플레이어 객체(PictureBox_Man)의 경계 상자(Bounds)가 현재 하트 객체(this.pictureBox)의 경계 상자와 교차하는지 확인
                {
                    this.pictureBox.Top = this.random.Next(-100, 0); //Y축 위치를 -100부터 0까지의 무작위 값으로 설정
                    this.pictureBox.Left = this.random.Next(0, 800); //X축 위치를 0부터 800까지의 무작위 값으로 설정

                    return true; //충돌 발생을 나타내기 위해 true 반환
                }
                return false; //충돌발생하지 않았을땐 false 반환
            }
            catch (Exception ex) //예외 발생한경우 처리하기위한 catch 블록
            {
                return false; //예외 발생시 false 반환
            }
        }

        public override PictureBox CreateRamdomPictureBox(System.ComponentModel.ComponentResourceManager resources) //메서드 재정의: 46줄의 추상메서드를 재정의함.
        {
            this.random = new Random(); //Random 클래스를 이용하여 난수 생성하기위한 객체 초기화

            this.pictureBox.Image = (Image)resources.GetObject("heart"); //PictureBox에 하트이미지 설정 : resources에서 heart 이름의 이미지를 가져와서 형변환하여 이미지로 설정함.
            this.pictureBox.Location = new Point(this.random.Next(0, 800), this.random.Next(-200, 0)); //PictureBox의 위치를 X축은 0부터 800까지, Y축은 -200부터 0까지의 무작위 좌표로 설정한다.
            this.pictureBox.Size = new Size(35, 35); //하트 이미지 크기는 35,35로 설정함.
            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; //하트이미지 SizeMode는 늘이거나 줄이는 방식 StretchImage 모드로 설정
            this.pictureBox.TabIndex = 20; //PictureBox의 탭 순서를 설정한다. 탭 키를 이용해 컨트롤을 탐색할 때 사용됨.

            return this.pictureBox; //설정된 하트이미지를 반환한다.
        }
    }
}

