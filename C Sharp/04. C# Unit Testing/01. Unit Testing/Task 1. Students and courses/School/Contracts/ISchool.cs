using School.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses.Contracts
{
    public interface ISchool
    {
        ICollection<ICourse> Courses { get; }

        void AddCourse(ICourse course);

        void RemoveCourse(ICourse course);
    }
}
