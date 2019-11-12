using System.Runtime.CompilerServices;
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

        public DateTime? UpdatedAt { get; set; }

        private User() {}

        private User(Guid id, string name, string lastName, string email, string confirmEmail,
            DateTime birthDate, string password, string confirmPassword, DateTime createdAt,
            DateTime? updatedAt)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            ConfirmEmail = confirmEmail;
            BirthDate = birthDate;
            Password = password;
            ConfirmPassword = confirmPassword;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;

            Validate();
        }

        public static User Create(string name, string lastName, string email, string confirmEmail,
            DateTime birthDate, string password, string confirmPassword)
            => new User(Guid.NewGuid(), name, lastName, email, confirmEmail, birthDate, password, 
                confirmPassword, DateTime.UtcNow, null);

        public static User Create(UserRequest userRequest)
            => new User(Guid.NewGuid(), userRequest.Name, userRequest.LastName, userRequest.Email, 
                userRequest.ConfirmEmail, Convert.ToDateTime(userRequest.BirthDate), 
                userRequest.Password, userRequest.ConfirmPassword, DateTime.UtcNow, null);

        public void Update(UserUpdateRequest userRequest)
        {
            Name = userRequest.Name;
            LastName = userRequest.LastName;
            Email = userRequest.Email;
            ConfirmEmail = userRequest.ConfirmEmail;
            BirthDate = Convert.ToDateTime(userRequest.BirthDate);
            UpdatedAt = DateTime.UtcNow;

            Validate();
        }

        public void Validate()
        {
            var validation = new UserValidation().Validate(this);
            if (!validation.IsValid)
                Error = validation.Errors.Select(c => c.ErrorCode).ToList();
        }
    }
}