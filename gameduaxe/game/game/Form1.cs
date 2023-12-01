using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        PictureBox[] ptboxaray;
        PictureBox[] ptboxcar;
       
        int speed = 2;
        public Form1()
        {
            InitializeComponent();
            ptboxaray = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox7,pictureBox8,pictureBox12,pictureBox13,pictureBox14,pictureBox15,pictureBox16,pictureBox17, pictureBox5, pictureBox6,pictureBox18,pictureBox19, pictureBox23, pictureBox22};
            ptboxcar = new PictureBox[] { carlock1, carlock2, carlock3, carlock4,carlock5};
            gameover();
            diemso();
            foreach (PictureBox ptcar in ptboxcar)
            {
                carmove(ptcar, speed);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(PictureBox ptb in ptboxaray)
                {
                    linemove(ptb, speed);

                }
            foreach(PictureBox ptcar in ptboxcar)
                {
                    carmove(ptcar, speed);
                }
            gameover();
            diemso();

        }
        Random rnd = new Random();
        Random rnd2 = new Random();
        void carmove(PictureBox ptcar, int speed)
        {
            if (ptcar.Top > 550)
            {
                do
                {
                    ptcar.Left = rnd.Next(48, 250);
                    ptcar.Top = rnd2.Next(-200, -100);
                } while (giaonhau(ptcar));
                diem++;
            }
            else
            {
                ptcar.Top +=speed;
            }
        }
        void linemove(PictureBox ptb, int speed)
        {
            if (ptb.Top > 550)
            {
                ptb.Top = -ptb.Size.Height;
            }
            else
            {
                ptb.Top += speed;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left&&mycar.Left>37)
            {
                mycar.Left -= 8;
            }
            if (e.KeyCode == Keys.Right&&mycar.Left<251)
            {
                mycar.Left += 8;
            }
            if (e.KeyCode == Keys.Up)
            {
                if(speed < 16)
                {
                    speed++;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (speed > 1)
                {
                    speed--;
                }
            }
        }
        void moveonover(PictureBox carmu)
        {
            do
            {
                carmu.Left = rnd.Next(48, 250);
                carmu.Top = rnd2.Next(-800,-50);
            } while (giaonhau(carmu));
        }
        bool giaonhau(PictureBox carmu)
        {
            foreach (PictureBox xe in ptboxcar)
            {
                if (carmu != xe && carmu.Bounds.IntersectsWith(xe.Bounds))
                {
                    return true; // Nếu có giao nhau với bất kỳ xe nào khác
                }
            }
            return false; // Nếu không giao nhau với bất kỳ xe nào
        }
        bool dungxe()
        {
            foreach(PictureBox xe in ptboxcar)
            {
                if (mycar.Bounds.IntersectsWith(xe.Bounds))
                {
                    return true;
                }
            }
            return false;
        }
        void gameover()
        {
            if(dungxe())
            {
                timer1.Enabled = false;
                DialogResult rs = MessageBox.Show("bạn muốn chơi lại không ?\nĐiểm số:"+diem.ToString(), "ngu vai o",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                switch (rs)
                {
                    case DialogResult.Yes:
                        timer1.Enabled = true;
                        diem = 0;
                        foreach(PictureBox camu in ptboxcar)
                        {
                            moveonover(camu);
                        }
                        speed = 2;
                        break;
                    case DialogResult.No:
                        this.Close();
                        break;
                }
            }
        }
        int diem = 0;
        void diemso()
        {
            textBox1.Text=diem.ToString();
        }
        private void carlock4_Click(object sender, EventArgs e)
        {

        }
    }
}
