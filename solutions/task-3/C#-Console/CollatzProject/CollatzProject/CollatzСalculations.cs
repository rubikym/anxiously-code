using System;
using System.Collections;
using System.Collections.Generic;

namespace CollatzProject
{
    public class CollatzSequence : IEnumerable<ulong>
    {
        private ulong input;

        public CollatzSequence(ulong number)
        {
            input = number;
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            return new CollatzEnumerator(input);
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

        public CollatzEnumerator(ulong input)
        {
            currentValue = input;
            startingValue = input;
        }

        public ulong Current => currentValue;

        object IEnumerator.Current { get { return this.Current; } }

        public void Dispose() { }

        public bool MoveNext()
        {
            if (!(currentValue < ((UInt64.MaxValue - 1) / 3)))
            {
                throw new CollatzOverflowExeption();
            }

            currentValue = (currentValue % 2 == 0) ? currentValue / 2 : currentValue * 3 + 1;
            
            return true;
        }

        public void Reset() => currentValue = startingValue;
    }

    public class CollatzOverflowExeption : Exception
    {
        public override string Message => "Entered number caused overflow. Can't be calculated collatz sequence.";
        public CollatzOverflowExeption() : base() { }
    }
}
