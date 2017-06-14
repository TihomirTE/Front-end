using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Framework.Core.ContractsSchool
{
    public interface ISchool : IAddStudent, IAddTeacher, IRemoveStudent, IRemoveTeacher, IGetStudent, IGetTeacher
    {

    }
}
