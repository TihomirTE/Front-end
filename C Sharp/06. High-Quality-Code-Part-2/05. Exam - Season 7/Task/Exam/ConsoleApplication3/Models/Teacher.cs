using System;
using SchoolSystem.Enums;
using SchoolSystem.Models.Abstraction;
using SchoolSystem.Models.Contracts;

namespace SchoolSystem.Models
{
    public class Teacher : Person, ITeacher
    {
        private const int MaxNumberOfMarks = 20;

        public Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, float mark)
        {
            if (student.Marks.Count > MaxNumberOfMarks)
            {
                throw new ArgumentOutOfRangeException($"Each student must not have more than {MaxNumberOfMarks} marks");
            }

            var addedMark = new Mark(this.Subject, mark);
            student.Marks.Add(addedMark);
        }
    }
}
