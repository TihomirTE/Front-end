namespace ArrayOfStudents
{
    using System;
    using System.Linq;

    // This class is for testing -> class TestEnumarable
    public class Students
    {
        /* Problem 3. First before last
    Write a method that from a given array of students finds
    all students whose first name is before its last name alphabetically.*/
        /*static void Main()
        {
            var students = new[]
            {
                new {FirstName = "Evstati", LastName = "Asenov"},
                new {FirstName = "Petyr", LastName = "Ivanov"},
                new {FirstName = "Asen", LastName = "Metodiev"},
                new {FirstName = "Krali", LastName = "Marko"},
            };

            // sorting the names
            var names = from student in students
                        where student.FirstName.CompareTo(student.LastName) < 0
                        select student;

            foreach (var item in names)
            {
                Console.WriteLine($"{ item.FirstName} {item.LastName}");
            }
        }*/
    }
}
