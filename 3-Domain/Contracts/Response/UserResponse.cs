using System;

namespace Restful.Login.Domain.Contracts.Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }

        public RoleResponse Role { get; set; }
    }
}
