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
            var outputNumber = GetNaturalNumber();
            Console.WriteLine(String.Format("Total steps completed:{0}", GetNumberOfSteps(outputNumber)));
            Console.ReadLine();
        }

        private static ulong GetNaturalNumber()
        {
            var thisIsNumber = false;
            var outputNumber = 0UL;
            do
            {
                Console.WriteLine("Enter natural number");
                var outputString = Console.ReadLine();
                if (UInt64.TryParse(outputString, out var number))
                {
                    outputNumber = number;
                    thisIsNumber = true;
                }
                else
                {
                    Console.WriteLine(GetErrorMessage(outputString));
                }
            }
            while (!thisIsNumber);
            return outputNumber;
        }

        private static string GetErrorMessage(string outputString)
        {
            switch (outputString)
            {
                case var _ when Int32.TryParse(outputString, out var i) && i <= 0:
                    return "You can't enter value less than zero";
                case var _ when Double.TryParse(outputString, out var _):
                    return "You can't enter a fractional value";
                default:
                    return "you can not enter not number";
            }
        }

        private static long GetNumberOfSteps(ulong outputNumber)
        {
            var step = 0;
            foreach (var number in new CollatzSequence(outputNumber))
            {
                ++step;
                if (number == 1)
                {
                    break;
                }
            }
            return step;
        }
    }
}
