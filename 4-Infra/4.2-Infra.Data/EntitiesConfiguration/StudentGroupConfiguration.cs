using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restful.Login.Domain.Entities;

namespace Restful.Login.Infra.Data.EntitiesConfiguration
{
    public class StudentGroupConfiguration : IEntityTypeConfiguration<StudentGroup>
    {
        public void Configure(EntityTypeBuilder<StudentGroup> builder)
        {
            builder.ToTable("student_group");

            builder
                .Property(sg => sg.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(sg => sg.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)");

            builder
                .Property(sg => sg.CourseId)
                .HasColumnName("course_id");

            builder
                .HasOne<Course>(sg => sg.Course)
                .WithMany(c => c.StudentGroups)
                .HasForeignKey(sg => sg.CourseId);

            builder
                .Ignore(sg => sg.Error);

            builder
                .Ignore(sg => sg.IsValid);
        }
    }
}
