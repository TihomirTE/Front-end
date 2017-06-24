using System;

namespace Task13_Queue.Queue
{
    public class CustomQueue<T>
    {
        private const string EMPTY_QUEUE = "Emty queue";
        private CustomLinkedList<T> items;

        public CustomQueue()
        {
            this.items = new CustomLinkedList<T>();
        }

        public CustomLinkedList<T> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                this.items = value;
            }
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public void Enqueue(T item)
        {
            this.items.AddLast(item);
        }

        public T Dequeue()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(EMPTY_QUEUE);
            }

            T first = this.items.FirstElement.Value;
            this.items.RemoveFirst();

            return first;
        }

        public T Peek()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(EMPTY_QUEUE);
            }

            return this.items.FirstElement.Value;
        }
    }
}
