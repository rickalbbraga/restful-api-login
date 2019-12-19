using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Restful.Login.Domain.Entities
{
    public class Role : Entity
    {
        public string Name { get; private set; }

        public IList<User> Users { get; private set; }

        private Role()
        {
            Users = new List<User>();
        }

        private Role(Guid id, string name)
        {
            Id = id;
            Name = name;
            Users = new List<User>();
        }

        public static Role Create(string name)
            => new Role(Guid.NewGuid(), name);
    }
}
