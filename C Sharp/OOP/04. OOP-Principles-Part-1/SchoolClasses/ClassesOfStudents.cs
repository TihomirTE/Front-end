namespace SchoolClasses
{
    using System.Collections.Generic;

    public class ClassesOfStudents: IComment
    {
        // fields
        private List<string> comments = new List<string>();
        private List<Teachers> setOfTeachers = new List<Teachers>();
        private List<Students> setOfStudents = new List<Students>();
        private string uniqueIdentifier;

        // constructors
        public ClassesOfStudents(string nameClass)
        {
            uniqueIdentifier = nameClass;
        }
        public ClassesOfStudents(string nameClass, string comment)
            :this(nameClass)
        {
            comments.Add(comment);
        }

        // property
        public int UniqueIdentifier { get; set; }

        // methods
        public void AddStudent(Students student)
        {
            setOfStudents.Add(student);
        }

        public void RemoveStudent(Students student)
        {
            setOfStudents.Remove(student);
        }

        public void RemoveClass(Students student)
        {
            setOfStudents.Clear();
        }

        public List<Students> GetAllStudents()
        {
            return setOfStudents;
        }

        public void AddTeacher(Teachers teacher)
        {
            setOfTeachers.Add(teacher);
        }

        public void RemoveTeacher(Teachers teacher)
        {
            setOfTeachers.Remove(teacher);
        }

        public List<Teachers> GetAllTeachers()
        {
            return setOfTeachers;
        }

        // comments 
        public List<string> Comments { get; }

        public void AddComment(string comment)
        {
            comments.Add(comment);
        }
    }
}
