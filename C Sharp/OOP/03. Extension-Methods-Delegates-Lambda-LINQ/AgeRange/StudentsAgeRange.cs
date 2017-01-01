namespace AgeRange
{
    using System;
    using System.Linq;

    /* Problem 4. Age range
    Write a LINQ query that finds the first name and last name of all students
    with age between 18 and 24.*/

    public class StudentsAgeRange
    {
        /*static void Main(string[] args)
        {
            var students = new[]
            {
                new {FirstName = "Evstati", LastName = "Asenov", age = 24},
                new {FirstName = "Petyr", LastName = "Ivanov", age = 15},
                new {FirstName = "Asen", LastName = "Metodiev", age = 18},
                new {FirstName = "Krali", LastName = "Marko", age = 32},
            };

            // LINQ query that finds the first name and last name of all
            // students with age between 18 and 24.
            var query = from student in students
                        where (student.age >= 18 && student.age <= 24)
                        select student;

            foreach (var student in query)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }*/
}
}
