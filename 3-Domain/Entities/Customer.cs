using System;

namespace Domain.Entities
{
    public class Customer : Entity
    {
        public string FirstName { get; private set; }
        
        public string LastName { get; private set; }
        
        public string Email { get; private set; }
        
        public string Phone { get; private set; }

        private Customer(Guid id, string firstName, string lastName, string email, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public static Customer Create(string firstName, string lastName, string email, string phone)
            => new Customer(Guid.NewGuid(), firstName, lastName, email, phone);
    }
}