using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.ContractsSchool;
using System.Collections.Generic;

namespace SchoolSystem.Tests.Core.Commands.RemoveStudentCommandTests
{

    [TestFixture]
    public class Execute_Should
    {
        private readonly string ReturnMessage = "Student with ID {0} was sucessfully removed.";
        private static object[] sourceLists = { new object[] { new List<string> { "0" } } };

        [Test, TestCaseSource("sourceLists")]
        public void RemoveStudent_WhenParametersAreCorrect(IList<string> parameters)
        {
            // Arrange
            var studentId = int.Parse(parameters[0]);
            var removeStudentMock = new Mock<IRemoveStudent>();
            var removeStudentCommandMock = new RemoveStudentCommand(removeStudentMock.Object);

            // Act 
            removeStudentCommandMock.Execute(parameters);

            // Assert
            removeStudentMock.Verify(r => r.RemoveStudent(studentId), Times.Once());
        }

        [Test, TestCaseSource("sourceLists")]
        public void ReturnCorrectMessage_WhenStudentIsRemoved(IList<string> parameters)
        {
            // Arrange
            var studentId = int.Parse(parameters[0]);
            var removeStudentMock = new Mock<IRemoveStudent>();
            var removeStudentCommandMock = new RemoveStudentCommand(removeStudentMock.Object);
            var expectedMessage = string.Format(this.ReturnMessage, studentId);

            // Act 
            var result = removeStudentCommandMock.Execute(parameters);

            // Assert
            Assert.AreEqual(expectedMessage, result);
        }
    }
}
