using System;

namespace Restful.Login.Domain.Contracts.Requests
{
    public class StudentRequest
    {
        public string Name { get; set; }

        public Guid GradeId { get; set; }
    }
}
