using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BucketList
{
    public class NotBucketList<T> : IBucketList<T>
    {
        private List<T> list;

        public NotBucketList()
        {
            this.list = new List<T>();
        }

        public T this[int index]
        {
            get
            {
                return this.list[index];
            }

            set
            {
                this.list[index] = value;
            }
        }

        public int Size
        {
            get
            {
                return this.list.Count();
            }
        }

        public void Add(T value)
        {
            this.list.Add(value);
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.list)
            {
                yield return item;
            }
        }

        public void Insert(int index, T value)
        {
            this.list.Insert(index, value);
        }

        public void Remove(int index)
        {
            this.list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
