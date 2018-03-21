using System;

namespace ArrayList
{
    public class CustomArrayList
    {
        private static readonly int INITIAL_CAPACITY = 4;

        private string INVALID_INDEX = "Invalid index: ";
        private object[] arr;
        private int count;

        public CustomArrayList()
        {
            this.arr = new object[INITIAL_CAPACITY];
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(object item)
        {
            this.Insert(this.count, item);
        }

        public int IndexOf(object item)
        {
            for (int i = 0; i < this.arr.Length; i++)
            {
                if (item == this.arr[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public void Clear()
        {
            this.arr = new object[INITIAL_CAPACITY];
           this.count = 0;
        }

        public bool Contains(object item)
        {
            int index = this.IndexOf(item);
            bool found = index != -1;
            return found;
        }

        public object RemoveAt(int index)
        {
            if (index >= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException(this.INVALID_INDEX + index);
            }

            object item = this.arr[index];
            Array.Copy(this.arr, index + 1, this.arr, index, this.count - index + 1);
            this.arr[this.count - 1] = null;
           this.count--;

            return item;
        }

        public int Remove(object item)
        {
            int index = this.IndexOf(item);
            if (index == -1)
            {
                return index;
            }

            Array.Copy(this.arr, index + 1, this.arr, index, this.count - index + 1);
           this.count--;

            return index;
        }

        private void Insert(int index, object item)
        {
            if (index > this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException(this.INVALID_INDEX + index);
            }

            object[] extendedArr = this.arr;
            if (this.count + 1 == this.arr.Length)
            {
                extendedArr = new object[this.arr.Length * 2];
            }

            Array.Copy(this.arr, extendedArr, index);
            this.count++;
            Array.Copy(this.arr, index, extendedArr, index + 1, this.count - index - 1);
            extendedArr[index] = item;
            this.arr = extendedArr;
        }
    }
}
