using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restful.Login.Domain.Entities;

namespace Restful.Login.Infra.Data.EntitiesConfiguration
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable("student_course");

            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder
                .Property(sc => sc.StudentId)
                .HasColumnName("student_id");

            builder
                .Property(sc => sc.CourseId)
                .HasColumnName("course_id");

            builder
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);


            builder
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
