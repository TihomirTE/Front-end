using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.ContractsSchool;
using SchoolSystem.Framework.Models.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.Tests.Core.Commands.TeacherAddMarkCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        private static object[] sourceLists = { new object[] { new List<string> { "0", "0", "7" } } };

        [Test, TestCaseSource("sourceLists")]
        public void AddMark_WhenTheParametersAreCorrect(IList<string> parameters)
        {
            // Arrange
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var getStudentMock = new Mock<IGetStudent>();
            var getTeacherMock = new Mock<IGetTeacher>();
            var studentMock = new Mock<IStudent>();
            var teacherMock = new Mock<ITeacher>();
            getStudentMock.Setup(s => s.GetStudent(studentId)).Returns(studentMock.Object);
            getTeacherMock.Setup(s => s.GetTeacher(teacherId)).Returns(teacherMock.Object);

            var teacherAddMarkCommand = new TeacherAddMarkCommand(getStudentMock.Object, getTeacherMock.Object);

            // Act
            teacherAddMarkCommand.Execute(parameters);

            // Assert
            teacherMock.Verify(t => t.AddMark(studentMock.Object, mark), Times.Once());
        }
    }
}
