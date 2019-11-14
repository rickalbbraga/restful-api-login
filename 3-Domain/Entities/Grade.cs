using Newtonsoft.Json;
using Restful.Login.Domain.Contracts.Requests;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Grade : Entity
    {
        public string Name { get; private set; }

        private Grade() { }

        [JsonConstructor]
        private Grade(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Grade Create(string name)
            => new Grade(Guid.NewGuid(), name);

        public void Update(GradeUpdateRequest gradeUpdateRequest)
        {
            Name = gradeUpdateRequest.Name;
        }
    }
}