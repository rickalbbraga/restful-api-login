using Newtonsoft.Json;
using System;

namespace Domain.Entities
{
    public class Student : Entity
    {
        public string Name { get; private set; }

        public Guid GradeId { get; private set; }

        public Grade Grade { get; private set; }

        private Student() {}

        [JsonConstructor]
        private Student(Guid id, string name, Guid gradeId, Grade grade)
        {
            Id = id;
            Name = name;
            GradeId = gradeId;
            Grade = grade;
        }

        public static Student Create(string name, Grade grade)
            => new Student(Guid.NewGuid(), name, grade.Id, grade);        
    }
}