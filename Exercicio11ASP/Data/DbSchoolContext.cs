using Exercicio11ASP.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio11ASP.Data
{
    public class DbSchoolContext : DbContext
    {

        public DbSchoolContext(DbContextOptions<DbSchoolContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}