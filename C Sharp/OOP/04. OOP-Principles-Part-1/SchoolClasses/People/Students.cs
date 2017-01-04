namespace SchoolClasses
{
    using System.Collections.Generic;

    public class Students : People, IComment
    {
        // fields
        private int classNumber;
        private List<string> comments = new List<string>();


        // constructor
        public Students(string name, int classNumber)
            :base(name)
        {
            this.classNumber = classNumber;
        }

        public Students(string name, int classNumber, string comment)
            : base(name)
        {
            this.classNumber = classNumber;
            comments.Add(comment);
        }

        // property
        public int ClassNumber { get; set; }
        
        // comments
        public List<string> Comments { get; }

        public void AddComment(string comment)
        {
            comments.Add(comment);
        }
    }
}
