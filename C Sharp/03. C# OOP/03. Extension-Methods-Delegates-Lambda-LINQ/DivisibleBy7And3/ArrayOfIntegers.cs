namespace DivisibleBy7And3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /* Problem 6. Divisible by 7 and 3
    Write a program that prints from given array of integers all numbers
    that are divisible by 7 and 3. Use the built-in extension methods and lambda
    expressions. Rewrite the same with LINQ.*/

    public class ArrayOfIntegers
    {
        /*static void Main()
        {
            var array = new List<int>() { 42, 23, 67, 12, 84, 7, 15, 21, 67, 72 };

            // Lambda
            var sortedLambda = array.FindAll(num => (num % 3 == 0)
                               && (num % 7 == 0));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Lambda Expression");
            Console.ResetColor();
            foreach (var num in sortedLambda)
            {
                Console.WriteLine(num);
            }
            
            // LINQ 
            var sortedLinq = from num in array
                             where num % 3 == 0 && num % 7 == 0
                             select num;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Linq Expression");
            Console.ResetColor();
            foreach (var num in sortedLinq)
            {
                Console.WriteLine(num);
            }
        }*/
    }
}
