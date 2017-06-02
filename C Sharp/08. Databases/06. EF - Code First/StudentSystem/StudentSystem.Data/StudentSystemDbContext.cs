using StudentSystem.Models;
using System.Data.Entity;

namespace StudentSystem.Data
{
    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext()
            :base("StudentSystemDatabase")
        {

        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }
    }
}
