
namespace GenericList
{
    using System;
    using System.Text;

    public class GenericList<T> where T:IComparable
    {
        // fields
        private T[] list;
        private int currentElement = 0; // index of the list


        #region 
        // Constructorts of the list
        public GenericList(int capacity)
        {
            list = new T[capacity];
        }

        
        public GenericList()
            : this (4)
        {
        }
        #endregion

        // Methods

        public void AddElement(T value)
        {
            if (currentElement == list.Length)
            {
                DoubleSizeList();
            }
            list[currentElement] = value;
            // update the index of the list
            currentElement++;
        }

        public void RemoveElement(int index)
        {
            if (index < 0 || index >= currentElement)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            else
            {
                // create new list with the same capacity
                T[] newList = new T[list.Length];

                // copying the part of the list which will remain the same
                for (int i = 0; i < index; i++)
                {
                    newList[i] = list[i];
                }
                // the index of the new list will be [i - 1] compare to the original
                for (int i = index + 1; i < currentElement; i++)
                {
                    newList[i - 1] = list[i];
                }

                list = newList;
                currentElement--;
            }
        }

        public void InsertElement(int index, T value)
        {
            if (currentElement == list.Length)
            {
                DoubleSizeList();
            }
            if (index < 0 || index > currentElement)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            else
            {
                T[] newList = new T[list.Length];
                for (int i = 0; i < index; i++)
                {
                    newList[i] = list[i];
                }

                newList[index] = value;

                for (int i = index + 1; i < currentElement; i++)
                {
                    newList[i + 1] = list[i];
                }

                list = newList;
                currentElement++;
            }
        }

        public void ClearList()
        {
            list = new T[0];
            currentElement = 0;
        }

        public int FindElement(T element)
        {
            int index = -1;
            
            for (int i = 0; i < currentElement; i++)
            {
                if (element.Equals(list[i]))
                {
                    return i; // return the position of the element
                }
            }
            return index; // return -1 if the element is not find in the List
        }

        public T FindMinValue()
        {
            T minValue = list[0];

            for (int i = 1; i < list.Length; i++)
            {
                if (minValue.CompareTo(list[i]) <= 0)
                {
                    minValue = list[i];
                }
            }
            return minValue;
        }

        public T FindMaxValue()
        {
            T maxValue = list[0];
            for (int i = 1; i < list.Length; i++)
            {
                if (maxValue.CompareTo(list[i]) > 0)
                {
                    maxValue = list[i];
                }
            }
            return maxValue;
        }

        // index of the list
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= currentElement)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return list[index];
                }
            }
            set
            {
                if (index < 0 || index >= currentElement)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    list[index] = value;
                }
            }
        }

        public void DoubleSizeList()
        {
            T[] doubleSizeList = new T[list.Length * 2];
            // copying the current List
            for (int i = 0; i < list.Length; i++)
            {
                doubleSizeList[i] = list[i];
            }
            list = doubleSizeList;
        }

        // Finds the lists Count
        public int Count
        {
            get { return currentElement; }
        }

        // ToString
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < currentElement; i++)
            {
                result.Append(list[i] + " ");
            }
            result.AppendLine();

            return result.ToString();
        }
    }
}
