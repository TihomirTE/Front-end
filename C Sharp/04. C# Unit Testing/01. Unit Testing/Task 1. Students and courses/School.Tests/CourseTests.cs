using Microsoft.VisualStudio.TestTools.UnitTesting;
using School.Contracts;
using School.Models;
using System;

namespace StudentsAndCourses.Tests
{
    /// <summary>
    /// This class test class Course
    /// </summary>
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void AddStudentToCourse_ShouldIncreaseNumberOfStudentsInCourse()
        {
            // Arrange
            ICourse addCourse = new Course("Math");
            IStudent gosho = new Student("Gosho", 11000);
            IStudent pesho = new Student("Pesho", 12000);
            IStudent tosho = new Student("Tosho", 13000);

            // Act
            addCourse.AddStudent(gosho);
            addCourse.AddStudent(pesho);
            addCourse.AddStudent(tosho);
            int result = addCourse.ListOfStudentsInCourse.Count;

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void AddStudentWithSameUniqueNumberInCourse_ShouldThrowException()
        {
            // Arrange
            IStudent pesho = new Student("Pesho", 11000);
            IStudent gosho = new Student("Gosho", 11000);
            ICourse courseSameId = new Course("Geography");

            // Act
            courseSameId.AddStudent(pesho);

            // Assert
            Assert.ThrowsException<ArgumentException>(() => courseSameId.AddStudent(gosho));
        }

        [TestMethod]
        public void AddNullStudentInCourse_ShouldThrowException()
        {
            // Arrange
            ICourse course = new Course("History");

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => course.AddStudent(null));
        }

        [TestMethod]
        public void AddThirtyStudentsInCourse_ShouldThrowException()
        {
            // Arrange
            ICourse course = new Course("Math");

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                for (int i = 0; i <= 30; i++)
                {
                    IStudent student = new Student("Evstati" + i, 12000 + i);
                    course.AddStudent(student);
                }
            });
        }

        [TestMethod]
        public void RemoveStudentToCourse_ShouldDecreaseNumberOfStudentsInCourse()
        {
            // Arrange
            ICourse removeCourse = new Course("Programming");
            IStudent dragan = new Student("Dragan", 11000);
            IStudent petkan = new Student("Petkan", 12000);
            IStudent ganio = new Student("Ganio", 13000);

            // Act
            removeCourse.AddStudent(dragan);
            removeCourse.AddStudent(petkan);
            removeCourse.AddStudent(ganio);
            removeCourse.RemoveStudent(petkan);
            int result = removeCourse.ListOfStudentsInCourse.Count;

            // Assert
            Assert.AreEqual(2, result);
        }
    }
}
