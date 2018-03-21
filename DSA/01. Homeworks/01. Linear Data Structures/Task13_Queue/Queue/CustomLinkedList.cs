using LinkedList;

namespace Task13_Queue.Queue
{
    public class CustomLinkedList<T> : LinkedList<T>
    {
        private ListItem<T> firstElement;
        private ListItem<T> lastElement;


        public ListItem<T> FirstElement
        {
            get
            {
                return this.firstElement;
            }
        }

        public ListItem<T> LastElement
        {
            get
            {
                return this.lastElement;
            }
        }

        public void AddLast(T value)
        {
            var item = new ListItem<T>(value);

            if (base.Count == 0)
            {
                this.firstElement = item;
            }
            else
            {
                this.lastElement.NextItem = item;
            }

            this.lastElement = item;
            base.Count++;
        }

        public void RemoveFirst()
        {
            if (base.Count != 0)
            {
                this.firstElement = this.firstElement.NextItem;

                base.Count--;

                if (base.Count == 0)
                {
                    this.lastElement = null;
                }
            }
        }
    }
}
