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
                .HasOne<Grade>(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GradeId);
            
            builder
                .Ignore(s => s.Error);
        }
    }
}