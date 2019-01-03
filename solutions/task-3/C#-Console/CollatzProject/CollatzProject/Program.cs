using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CollatzProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var outputNumber = ReadNaturalNumber();
            Console.WriteLine($"Total steps completed: {CalculateNumberOfSteps(outputNumber)}");
            Console.ReadLine();
        }

        private static ulong ReadNaturalNumber()
        {
            do
            {
                Console.WriteLine("Enter natural number");
                var input = Console.ReadLine();
                if (UInt64.TryParse(input, out var number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("The value entered is not natural number");
                }
            }
            while (true);
        }

        private static long CalculateNumberOfSteps(ulong outputNumber)
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
