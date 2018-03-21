using System;

namespace LinkedList
{
    public class LinkedList<T>
    {
        private const string INVALID_INDEX = "Invalid index: ";

        private ListItem<T> firstElement;
        private ListItem<T> lastElement;
        private int count;

        public LinkedList()
        {
            this.firstElement = null;
            this.lastElement = null;
            this.count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new ArgumentOutOfRangeException(INVALID_INDEX + index);
                }

                ListItem<T> currentItem = this.firstElement;
                for (int i = 0; i < index; i++)
                {
                    currentItem = currentItem.NextItem;
                }

                return currentItem.Value;
            }

            set
            {
                if (index < 0 || index >= this.count)
                {
                    throw new ArgumentOutOfRangeException(INVALID_INDEX + index);
                }

                ListItem<T> currentItem = this.firstElement;
                for (int i = 0; i < index; i++)
                {
                    currentItem = currentItem.NextItem;
                }

                currentItem.Value = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            protected set
            {
                if (this.count <= 0 && value < 0)
                {
                    throw new InvalidOperationException("List size is smaller than zero");
                }

                this.count = value;
            }


        }

        public void Add(T item)
        {
            if (this.firstElement == null)
            {
                this.firstElement = new ListItem<T>(item);
                this.lastElement = this.firstElement;
            }
            else
            {
                ListItem<T> newListItem = new ListItem<T>(item, this.lastElement);
                this.lastElement = newListItem;
            }

            this.count++;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException(INVALID_INDEX + index);
            }

            int currentIndex = 0;
            ListItem<T> currentItem = this.firstElement;
            ListItem<T> prevItem = null;

            while (currentIndex < index)
            {
                prevItem = currentItem;
                currentItem = currentItem.NextItem;
                currentIndex++;
            }

            this.count--;
            if (this.count == 0)
            {
                this.firstElement = null;
            }
            else if (prevItem == null)
            {
                this.firstElement = currentItem.NextItem;
            }
            else
            {
                prevItem.NextItem = currentItem.NextItem;
            }

            ListItem<T> lastItem = null;
            if (this.firstElement != null)
            {
                lastItem = this.firstElement;
                while (lastItem.NextItem != null)
                {
                    lastItem = lastItem.NextItem;
                }
            }

            this.lastElement = lastItem;

            return currentItem.Value;
        }

        public int Remove(T item)
        {
            int currentIndex = 0;
            ListItem<T> currentItem = this.firstElement;
            ListItem<T> prevItem = null;
            while (currentItem != null)
            {
                if ((currentItem.Value != null && currentItem.Value.Equals(item)) ||
                    (currentItem.Value == null && item == null))
                {
                    break;
                }

                prevItem = currentItem;
                currentItem = currentItem.NextItem;
                currentIndex++;
            }

            if (currentItem != null)
            {
                this.count--;

                if (this.count == 0)
                {
                    this.firstElement = null;
                }
                else if (prevItem == null)
                {
                    this.firstElement = currentItem.NextItem;
                }
                else
                {
                    prevItem.NextItem = currentItem.NextItem;
                }

                ListItem<T> lastItem = null;
                if (this.firstElement != null)
                {
                    lastItem = this.firstElement;
                    while (lastItem.NextItem != null)
                    {
                        lastItem = lastItem.NextItem;
                    }
                }

                this.lastElement = lastItem;

                return currentIndex;
            }
            else
            {
                return -1;
            }
        }

        public int IndexOf(T item)
        {
            int index = 0;
            ListItem<T> currentItem = this.firstElement;
            while (currentItem != null)
            {
                if ((currentItem.Value != null && currentItem.Value.Equals(item)) ||
                    (currentItem.Value == null && item == null))
                {
                    return index;
                }

                currentItem = currentItem.NextItem;
                index++;
            }

            return -1;
        }

        public bool Contains(T item)
        {
            int index = this.IndexOf(item);
            bool isFound = index != -1;

            return isFound;
        }
    }
}
