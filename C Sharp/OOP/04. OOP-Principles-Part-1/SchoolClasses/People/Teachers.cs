namespace SchoolClasses
{
    using System.Collections.Generic;

    public class Teachers: People, IComment
    {
        // fields
        private List<string> comments = new List<string>();
        private List<Disciplines> setOfDisciplines = new List<Disciplines>();

        // constructors
        public Teachers(string name)
            :base(name)
        {
        }

        public Teachers(string name, string comment)
            :base(name)
        {
            comments.Add(comment);
        }

        // methods
        public void AddDiscipline(Disciplines discipline)
        {
            setOfDisciplines.Add(discipline);
        }

        public void RemoveDiscipline(Disciplines discipline)
        {
            setOfDisciplines.Remove(discipline);
        }

        public void ClearDisciplines()
        {
            setOfDisciplines.Clear();
        }

        // comments
        public List<string> Comments { get; }
        
        public void AddComment(string comment)
        {
            comments.Add(comment);
        }
    }
}
