using System.Linq;
using System;
using Domain.Contracts.Requests;
using Domain.Validations;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string ConfirmEmail { get; private set; }

        public DateTime BirthDate { get; private set; }
        
        public string Password { get; private set; }

        public string ConfirmPassword { get; private set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        private User() {}

        private User(Guid id, string name, string lastName, string email, string confirmEmail,
            DateTime birthDate, string password, string confirmPassword)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            ConfirmEmail = confirmPassword;
            BirthDate = birthDate;
            Password = password;
            ConfirmPassword = confirmPassword;

            var validation = new UserValidation().Validate(this);
            if (!validation.IsValid)
                Error = validation.Errors.Select(c => c.ErrorCode).ToList();
        }

        public static User Create(string name, string lastName, string email, string confirmEmail,
            DateTime birthDate, string password, string confirmPassword)
            => new User(Guid.Empty, name, lastName, email, confirmEmail, birthDate, password, confirmPassword);

        public static User Create(UserRequest userRequest)
            => new User(Guid.Empty, userRequest.Name, userRequest.LastName, userRequest.Email, userRequest.ConfirmEmail,
            Convert.ToDateTime(userRequest.BirthDate), userRequest.Password, userRequest.ConfirmPassword);
        
    }
}