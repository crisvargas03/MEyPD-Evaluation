using AteneaBackend.Datalayer.Models;
using Microsoft.EntityFrameworkCore;

namespace AteneaBackend.Datalayer.Context
{
    public class MainBDContext : DbContext
    {
        public MainBDContext(DbContextOptions<MainBDContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<GradesBook> GradesBook { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Subject> Subject { get; set; }
    }
}
