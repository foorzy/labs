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

namespace TuringMachine
{
    public partial class Form1 : Form
    {
        private readonly TuringMachine _machine = new TuringMachine();
        
        int lastCharIndex = 0;
        int curState;

        public Form1()
        {
            InitializeComponent();
        }
        private void SubmitInputString(object sender, EventArgs e)
        {
            var turingLine = InputTuringString();
            
            _machine.ReadDataFromFile("..//..//..//example.txt");
            lastCharIndex = _machine.InitializeStringToWorkWith(turingLine);
            DrawTuringLine();
        }
        public List<char> InputTuringString()
        {
            List<char> turingLine = new List<char>();

            string inputStr = richTextBox1.Text;
            foreach (var item in inputStr)
            {
                turingLine.Add(item);
            }
            return turingLine;
        }

        
        public void DrawTuringLine()
        {
            var symbols = _machine.lineToWorkWIth;

            richTextBox3.Clear();
            string text = "";
            foreach (var item in symbols)
            {
                text += item;
            }

            richTextBox2.Text = text;

            richTextBox2.Text += "\n";
            string spaces = "";
            for (int i = 0; i < _machine.currentChar; i++)
            {
                spaces += " ";
            }

            spaces += "🠡";
            richTextBox2.Text += spaces;

            TransitionsDataContainer tr = _machine.CurrentTransition;

            List<Transition> moves = tr.allTransitions;

            foreach (var item in moves)
            {
                string text1 = "";
                text1 +=item.vertex + "|" + item.changedVertex + "," + item.move + "\n" + "\n";
                richTextBox3.Text += text1;
            }

            string state = "";
            curState = tr.state;
            if (tr.state == 0)
                state = "non final";
            else if (tr.state == 1)
                state = "final";
            richTextBox3.Text += "state: " + state;
            
        }
        
        private void MoveReadHead(object sender, EventArgs e)
        {
            
            richTextBox2.Clear();
            _machine.MakeOneMove();
            DrawTuringLine();
        }

        private void RichTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clear(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            _machine.Clear();
        }

        public void MakeAllTransitions(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                _machine.MakeOneMove();
            }
            DrawTuringLine();
        }
    }
}
