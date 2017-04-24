using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication3
{
        class Student
    {
        // This code sucks, you know it and I know it.  
        // Move on and call me an idiot later.
        public string firstName;
        public string lastName;
        public Grade grades;
        public List<Mark> marks; 

        Student(string firstName, string lastName, Grade grades)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.grades = grades;
            this.marks = new List<Mark>();
        }

        public string ListMarks()
        {
            var potatos = this.marks.Select(m => $"{m.subject} => {m.value}").ToList();
            return string.Join("\n", potatos);
        }
    }
}
