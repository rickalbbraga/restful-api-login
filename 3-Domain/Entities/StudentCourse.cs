using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restful.Login.Domain.Entities
{
    public class StudentCourse
    {
        public Guid StudentId { get; private set; }
        public Student Student { get; private set; }

        public Guid CourseId { get; private set; }
        public Course Course { get; private set; }

        private StudentCourse()
        {

        }

        private StudentCourse(Student student, Course course)
        {
            StudentId = student.Id;
            Student = student;
            CourseId = course.Id;
            Course = course;
        }

        public static StudentCourse Create(Student student, Course course)
            => new StudentCourse(student, course);
    }
}
