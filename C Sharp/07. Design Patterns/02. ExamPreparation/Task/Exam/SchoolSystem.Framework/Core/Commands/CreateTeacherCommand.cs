using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.ContractsSchool;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private static int currentTeacherId = 0;
        private readonly ITeacherFactory teacherFacory;
        private readonly IAddTeacher addTeacher;

        public CreateTeacherCommand(ITeacherFactory teacherFacory, IAddTeacher addTeacher)
        {
            this.teacherFacory = teacherFacory;
            this.addTeacher = addTeacher;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.teacherFacory.CreateTeacher(firstName, lastName, subject);
            this.addTeacher.AddTeacher(currentTeacherId, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {currentTeacherId++} was created.";
        }
    }
}
