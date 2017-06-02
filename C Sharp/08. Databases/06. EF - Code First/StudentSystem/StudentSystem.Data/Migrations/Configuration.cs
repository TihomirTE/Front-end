using StudentSystem.Models;
using System.Data.Entity.Migrations;

namespace StudentSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // In the begining of the design of the Databases -> true
            this.AutomaticMigrationDataLossAllowed = true;

            this.ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            context.Courses.AddOrUpdate(
             c => c.Name,
             new Course { Name = "Bulgarian language" },
             new Course { Name = "Matrhs" },
             new Course { Name = "Informatics" },
             new Course { Name = "Physic" }
           );

            context.Students.AddOrUpdate(
                s => new { s.FirstName, s.LastName },
                new Student { FirstName = "Gosho", LastName = "Picha" },
                new Student { FirstName = "Pesho", LastName = "Silniq" },
                new Student { FirstName = "Rado", LastName = "Byrziq" },
                new Student { FirstName = "Pesho", LastName = "Lyka" }
            );
        }
    }
}
