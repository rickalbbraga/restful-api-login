using Restful.Login.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Student : Entity
    {
        public string Name { get; private set; }

        public IList<StudentCourse> StudentCourses { get; private set; }

        private Student() 
        {
            StudentCourses = new List<StudentCourse>();
        }

        private Student(Guid id, string name)
        {
            Id = id;
            Name = name;
            StudentCourses = new List<StudentCourse>();
        }

        public static Student Create(string name)
            => new Student(Guid.NewGuid(), name);       
        
        public void RegistreStudent(StudentCourse studentCourses)
        {
            StudentCourses.Add(studentCourses);
        }
    }
}