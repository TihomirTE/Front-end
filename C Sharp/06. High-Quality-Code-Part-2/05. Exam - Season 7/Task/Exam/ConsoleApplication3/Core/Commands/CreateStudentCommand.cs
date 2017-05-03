using System.Collections.Generic;
using SchoolSystem.Enum;
using SchoolSystem.Models;

namespace SchoolSystem
{
    public class CreateStudentCommand
    {
        private static int studentID = 0;

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grades = (Grade)int.Parse(parameters[2]);

            var student = new Student(firstName, lastName, grades);
            Engine.Students.Add(studentID, student);

            return $"A new student with name {firstName} {lastName}, grade {grades} and ID {studentID++} was created.";
        }
    }
}
