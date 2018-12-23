using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzProject
{
    public class CollatzСalculations
    {
        public ulong NumberSteps { get; set; }
        public StringBuilder MessageAboutSteps { get; set; }

        public CollatzСalculations(ulong number)
        {
            MessageAboutSteps = new StringBuilder("Количество выполненых шагов:");
            GetNumberSteps(number);
        }

        private void GetNumberSteps(ulong inputNumber)
        {
            for (NumberSteps = 0; inputNumber > 1; NumberSteps++)
            {
                if (DefineEvenNumber(inputNumber))
                {
                    inputNumber = inputNumber / 2;
                }
                else
                {
                    var validate = new Validation(inputNumber);
                    if (!String.IsNullOrEmpty(validate.ErrorMessage))
                    {
                        BuildMessage(validate.ErrorMessage);
                        return;
                    }
                    inputNumber = inputNumber * 3 + 1;
                }
            }
        }

        private bool DefineEvenNumber(ulong value)
        {
            if (value % 2 == 0)
            {
                return true;
            }
            return false;
        }

        private void BuildMessage(string errorMessage)
        {
            MessageAboutSteps = new StringBuilder(errorMessage + " на шаге:");
        }
    }
}
