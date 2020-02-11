using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace АЛГОРИТМЫ_______
{
    public partial class Famous_people : Form
    {
       
        public Famous_people()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        static int answer(int i)
        {
            return i;
        }

        private void Famous_people_Load(object sender, EventArgs e)
        {
            int a=Mainform.answers();
                                         
            if (a == 0)
            {
                pictureBoxHuman.Image = new Bitmap(@"1.jpg");
                pictureBoxHuman.ClientSize = new Size(330, 441);
                labelName.Text = "Fedor Dostoevskiy";
            }
            if (a == 1)
            {
                pictureBoxHuman.Image = new Bitmap(@"2.jpg");
                pictureBoxHuman.ClientSize = new Size(220,283);
                labelName.Text = "William Shakespeare";
            }
            if (a == 2)
            {
                pictureBoxHuman.Image = new Bitmap(@"3.jpg");
                pictureBoxHuman.ClientSize = new Size(270, 346);
                labelName.Text = "Anton Checkhov";
            }
            if (a == 3)
            {
                pictureBoxHuman.Image = new Bitmap(@"4.jpg");
                pictureBoxHuman.ClientSize = new Size(214, 317);
                labelName.Text = "James Joyce";
            }
            if (a == 4)
            {
                pictureBoxHuman.Image = new Bitmap(@"5.jpg");
                pictureBoxHuman.ClientSize = new Size(200, 272);
                labelName.Text = "William Faulkner";
            }
            if (a == 5)
            {
                pictureBoxHuman.Image = new Bitmap(@"6.jpg");
                pictureBoxHuman.ClientSize = new Size(220, 293);
                labelName.Text = "Franz Kafka";
            }
            if (a == 6)
            {
                pictureBoxHuman.Image = new Bitmap(@"7.jpg");
                pictureBoxHuman.ClientSize = new Size(262, 400);
                labelName.Text = "Vladimir Nabokov";
            }
            if (a == 7)
            {
                pictureBoxHuman.Image = new Bitmap(@"8.jpg");
                pictureBoxHuman.ClientSize = new Size(214, 317);
                labelName.Text = "Ernest Hemingway";
            }
            if (a == 8)
            {
                pictureBoxHuman.Image = new Bitmap(@"9.jpg");
                pictureBoxHuman.ClientSize = new Size(297, 300);
                labelName.Text = "Gustave Flaubert";
            }
            if (a == 9)
            {
                pictureBoxHuman.Image = new Bitmap(@"10.jpg");
                pictureBoxHuman.ClientSize = new Size(220, 275);
                labelName.Text = "Henry James";
            }
            if (a == 10)
            {
                pictureBoxHuman.Image = new Bitmap(@"11.jpg");
                pictureBoxHuman.ClientSize = new Size(200, 287);
                labelName.Text = "Jane Austen";
            }
            if (a == 11)
            {
                pictureBoxHuman.Image = new Bitmap(@"12.jpg");
                pictureBoxHuman.ClientSize = new Size(250, 329);
                labelName.Text = "Leo Tolstoy";
            }
            if (a == 12)
            {
                pictureBoxHuman.Image = new Bitmap(@"13.jpg");
                pictureBoxHuman.ClientSize = new Size(214, 317);
                labelName.Text = "Charles Dickens";
            }
        }
    }
}
