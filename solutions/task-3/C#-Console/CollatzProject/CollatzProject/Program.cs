﻿using System;
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
                    Console.WriteLine(GetErrorMessage(input));
                }
            }
            while (true);
        }

        private static string GetErrorMessage(string outputString)
        {
            switch (outputString)
            {
                case var _ when Int32.TryParse(outputString, out var i) && i <= 0:
                    return "You can't enter value less or equal than zero";
                case var _ when Double.TryParse(outputString, out var _):
                    return "You can't enter a fractional value";
                default:
                    return "You can not enter not number";
            }
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
