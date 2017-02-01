using Microsoft.VisualStudio.TestTools.UnitTesting;
using School.Contracts;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Tests
{
    /// <summary>
    /// This class test class Student
    /// </summary>

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void ShouldCreateInstanceOfStudent()
        {
            // Arrange
            IStudent student = new Student("Pesho", 21000);

            // Act & Assert
            Assert.IsInstanceOfType(student, typeof(Student));
        }

        [TestMethod]
        public void StudentName_ShouldThrowException_IfItIsNull()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Student(null));
        }

        [TestMethod]
        public void CreateStudent_ShouldReturnCorrectName()
        {
            // Arrange
            IStudent student = new Student("Pesho", 13003);

            // Act & Assert
            Assert.AreEqual("Pesho", student.Name);
        }

        [TestMethod]
        public void CreateStudent_ShouldReturnCorrectUniqueNumber()
        {
            // Arrange
            IStudent student = new Student("Gosho", 13003);

            // Act & Assert
            Assert.AreEqual(13003, student.Id);
        }

        [TestMethod]
        public void CreateStudentWithNoValidUniqueNumber_ShouldReturnArgumentOutOfRangeException()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Student("Pesho", 10));
        }
    }
}
