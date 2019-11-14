using Domain.Entities;
using System;

namespace Restful.Login.Domain.Entities
{
    public class StudentGroup : Entity
    {
        public string  Name { get; private set; }

        public Guid CourseId { get; private set; }

        public Course Course { get; private set; }

        private StudentGroup() { }

        private StudentGroup(Guid id, string name, Guid courseId, Course course)
        {
            Id = id;
            Name = name;
            CourseId = courseId;
            Course = course;
        }

        public static StudentGroup Create(string name, Course course)
            => new StudentGroup(Guid.NewGuid(), name, course.Id, course);
    }
}
