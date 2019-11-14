using Domain.Entities;
using System;

namespace Restful.Login.Domain.Contracts.Response
{
    public class StudentResponse
    {
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public GradeResponse Grade { get; private set; }
    }
}
