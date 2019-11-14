using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restful.Login.Domain.Entities;

namespace Restful.Login.Infra.Data.EntitiesConfiguration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("course");

            builder
                .Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)");

            builder
                .Ignore(c => c.Error);

            builder
                .Ignore(c => c.IsValid);
        }
    }
}
