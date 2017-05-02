using System;
using System.Collections.Generic;
using System.Linq;
using SchoolSystem.Enum;
using SchoolSystem.Models.Abstraction;
using SchoolSystem.Models.Contracts;

namespace SchoolSystem.Models
{
    public class Student : Person, IStudent
    {
        private const int NumberOfMarks = 20;

        private Grade grades;
        private IList<IMark> marks;

        public Student(string firstName, string lastName, Grade grades)
            : base(firstName, lastName)
        {
            this.grades = grades;
            this.Marks = new List<IMark>();
        }

        public Grade Grade { get; set; }

        public IList<IMark> Marks
        {
            get
            {
                return this.marks;
            }

            set
            {
                if (value.Count > NumberOfMarks)
                {
                    throw new ArgumentOutOfRangeException($"Each student must not have more than {NumberOfMarks} marks");
                }

                this.marks = value;
            }
        }

        public string ListMarks()
        {
            var potatos = this.marks.Select(m => $"{m.Subject} => {m.Value}").ToList();
            return string.Join("\n", potatos);
        }
    }
}
