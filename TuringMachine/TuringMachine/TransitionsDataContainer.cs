using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public class TransitionsDataContainer
    {
        public List<Transition> allTransitions = new List<Transition>();
        public int currentPoint;
        public int state;
    }
}
