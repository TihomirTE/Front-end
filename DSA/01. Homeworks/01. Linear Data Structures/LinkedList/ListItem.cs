namespace LinkedList
{
    public class ListItem<T>
    {
        private T value;
        private ListItem<T> nextItem;

        public ListItem(T value, ListItem<T> prevItem)
        {
            this.value = value;
            prevItem.nextItem = this;
        }

        public ListItem(T value)
        {
            this.value = value;
            this.nextItem = null;
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public ListItem<T> NextItem
        {
            get
            {
                return this.nextItem;
            }

            set
            {
                this.nextItem = value;
            }
        }
    }
}
