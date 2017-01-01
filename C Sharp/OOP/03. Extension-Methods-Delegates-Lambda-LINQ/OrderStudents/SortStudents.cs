namespace OrderStudents
{
    using System;
    using System.Linq;

    /* Problem 5. Order students
    Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.
    Rewrite the same with LINQ.*/

    public class SortStudents
    {
        /*static void Main()
        {
            var students = new[]
            {
                new {FirstName = "Evstati", LastName = "Asenov", age = 24},
                new {FirstName = "Petyr", LastName = "Ivanov", age = 15},
                new {FirstName = "Asen", LastName = "Metodiev", age = 18},
                new {FirstName = "Krali", LastName = "Marko", age = 32},
                new {FirstName = "Georgi", LastName = "Georgiev", age = 24},
                new {FirstName = "Milen", LastName = "Aleksandrov", age = 15},
                new {FirstName = "Nikolai", LastName = "Iordanov", age = 18},
                new {FirstName = "Iliqn", LastName = "Stamatov", age = 32},
            };
            
            // Sort students with Lambda Expression
            var sortedStudentsLambda = students.OrderByDescending(student => student.FirstName)
                                       .ThenByDescending(student => student.LastName);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Lambda Expression");
            Console.ResetColor();
            foreach (var student in sortedStudentsLambda)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
            Console.WriteLine("----------------------------------------------");
            // Sort students with LINQ
            var sortedStudentsLing = from student in students
                                     orderby student.FirstName descending,
                                     student.LastName descending
                                     select student;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("LINQ");
            Console.ResetColor();
            foreach (var student in sortedStudentsLing)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }*/
    }
}
