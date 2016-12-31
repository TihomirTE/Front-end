using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroups
{

    // Problem 16.* Groups

    public class Group : TestStudent
    {
        public int GroupNumber { get; set; }

        public string DepartmentName { get; set; }

        public Group(int groupNumber, string departmentName)
        {
            GroupNumber = groupNumber;
            DepartmentName = departmentName;
        }

        public static void studentGroup(List<Student> students )
        {

        }
    }
}
