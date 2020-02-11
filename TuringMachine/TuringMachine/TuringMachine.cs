using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringMachine
{
    public class TuringMachine
    {
        public List<TransitionsDataContainer> transitions { get; private set; } = new List<TransitionsDataContainer>();
        public List<char> lineToWorkWIth { get; private set; } = new List<char>();
        private int currentPoint = 1;
        public int currentChar { get; private set; }

        public TransitionsDataContainer CurrentTransition {
            get
            {
                return transitions[currentPoint - 1];
            }
        }

        public string Result
        {
            get
            {
                var result = new StringBuilder();
                foreach (var item in lineToWorkWIth)
                {
                    result.Append(item);
                }
                return result.ToString();
            }
        }

        public void ReadDataFromFile(string path)
        {
            var dataFile = new StreamReader(path);

            int counter = 1;
            while (true)
            {
                TransitionsDataContainer dataContainer = new TransitionsDataContainer();

                string line = dataFile.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;
                string[] parts = line.Split(' ');

                foreach (var item in parts)
                {
                    if (item.Length != 1)
                    {
                        string[] transitionParts = item.Split(',');
                        Transition point = new Transition();
                        point.vertex = Convert.ToChar(transitionParts[0]);
                        point.changedVertex = Convert.ToChar(transitionParts[1]);
                        point.move = Convert.ToChar(transitionParts[2]);
                        point.pointTransition = Convert.ToInt32(transitionParts[3]);

                        dataContainer.allTransitions.Add(point);
                    }

                    else
                    {
                        dataContainer.currentPoint = counter;
                        dataContainer.state = Convert.ToInt32(item);
                    }
                }
                transitions.Add(dataContainer);
                counter++;
            }

            dataFile.Close();
        }

        public int InitializeStringToWorkWith(IList<char> turingLine)
        {
            var lastCharIndex = 0;
            for (int i = 0; i < 20; i++)
            {
                lineToWorkWIth.Add('*');
            }

            foreach (var item in turingLine)
            {
                lineToWorkWIth.Add(item);
            }

            for (int i = 0; i < 20; i++)
            {
                lineToWorkWIth.Add('*');
            }

            for (int i = 0; i < lineToWorkWIth.Count - 1; i++)
            {
                if (lineToWorkWIth[i] != '*')
                {
                    currentChar = i;
                    break;
                }
            }

            for (int i = lineToWorkWIth.Count - 1; i > 0; i--)
            {
                if (lineToWorkWIth[i] != '*')
                {
                    lastCharIndex = i;
                    break;
                }
            }

            return lastCharIndex;
        }

        public void MakeOneMove()
        {
            bool flag = false;
            bool isCharInLine = true;

            foreach (var transition in transitions)
            {
                char currentSymbol = lineToWorkWIth[currentChar];

                int counter = 0;
                foreach (var item in transitions)
                {
                    foreach (var li in item.allTransitions)
                    {
                        if(li.vertex == currentSymbol)
                        {
                            counter++;

                        }
                    }
                }

                if(counter == 0)
                {
                    isCharInLine = false;
                }

                if (!isCharInLine)
                {
                    MessageBox.Show("Rejected");
                    this.Clear();
                    break;
                }

                if (transition.currentPoint == currentPoint)
                {
                    foreach (var item in transition.allTransitions)
                    {
                        if (currentSymbol == item.vertex)
                        {
                            lineToWorkWIth[currentChar] = item.changedVertex;
                            currentPoint = item.pointTransition;

                            if (item.move == 'R')
                            {
                                currentChar++;
                                flag = true;
                                break;
                            }

                            else
                            {
                                currentChar--;
                                flag = true;
                                break;

                            }

                        }
                    }
                }


                if (flag == true)
                    break;
            }

        }

        public void Clear()
        {
            transitions.Clear();
            lineToWorkWIth.Clear();
            currentPoint = 1;
        }
    }
}
