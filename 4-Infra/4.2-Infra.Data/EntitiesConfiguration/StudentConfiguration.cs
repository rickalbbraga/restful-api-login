using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntitiesConfiguration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("students");

            builder
                .Property(s => s.Id)
                .HasColumnName("id")
                .IsRequired();
            
            builder
                .Property(s => s.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)");

            builder
                .Ignore(s => s.Error);

            builder
                .Ignore(s => s.IsValid);
        }
    }
}