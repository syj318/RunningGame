﻿namespace Running_game
{
    partial class GameForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.PictureBox_Man = new System.Windows.Forms.PictureBox();
            this.pictureBox_object1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_object2 = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.pictureBox_heart1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_heart2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_heart3 = new System.Windows.Forms.PictureBox();
            this.label_hearts = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Man)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_object1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_object2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_heart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_heart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_heart3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(390, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 150);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(390, 240);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 150);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Location = new System.Drawing.Point(390, 450);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 150);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.Location = new System.Drawing.Point(390, 660);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 150);
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.White;
            this.pictureBox7.Location = new System.Drawing.Point(390, -180);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(20, 150);
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            // 
            // PictureBox_Man
            // 
            this.PictureBox_Man.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox_Man.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Man.Image")));
            this.PictureBox_Man.Location = new System.Drawing.Point(329, 606);
            this.PictureBox_Man.Name = "PictureBox_Man";
            this.PictureBox_Man.Size = new System.Drawing.Size(130, 195);
            this.PictureBox_Man.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox_Man.TabIndex = 12;
            this.PictureBox_Man.TabStop = false;
            // 
            // pictureBox_object1
            // 
            this.pictureBox_object1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_object1.Image")));
            this.pictureBox_object1.Location = new System.Drawing.Point(30, 165);
            this.pictureBox_object1.Name = "pictureBox_object1";
            this.pictureBox_object1.Size = new System.Drawing.Size(74, 99);
            this.pictureBox_object1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_object1.TabIndex = 13;
            this.pictureBox_object1.TabStop = false;
            // 
            // pictureBox_object2
            // 
            this.pictureBox_object2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_object2.Image")));
            this.pictureBox_object2.Location = new System.Drawing.Point(681, 105);
            this.pictureBox_object2.Name = "pictureBox_object2";
            this.pictureBox_object2.Size = new System.Drawing.Size(91, 58);
            this.pictureBox_object2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_object2.TabIndex = 14;
            this.pictureBox_object2.TabStop = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Red;
            this.label.Font = new System.Drawing.Font("굴림", 70F, System.Drawing.FontStyle.Bold);
            this.label.ForeColor = System.Drawing.Color.Yellow;
            this.label.Location = new System.Drawing.Point(145, 183);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(540, 94);
            this.label.TabIndex = 15;
            this.label.Text = "Game Over";
            this.label.Visible = false;
            // 
            // pictureBox_heart1
            // 
            this.pictureBox_heart1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_heart1.Image")));
            this.pictureBox_heart1.Location = new System.Drawing.Point(237, 93);
            this.pictureBox_heart1.Name = "pictureBox_heart1";
            this.pictureBox_heart1.Size = new System.Drawing.Size(51, 50);
            this.pictureBox_heart1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_heart1.TabIndex = 16;
            this.pictureBox_heart1.TabStop = false;
            // 
            // pictureBox_heart2
            // 
            this.pictureBox_heart2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_heart2.Image")));
            this.pictureBox_heart2.Location = new System.Drawing.Point(589, 480);
            this.pictureBox_heart2.Name = "pictureBox_heart2";
            this.pictureBox_heart2.Size = new System.Drawing.Size(51, 48);
            this.pictureBox_heart2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_heart2.TabIndex = 16;
            this.pictureBox_heart2.TabStop = false;
            // 
            // pictureBox_heart3
            // 
            this.pictureBox_heart3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_heart3.Image")));
            this.pictureBox_heart3.Location = new System.Drawing.Point(609, 49);
            this.pictureBox_heart3.Name = "pictureBox_heart3";
            this.pictureBox_heart3.Size = new System.Drawing.Size(51, 50);
            this.pictureBox_heart3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_heart3.TabIndex = 16;
            this.pictureBox_heart3.TabStop = false;
            // 
            // label_hearts
            // 
            this.label_hearts.AutoSize = true;
            this.label_hearts.BackColor = System.Drawing.Color.White;
            this.label_hearts.Font = new System.Drawing.Font("굴림", 15F);
            this.label_hearts.ForeColor = System.Drawing.Color.Fuchsia;
            this.label_hearts.Location = new System.Drawing.Point(12, 18);
            this.label_hearts.Name = "label_hearts";
            this.label_hearts.Size = new System.Drawing.Size(60, 20);
            this.label_hearts.TabIndex = 17;
            this.label_hearts.Text = "♥ = 0";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("굴림", 50F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(212, 447);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(416, 81);
            this.button1.TabIndex = 18;
            this.button1.Text = "RESTART";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Font = new System.Drawing.Font("굴림", 50F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Yellow;
            this.button2.Location = new System.Drawing.Point(212, 559);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(416, 76);
            this.button2.TabIndex = 19;
            this.button2.Text = "CLOSE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.Font = new System.Drawing.Font("굴림", 50F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Yellow;
            this.button3.Location = new System.Drawing.Point(212, 329);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(416, 81);
            this.button3.TabIndex = 20;
            this.button3.Text = "RANK";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // gameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(784, 801);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_hearts);
            this.Controls.Add(this.pictureBox_heart3);
            this.Controls.Add(this.pictureBox_heart2);
            this.Controls.Add(this.pictureBox_heart1);
            this.Controls.Add(this.PictureBox_Man);
            this.Controls.Add(this.label);
            this.Controls.Add(this.pictureBox_object2);
            this.Controls.Add(this.pictureBox_object1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "gameForm";
            this.Text = "Running_Game";
            this.Load += new System.EventHandler(this.gameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Man)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_object1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_object2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_heart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_heart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_heart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox PictureBox_Man;
        private System.Windows.Forms.PictureBox pictureBox_object1;
        private System.Windows.Forms.PictureBox pictureBox_object2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBox_heart1;
        private System.Windows.Forms.PictureBox pictureBox_heart2;
        private System.Windows.Forms.PictureBox pictureBox_heart3;
        private System.Windows.Forms.Label label_hearts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

