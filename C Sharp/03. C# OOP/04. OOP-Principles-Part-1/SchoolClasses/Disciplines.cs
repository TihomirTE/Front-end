namespace SchoolClasses
{
    using System.Collections.Generic;

    public class Disciplines: IComment
    {
        // fields
        private string name;
        private int numberOfLectures;
        private int numberOfExcercises;
        private List<string> comments = new List<string>();

        // constructors
        public Disciplines(string name, int numberOfLectures, int numberOfExcercises)
        {
            this.name = name;
            this.numberOfLectures = numberOfLectures;
            this.numberOfExcercises = numberOfExcercises;
        }

        public Disciplines(string name, int numberOfLectures, int numberOfExcercises, string comment)
            :this(name, numberOfLectures, numberOfExcercises)
        {
            comments.Add(comment);
        }

        // properties
        public string Name { get; set; }
        public int NumberOfLectures { get; set; }
        public int NumberOfExcercises { get; set; }

        public List<string> Comments { get; }

        public void AddComment(string comment)
        {
            comments.Add(comment);
        }
    }
}
