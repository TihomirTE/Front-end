using System;
using System.Collections;
using System.Collections.Generic;

namespace BucketList
{
    public class BucketList<T> : IBucketList<T>
    {
        private const int BUCKET_SIZE = 4;

        private int bucketSize;
        private List<Bucket<T>> buckets;

        public BucketList()
        {
            this.Clear();
        }

        public T this[int index]
        {
            get
            {
                return this.buckets[index / this.bucketSize][index % this.bucketSize];
            }

            set
            {
                this.buckets[index / this.bucketSize][index % this.bucketSize] = value;
            }
        }

        public int Size { get; private set; }
        

        public void Add(T value)
        {
            this.Insert(this.Size, value);
        }

        public void Clear()
        {
            this.bucketSize = BUCKET_SIZE;
            this.buckets = new List<Bucket<T>>();
            this.Size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this[i];
            }
        }

        public void Insert(int index, T value)
        {
            if (this.buckets.Count == this.bucketSize * 2 && this.buckets[this.buckets.Count - 1].Full)
            {
                var increasedBucket = new List<Bucket<T>>();
                increasedBucket.Capacity = this.buckets.Count / 2;

                for (int i = 0; i < this.buckets.Count; i+= 2)
                {
                    increasedBucket.Add(new Bucket<T>(this.buckets[i], this.buckets[i + 1]));
                }

                this.bucketSize *= 2;
                this.buckets = increasedBucket;
            }

            if(this.buckets.Count == 0 || this.buckets[this.buckets.Count - 1].Full)
            {
                var newBucket = new Bucket<T>(this.bucketSize);
                this.buckets.Add(newBucket);
            }

            int destinationIndex = this.buckets.Count - 1;
            int sourceIndex = destinationIndex - 1;

            int targetIndex = index / this.bucketSize;
            int targetIndexInBucket = index % this.bucketSize;

            while (destinationIndex != targetIndex)
            {
                this.buckets[destinationIndex]
                    .PushFront(this.buckets[sourceIndex][this.bucketSize - 1]);

                --destinationIndex;
                --sourceIndex;
            }

            this.buckets[targetIndex].Insert(targetIndexInBucket, value);
            ++this.Size;
        }

        // TODO
        public void Remove(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
