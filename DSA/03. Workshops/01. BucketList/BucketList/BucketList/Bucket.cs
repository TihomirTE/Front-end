namespace BucketList
{
    public class Bucket<T>
    {
        private T[] buffer;
        private int startIndex;
        private int endIndex;
        private int size;

        public Bucket(int bucketSize)
        {
            this.buffer = new T[bucketSize];
            this.startIndex = 0;
            this.endIndex = 0;
            this.size = 0;
        }

        public Bucket(Bucket<T> left, Bucket<T> right)
        {
            this.size = left.size + right.size;
            this.buffer = new T[size];
            this.startIndex = 0;
            this.endIndex = 0;

            for (int i = 0; i < left.size; ++i)
            {
                this.buffer[i] = left[i];
            }
            for (int i = 0; i < right.size; i++)
            {
                this.buffer[left.size + i] = left[i];
            }
        }

        public bool Full => this.size == this.buffer.Length;

        public T this[int index]
        {
            get
            {
                return this.buffer[AdaptIndex(index)];
            }

            set
            {
                this.buffer[AdaptIndex(index)] = value;
            }
        }

        public void PushFront(T value)
        {
            this.startIndex = PrevIndex(this.startIndex);
            this.buffer[this.startIndex] = value;

            if (this.Full)
            {
                this.endIndex = this.startIndex;
            }
            else
            {
                ++this.size;
            }
        }

        public void Insert(int index, T value)
        {
            int destinationIndex = this.endIndex;
            int sourceIndex = this.PrevIndex(destinationIndex);

            int realIndex = this.AdaptIndex(index); 

            while (destinationIndex != realIndex)
            {
                this.buffer[destinationIndex] = this.buffer[sourceIndex];
                destinationIndex = sourceIndex;
                sourceIndex = this.PrevIndex(sourceIndex);
            }

            this.buffer[realIndex] = value;

            this.endIndex = this.NextIndex(endIndex);

            if (!this.Full)
            {
                ++this.size;
            }
        }

        public void Remove(int index)
        {
            int destinationIndex = this.AdaptIndex(index);
            int sourceIndex = this.NextIndex(destinationIndex);

            while (sourceIndex != this.endIndex)
            {
                this.buffer[destinationIndex] = this.buffer[sourceIndex];
                destinationIndex = sourceIndex;
                sourceIndex = this.NextIndex(sourceIndex);
            }

            this.endIndex = this.PrevIndex(this.endIndex);
        }

        private int PrevIndex(int index)
        {
            if (index == 0)
            {
                return this.buffer.Length - 1;
            }

            return index - 1;
        }

        private int NextIndex(int index)
        {
            if (index == this.buffer.Length - 1)
            {
                return 0;
            }

            return index + 1;
        }

        private int AdaptIndex(int index)
        {
            int realIndex = this.startIndex + index;
            if (realIndex >= this.buffer.Length)
            {
                realIndex -= this.buffer.Length;
            }

            return realIndex;
        }
    }
}
