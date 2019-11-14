using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.EntitiesConfiguration
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable("grades");

            builder
                .Property(g => g.Id)
                .HasColumnName("id")
                .IsRequired();
            
            builder
                .Property(g => g.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)");
            
            builder
                .Ignore(g => g.Error);

        }
    }
}