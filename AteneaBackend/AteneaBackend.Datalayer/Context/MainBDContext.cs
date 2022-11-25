using AteneaBackend.Datalayer.FluentConfig;
using AteneaBackend.Datalayer.Models;
using Microsoft.EntityFrameworkCore;

namespace AteneaBackend.Datalayer.Context
{
    public class MainBDContext : DbContext
    {
        public MainBDContext(DbContextOptions<MainBDContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TeacherConfig());
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new GradesBookConfig());
            modelBuilder.ApplyConfiguration(new SubjectConfig());
            modelBuilder.ApplyConfiguration(new AttendanceConfig());
        }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<GradesBook> GradesBook { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Subject> Subject { get; set; }
    }
}
