using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Restful.Login.Domain.Entities
{
    public class Course : Entity
    {
        public string Name { get; private set; }

        public IList<StudentCourse> StudentCourses { get; set; }

        public IList<StudentGroup> StudentGroups { get; set; }

        private Course() { }

        private Course(Guid id, string name)
        {
            Id = id;
            Name = name;
            StudentCourses = new List<StudentCourse>();
            StudentGroups = new List<StudentGroup>();
        }

        public static Course Create(string name)
            => new Course(Guid.NewGuid(), name);
    }
}
