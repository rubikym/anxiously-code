using System;

namespace CollatzProject
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                var input = ReadNaturalNumber();
                try
                {
                    Console.WriteLine($"Total steps completed: {CalculateNumberOfSteps(input)}");
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

        private static long CalculateNumberOfSteps(ulong input)
        {
            var step = 0;
            foreach (var number in new CollatzSequence(input))
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
