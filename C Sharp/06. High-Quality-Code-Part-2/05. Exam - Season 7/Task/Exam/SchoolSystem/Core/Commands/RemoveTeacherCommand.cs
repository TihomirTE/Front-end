using System.Collections.Generic;
using SchoolSystem.Core.Commands.Contracts;

namespace SchoolSystem.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameter)
        {
            var teacherID = int.Parse(parameter[0]);
            Engine.Teachers.Remove(teacherID);

            return $"Teacher with ID {teacherID} was sucessfully removed.";
        }
    }
}
