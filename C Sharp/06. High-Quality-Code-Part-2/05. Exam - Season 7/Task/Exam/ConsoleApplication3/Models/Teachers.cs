using System;
using SchoolSystem.Enums;
using SchoolSystem.Models.Abstraction;
using SchoolSystem.Models.Contracts;

namespace SchoolSystem.Models
{
    public class Teachers : Person, ITeacher
    {
        public Teachers(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, float mark)
        {
            var addedMark = new Mark(this.Subject, mark);
            student.Marks.Add(addedMark);
        }
    }
}
