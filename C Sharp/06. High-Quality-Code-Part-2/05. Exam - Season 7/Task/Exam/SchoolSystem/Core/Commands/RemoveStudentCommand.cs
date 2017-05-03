using System.Collections.Generic;
using SchoolSystem.Core.Commands.Contracts;

namespace SchoolSystem.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameter)
        {
            var studentID = int.Parse(parameter[0]);
            Engine.Students.Remove(studentID);

            return $"Student with ID {studentID} was sucessfully removed.";
        }
    }
}
