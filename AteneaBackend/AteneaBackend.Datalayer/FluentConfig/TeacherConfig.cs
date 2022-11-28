using AteneaBackend.Datalayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AteneaBackend.Datalayer.FluentConfig
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            // builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Password).HasMaxLength(15);

            builder.HasQueryFilter(x => !x.IsDeleted);

            // Relationships Config
            builder.HasMany(t => t.Students)
                .WithOne(s => s.Teacher)
                .HasForeignKey(s => s.TeacherId);
        }
    }
}
