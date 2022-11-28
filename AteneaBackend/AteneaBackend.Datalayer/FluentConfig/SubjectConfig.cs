using AteneaBackend.Datalayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AteneaBackend.Datalayer.FluentConfig
{
    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Name).IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);

            // Relationships
            builder.HasMany(sb => sb.GradesBooks)
                .WithOne(gb => gb.Subject)
                .HasForeignKey(sb => sb.SubjectId);
        }
    }
}
