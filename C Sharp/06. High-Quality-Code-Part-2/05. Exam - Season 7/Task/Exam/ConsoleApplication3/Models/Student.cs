using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchoolSystem.Enum;
using SchoolSystem.Models.Abstraction;
using SchoolSystem.Models.Contracts;

namespace SchoolSystem.Models
{
    public class Student : Person, IStudent
    {
        private IList<IMark> marks;

        public Student(string firstName, string lastName, Grade grades)
            : base(firstName, lastName)
        {
            this.Grade = grades;
            this.Marks = new List<IMark>();
        }

        public Grade Grade { get; set; }

        public IList<IMark> Marks { get; set; }

        public string ListMarks()
        {
            if (this.Marks.Count == 0)
            {
                return "This student has no marks";
            }

            var builder = new StringBuilder();
            builder.AppendLine("The student has these marks:");

            var allMarks = this.Marks
                .Select(m => $"{m.Subject} => {m.Value}")
                .ToList();

            allMarks.ForEach(m => builder.AppendLine(m));

            return builder.ToString();
        }
    }
}
