using School.Contracts;
using StudentsAndCourses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class School : ISchool
    {
        private ICollection<ICourse> courses;

        public School()
        {
            this.courses = new HashSet<ICourse>();
        }

        public ICollection<ICourse> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public void AddCourse(ICourse course)
        {
            if (this.Courses.Contains(course))
            {
                throw new ArgumentException("Course exist");
            }
            this.Courses.Add(course);
        }

        public void RemoveCourse(ICourse course)
        {
            if (!this.Courses.Contains(course))
            {
                throw new ArgumentException("Course does not exist");
            }

            this.Courses.Remove(course);
        }
    }
}
