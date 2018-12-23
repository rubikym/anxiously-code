using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = DisplayAndIntroduce();

            while (!Validated(console.inputValue))
            {
                console = DisplayAndIntroduce();
            }
            var calculation = new CollatzСalculations(UInt64.Parse(console.inputValue));
            DisplayAndIntroduce(calculation.MessageAboutSteps + calculation.NumberSteps.ToString());
        }

        private static WorkWithConsole DisplayAndIntroduce(string outputValue = "")
        {
            WorkWithConsole console;
            if (String.IsNullOrEmpty(outputValue))
            {
                console = new WorkWithConsole();
            }
            else
            {
                console = new WorkWithConsole(outputValue);
            }

            console.OutputValue();
            console.EnterValue();
            return console;
        }

        private static bool Validated(string value)
        {
            var validation = new Validation(value);
            while (!String.IsNullOrEmpty(validation.ErrorMessage))
            {
                var console = new WorkWithConsole(validation.ErrorMessage);
                console.OutputValue();
                return false;
            }
            return true;
        }
    }
}
