using System;

namespace Restful.Login.Domain.Contracts.Requests
{
    public class RegistrationRequest
    {
        public Guid StudentId { get; set; }

        public Guid CoursetId { get; set; }
    }
}
