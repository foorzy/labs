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
    public partial class NewPerson : Form
    {
        public NewPerson()
        {
            InitializeComponent();
        }

        //кнопка добавления писателя
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxRate.Text!="" )
            {
                int a = 1;
                int b = SearchClass.Lenear(Mainform.keys, Convert.ToInt32(textBoxRate.Text), ref a);
                if (b == -1)
                {
                    Mainform.keys.Add(Convert.ToInt32(textBoxRate.Text));
                    Mainform.people.Add(Convert.ToInt32(textBoxRate.Text), textBoxName.Text);
                }
                else MessageBox.Show("Такой номер уже есть!");
                this.Hide();
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        //проверка цифр
        private void textBoxRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }          
        }
    }
}
