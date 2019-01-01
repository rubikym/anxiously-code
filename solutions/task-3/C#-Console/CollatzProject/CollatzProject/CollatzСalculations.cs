using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzProject
{
    public class CollatzСalculations : IEnumerable<ulong>
    {

        public CollatzСalculations(ulong number)
        {
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

        private bool DefineEvenNumber(ulong value) => value % 2 == 0;

        public IEnumerable<ulong> GetCollatzСalculations(long outputValue)
        {
            
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            return new CollatzEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }

    public class CollatzEnumerator : IEnumerator<ulong>
    {
        private ulong[] collatzIEnumerator;
        int position = -1;

        public ulong Current => collatzIEnumerator[position];

        object IEnumerator.Current { get { return this.Current; } }

        public CollatzEnumerator()
        {

        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if(position < collatzIEnumerator.Length-1)
            {
                ++position;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset() => position = -1;
    }
}
