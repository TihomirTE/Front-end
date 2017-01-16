namespace RangeExeptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
        where T : IComparable<T>
    {
        // constructor
        public InvalidRangeException(T start, T end)
        {
            this.Start = start;
            this.End = end;
        }

        // properties
        public T Start { get; private set; }
        public T End { get; private set; }

        // this method overrdide the method Message in the ApplicationException class
        public override string Message
        {
            get
            {
                return string.Format("Input cannot be outside the range {0} and {1}.", this.Start, this.End);
            }
        }
    }
}