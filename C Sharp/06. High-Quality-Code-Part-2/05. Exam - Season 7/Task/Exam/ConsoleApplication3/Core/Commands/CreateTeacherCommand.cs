using System.Collections.Generic;
using SchoolSystem.Core.Commands.Contracts;
using SchoolSystem.Enums;
using SchoolSystem.Models;

namespace SchoolSystem.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private static int teacherID = 0;

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = new Teacher(firstName, lastName, subject);
            Engine.Teachers.Add(teacherID, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {teacherID++} was created.";
        }
    }
}
