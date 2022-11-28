using AteneaBackend.Datalayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AteneaBackend.Datalayer.FluentConfig
{
    public class AttendanceConfig : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.StudentId).IsRequired();
            builder.Property(x => x.IsPresent).IsRequired();
            builder.Property(x => x.Justification).HasMaxLength(200);

            builder.HasQueryFilter(x => !x.IsDeleted);

            // Relationships
            // Student
            builder.HasOne(at => at.Student)
                .WithMany(st => st.Attendances)
                .HasForeignKey(x => x.StudentId);
        }
    }
}
