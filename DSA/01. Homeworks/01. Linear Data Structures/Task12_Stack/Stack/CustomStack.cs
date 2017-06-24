using System;

namespace Task12_Stack.Stack
{
    public class CustomStack<T>
    {
        private const string EMPTY_STACK = "Emty stack";
        private T[] items;

        public CustomStack()
        {
            this.items = new T[4];
        }

        public int Count { get; set; }

        public void Push(T value)
        {
            if (this.Count >= this.items.Length)
            {
                Array.Resize(ref this.items, this.items.Length * 2);
            }

            this.items[this.Count] = value;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EMPTY_STACK);
            }

            T result = this.items[this.Count - 1];
            this.Count--;

            return result;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EMPTY_STACK);
            }

            return this.items[this.Count - 1];
        }
    }
}
