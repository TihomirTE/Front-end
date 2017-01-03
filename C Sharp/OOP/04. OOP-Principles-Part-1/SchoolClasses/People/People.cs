namespace SchoolClasses
{
    public abstract class People
    {
        // field
        private string name;

        // constructor

        public People(string name)
        {
            this.name = name;
        }

        // property
        public string Name { get; set; }
    }
}
