using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.ContractsSchool;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        private readonly IGetStudent getStudent;
        private readonly IGetTeacher getTeacher;

        public TeacherAddMarkCommand(IGetStudent getStudent, IGetTeacher getTeacher)
        {
            this.getStudent = getStudent;
            this.getTeacher = getTeacher;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var student = this.getStudent.GetStudent(studentId);
            var teacher = this.getTeacher.GetTeacher(teacherId);

            teacher.AddMark(student, mark);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
