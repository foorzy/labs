using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleSort
{
    public partial class FomrParametrs : Form
    {

        public FomrParametrs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parametrs.Ot = Convert.ToInt32(textBox1.Text);
            Parametrs.Do = Convert.ToInt32(textBox2.Text);
            Parametrs.Shag = Convert.ToInt32(textBox3.Text);
            Parametrs.Progonok = Convert.ToInt32(textBox4.Text);

            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
