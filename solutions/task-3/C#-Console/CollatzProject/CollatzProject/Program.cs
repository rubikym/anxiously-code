using System;

namespace CollatzProject
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                var outputNumber = ReadNaturalNumber();
                try
                {
                    Console.WriteLine($"Total steps completed: {CalculateNumberOfSteps(outputNumber)}");
                }
                catch (CollatzOverflowExeption e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
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
