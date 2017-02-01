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
    /// This class test class School
    /// </summary>
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void ShouldCreateInstanceOfSchoolClass()
        {
            // Arrange
            Models.School scholl = new Models.School();

            // Action & Assert
            Assert.IsInstanceOfType(scholl, typeof(Models.School));
        }

        [TestMethod]
        public void AddCourse_ShouldIncreaseNumberOfCoursesInSchool()
        {
            // Arrange
            Models.School school = new Models.School();
            ICourse math = new Course("Math");
            ICourse biology = new Course("Biology");
            ICourse history = new Course("History");

            // Act
            school.AddCourse(math);
            school.AddCourse(biology);
            school.AddCourse(history);

            // Assert
            Assert.AreEqual(3, school.Courses.Count);
        }

        [TestMethod]
        public void AddCourseInSchool_WhichExistInSchoolAlready_ShouldThrowArgumentException()
        {
            // Arrange
            Models.School school = new Models.School();
            ICourse math = new Course("Math");
            ICourse biology = new Course("Biology");
            ICourse history = new Course("History");

            // Act
            school.AddCourse(math);
            school.AddCourse(biology);

            // Assert
            Assert.ThrowsException<ArgumentException>(() => school.AddCourse(math));
        }

        [TestMethod]
        public void RemoveCourseInSchool_ShouldDecreaseNumberOfCursesInSchool()
        {
            // Arrange
            Models.School school = new Models.School();
            ICourse math = new Course("Math");
            ICourse biology = new Course("Biology");
            ICourse history = new Course("History");

            // Act
            school.AddCourse(math);
            school.AddCourse(biology);
            school.AddCourse(history);
            school.RemoveCourse(biology);
            school.RemoveCourse(math);

            // Assert
            Assert.AreEqual(1, school.Courses.Count);
        }

        [TestMethod]
        public void RemoveCourseInSchool_WhichDoesNotExistInSchool_ShouldThrowArgumentException()
        {
            // Arrange
            Models.School school = new Models.School();
            ICourse math = new Course("Math");
            ICourse biology = new Course("Biology");
            ICourse history = new Course("History");

            // Act
            school.AddCourse(math);
            school.AddCourse(biology);

            // Assert
            Assert.ThrowsException<ArgumentException>(() => school.RemoveCourse(history));
        }

    }
}
