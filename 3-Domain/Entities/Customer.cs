using Restful.Login.Domain.Validations;
using System;
using System.Linq;

namespace Domain.Entities
{
    public class Customer : Entity
    {
        public string FirstName { get; private set; }
        
        public string LastName { get; private set; }
        
        public string Email { get; private set; }
        
        public string Phone { get; private set; }

        public DateTime BirthDate { get; private set; }

        private Customer(Guid id, string firstName, string lastName, string email, string phone, DateTime birthDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;

            Validate();
        }

        public static Customer Create(string firstName, string lastName, string email, string phone, DateTime birthDate)
            => new Customer(Guid.NewGuid(), firstName, lastName, email, phone, birthDate);

        private void Validate()
        {
            var validation = new CustomerValidation().Validate(this);

            if (!validation.IsValid)
                Error = validation.Errors.Select(c => c.ErrorMessage).ToList();
        }
    }
}