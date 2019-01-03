using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzProject
{
    public class CollatzSequence : IEnumerable<ulong>
    {
        private ulong outputNumber;

        public CollatzSequence(ulong number)
        {
            outputNumber = number;
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            return new CollatzEnumerator(outputNumber);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }

    public class CollatzEnumerator : IEnumerator<ulong>
    {
        private ulong startingValue;
        private ulong currentValue;

        public CollatzEnumerator(ulong outputNumber)
        {
            currentValue = outputNumber;
            startingValue = outputNumber;
        }

        public ulong Current => currentValue;

        object IEnumerator.Current { get { return this.Current; } }

        public void Dispose() { }

        public bool MoveNext()
        {
            if (!(currentValue < ((UInt64.MaxValue - 1) / 3)))
            {
                throw new CollatzOverflowExeption("Entered number caused overflow. Can't be calculated collatz sequence.");
            }

            currentValue = (currentValue % 2 == 0) ? currentValue / 2 : currentValue * 3 + 1;
            
            return true;
        }

        public void Reset() => currentValue = startingValue;
    }

    public class CollatzOverflowExeption : Exception
    {
        public CollatzOverflowExeption(string message) : base(message) { }
    }
}
