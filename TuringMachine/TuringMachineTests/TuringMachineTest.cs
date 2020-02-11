using Microsoft.VisualStudio.TestTools.UnitTesting;
using TuringMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine.Tests
{
    [TestClass]
    public class TuringMachineTest
    {
        [TestMethod]
        public void Initialize()
        {
            //arrange
            var machine = new TuringMachine();
            var turingLine = new List<char>();
            
            //act
            var result = machine.InitializeStringToWorkWith(turingLine);

            //assert
            Assert.AreEqual(0, result);
            Assert.AreEqual(0, machine.transitions.Count);
            Assert.AreEqual(40, machine.lineToWorkWIth.Count);
        }

        [TestMethod]
        public void ReadData()
        {
            //arrange
            var machine = new TuringMachine();
            var turingLine = new List<char>();

            //act
            machine.ReadDataFromFile("D:\\proga\\algorithms 3k\\TuringMachine\\example.txt");

            //assert
            Assert.AreEqual(5, machine.transitions.Count);
        }

        [TestMethod]
        [DataRow("1111", "********************0000********************")]
        [DataRow("1*1", "********************0*1********************")]
        [DataRow("0000", "********************1111********************")]
        [DataRow("11*1", "********************00*1********************")]
        [DataRow("0101", "********************1010********************")]
        [DataRow("0*1", "********************1*1********************")]
        [DataRow("10*1", "********************01*1********************")]
        [DataRow("0011", "********************1100********************")]
        [DataRow("*00", "*********************11********************")]
        [DataRow("101010", "********************010101********************")]
        [DataRow("00*11", "********************11*11********************")]
        [DataRow("00*00", "********************11*00********************")]
        [DataRow("11*11", "********************00*11********************")]
        [DataRow("1*1*1", "********************0*1*1********************")]
        [DataRow("0*0*1", "********************1*0*1********************")]
        public void ExecuteMachine1(string data, string expectedResult)
        {
            //arrange
            var machine = new TuringMachine();
            var turingLine = new List<char>();
            machine.ReadDataFromFile("D:\\proga\\algorithms 3k\\TuringMachine\\ex2.txt");

            //act
            machine.InitializeStringToWorkWith(data.ToCharArray());
            for (int i = 0; i < 100; i++)
            {
                machine.MakeOneMove();
            }

            //assert
            Assert.AreEqual(expectedResult, machine.Result);
        }

        [TestMethod]
        [DataRow("11*11", "********************1111*********************")]
        [DataRow("1111", "********************1111********************")]
        [DataRow("1*1*1", "********************11**1********************")]
        [DataRow("1*111*11", "********************1111**11********************")]
        [DataRow("1", "********************1********************")]
        [DataRow("1*1", "********************11*********************")]
        [DataRow("1111*111", "********************1111111*********************")]
        [DataRow("*11*", "*********************11*********************")]
        [DataRow("11111*111*", "********************11111111**********************")]
        [DataRow("1*1111", "********************11111*********************")]

        public void ExecuteMachine2(string data, string expectedResult)
        {
            //arrange
            var machine = new TuringMachine();
            var turingLine = new List<char>();
            machine.ReadDataFromFile("D:\\proga\\algorithms 3k\\TuringMachine\\example.txt");

            //act
            machine.InitializeStringToWorkWith(data.ToCharArray());
            for (int i = 0; i < 100; i++)
            {
                machine.MakeOneMove();
            }

            //assert
            Assert.AreEqual(expectedResult, machine.Result);
        }
    }
}