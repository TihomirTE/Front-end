using StudentSystem.Data;
using StudentSystem.Data.Migrations;
using StudentSystem.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace StudentSystem.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StudentSystemDbContext>());

            // Migrate dates when sth change
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());

            var dbContext = new StudentSystemDbContext();

            var student = new Student
            {
                FirstName = "Stamat",
                LastName = "Peshev",
                Number = 10,
                Age = 17
            };

            dbContext.Students.Add(student);
            dbContext.SaveChanges();

            Console.WriteLine(dbContext.Students.Count());
        }
    }
}
