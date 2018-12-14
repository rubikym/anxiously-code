using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzProject
{
    public class WorkWithConsole
    {
        public string outputValue { get; set; }
        public string inputValue { get; set; }

        public WorkWithConsole()
        {
            outputValue = "Введите натуральное число:";
        }

        public WorkWithConsole(string value)
        {
            outputValue = value;
        }

        public void OutputValue()
        {
            Console.WriteLine(outputValue);
        }

        public void EnterValue()
        {
            inputValue = Console.ReadLine();
        }
    }
}
