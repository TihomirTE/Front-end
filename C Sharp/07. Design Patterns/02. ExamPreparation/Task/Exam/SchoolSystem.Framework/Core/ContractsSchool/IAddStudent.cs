using SchoolSystem.Framework.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Framework.Core.ContractsSchool
{
    public interface IAddStudent
    {
        void AddStudent(int studentId, IStudent student);
    }
}
