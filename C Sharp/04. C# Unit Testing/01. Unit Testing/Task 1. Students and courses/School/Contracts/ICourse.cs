using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Contracts
{
    public interface ICourse
    {
        //string CourseName { get; }

        ICollection<IStudent> ListOfStudentsInCourse { get; }

        void AddStudent(IStudent student);

        void RemoveStudent(IStudent student);
    }
}
