using System.Collections.Generic;
using SchoolSystem.Core.Commands.Contracts;

namespace SchoolSystem.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var studentID = int.Parse(parameters[0]);
            var student = Engine.Students[studentID];

            return student.ListMarks();
        }
    }
}
