using School.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.Models
{
    public class Course : ICourse
    {
        private const int MaxStudentsNumber = 29;
        private ICollection<IStudent> listOfStudentsInCourse;

        public Course(string name)
        {
            this.Name = name;
            this.listOfStudentsInCourse = new HashSet<IStudent>();
        }

        public string Name { get; }

        public ICollection<IStudent> ListOfStudentsInCourse
        {
            get
            {
                return this.listOfStudentsInCourse;
            }
        }


        public void AddStudent(IStudent student)
        {
            if (student == null)
            {
                throw new ArgumentException("The course can\'t be null");
            }

            if (this.ListOfStudentsInCourse.Count > MaxStudentsNumber)
            {
                throw new ArgumentException("The course can not be more than " + (MaxStudentsNumber - 1));
            }

            if (this.ListOfStudentsInCourse.Any(x => x.Id == student.Id))
            {
                throw new ArgumentException("Student number must be unique");
            }

            this.listOfStudentsInCourse.Add(student);
        }

        public void RemoveStudent(IStudent student)
        {
            if (student == null || listOfStudentsInCourse.Count < 1)
            {
                throw new ArgumentException("The can\'t be less than 1 student");
            }

            this.listOfStudentsInCourse.Remove(student);
        }
    }
}
