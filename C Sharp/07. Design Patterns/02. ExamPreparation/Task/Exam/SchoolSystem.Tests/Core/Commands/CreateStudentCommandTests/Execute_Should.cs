using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.ContractsSchool;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Tests.Core.Commands.CreateStudentCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        private static object[] sourceLists = {new object[] {new List<string> {"Pesho", "Petrov", "6"}},
                                                new object[] {new List<string> {"Gosho", "Peshev", "9"}}};

        [Test, TestCaseSource("sourceLists")]
        public void CreateStudent_WhenParametersAreCorrect(IList<string> parameters)
        {
            // Arrange
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var studentFactoryMock = new Mock<IStudentFactory>();
            var addStudentMock = new Mock<IAddStudent>();

            var createStudent = new CreateStudentCommand(studentFactoryMock.Object, addStudentMock.Object);

            // Act
            createStudent.Execute(parameters);

            // Assert
            studentFactoryMock.Verify(s => s.CreateStudent(firstName, lastName, grade), Times.Once());
        }

        [Test, TestCaseSource("sourceLists")]
        public void AddStudent_WhenParametersAreCorrect(IList<string> parameters)
        {
            // Arrange
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var studentFactoryMock = new Mock<IStudentFactory>();
            var addStudentMock = new Mock<IAddStudent>();
            var studentMock = new Mock<IStudent>();

            var createStudent = new CreateStudentCommand(studentFactoryMock.Object, addStudentMock.Object);
            studentFactoryMock.Setup(s => s.CreateStudent(firstName, lastName, grade)).Returns(studentMock.Object);

            // Act
            createStudent.Execute(parameters);

            // Assert
            addStudentMock.Verify(s => s.AddStudent(0, studentMock.Object), Times.Once());
        }
    }
}
