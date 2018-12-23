using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzProject
{
    public class Validation
    {
        public string InputString { get; set; }
        public string ErrorMessage { get; set; }
        private double inputSymbols;
        private ulong inputNumber;

        public Validation(string number)
        {
            InputString = number;
            CheckNumber();
            CheckNaturalnessNumber();
            CheckNegativeNumbers();
        }

        public Validation(ulong value)
        {
            CheckOverflow(value);
        }

        private string CheckNumber()
        {
            if (!double.TryParse(InputString, out inputSymbols))
            {
                ErrorMessage = "Введенные символы не являются числом";
            }
            return ErrorMessage;
        }

        private string CheckNaturalnessNumber()
        {
            if (inputSymbols != 0 && !UInt64.TryParse(InputString, out inputNumber))
            {
                ErrorMessage = "Введеное число не должно быть дробным";
            }
            return ErrorMessage;
        }

        private string CheckNegativeNumbers()
        {
            if (inputNumber != 0 && inputNumber < 0)
            {
                ErrorMessage = "Число должно быть больше нуля";
            }
            return ErrorMessage;
        }

        private string CheckOverflow(ulong x)
        {
            if (!(x < ((UInt64.MaxValue - 1) / 3)))
            {
                ErrorMessage = "Число вышло за пределы UInt64";
            }
            return ErrorMessage;
        }
    }
}
