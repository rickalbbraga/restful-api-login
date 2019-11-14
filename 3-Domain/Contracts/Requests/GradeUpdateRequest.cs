using System;

namespace Restful.Login.Domain.Contracts.Requests
{
    public class GradeUpdateRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
