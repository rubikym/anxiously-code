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
                    Console.WriteLine("The value entered has not been validated.");
                }
            }
            while (!thisIsNumber);

            Console.WriteLine(String.Format("Total steps completed:{0}", GetNumberOfSteps(outputNumber)));
            Console.ReadLine();
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
