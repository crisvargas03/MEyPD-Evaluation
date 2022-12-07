using AteneaBackend.Datalayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AteneaBackend.Datalayer.FluentConfig
{
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Birthdate).IsRequired();
            builder.Property(x => x.Gender).HasMaxLength(2);
            builder.Property(x => x.CardnetNumber).IsRequired().HasMaxLength(8);
            builder.Property(x => x.TeacherId).IsRequired();
            builder.Property(x => x.Condition).HasMaxLength(20);
            builder.Property(x => x.PhoneNumber).HasMaxLength(15);
            builder.Property(x => x.Address).HasMaxLength(100);

            builder.HasQueryFilter(x => !x.IsDeleted);

            // Relationships Config
            // Teacher
            builder.HasOne(st => st.Teacher)
                .WithMany(te => te.Students)
                .HasForeignKey(st => st.TeacherId);

            // GradesBook
            builder.HasMany(st => st.GradesBooks)
                .WithOne(gb => gb.Student)
                .HasForeignKey(gb => gb.StudentId);

            // Attendance
            builder.HasMany(st => st.Attendances)
                .WithOne(at => at.Student)
                .HasForeignKey(st => st.StudentId);
        }
    }
}
