namespace SchoolClasses
{
    using System.Collections.Generic;

    public class School
    {
        //field
        private List<ClassesOfStudents> classes = new List<ClassesOfStudents>();

        // methods
        public void AddClass(ClassesOfStudents classes)
        {
            this.classes.Add(classes);
        }

        public void RemoveClass(ClassesOfStudents classes)
        {
            this.classes.Remove(classes);
        }

        public List<ClassesOfStudents> GetAllClasses()
        {
            return this.classes;
        }
    }
}
