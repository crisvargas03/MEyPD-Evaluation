using AteneaBackend.Datalayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AteneaBackend.Datalayer.FluentConfig
{
    public class GradesBookConfig : IEntityTypeConfiguration<GradesBook>
    {
        public void Configure(EntityTypeBuilder<GradesBook> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.SubjectId).IsRequired();
            builder.Property(x => x.StudentId).IsRequired();
            builder.Property(x => x.Grade).IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);

            // Relationships Config
            // Student
            builder.HasOne(gb => gb.Student)
                .WithMany(st => st.GradesBooks)
                .HasForeignKey(gb => gb.StudentId);

            // Subject
            builder.HasOne(gb => gb.Subject)
                .WithMany(sb => sb.GradesBooks)
                .HasForeignKey(gb => gb.SubjectId);
        }
    }
}
