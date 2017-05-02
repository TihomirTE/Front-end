using System;
using SchoolSystem.Enums;
using SchoolSystem.Models.Abstraction;
using SchoolSystem.Models.Contracts;

namespace SchoolSystem.Models
{
    public class Teachers : Person, ITeacher
    {
        private Subject subject;

        public Teachers(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; set; }

        // TODO this method
        public void AddMark(IStudent student, float mark)
        {
            throw new NotImplementedException();
        }

        public void AddMark(Student teacher, float value)
        {
            var cain = new Mark(this.subject, value);
            teacher
                .Marks
                .Add(cain);
        }
    }
}
