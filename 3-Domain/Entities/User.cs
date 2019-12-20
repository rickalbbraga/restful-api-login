using Domain.Contracts.Requests;
using Domain.Validations;
using Restful.Login.Domain.Entities;
using System;
using System.Linq;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string ConfirmEmail { get; private set; }

        public DateTime? BirthDate { get; private set; }
        
        public string Password { get; private set; }

        public string ConfirmPassword { get; private set; }

        public Guid RoleId { get; private set; }

        public Role Role { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private User() { }

        private User(Guid id, string name, string lastName, string email, string confirmEmail,
            DateTime? birthDate, string password, string confirmPassword, Role role, DateTime createdAt,
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
            RoleId = role.Id;
            Role = role;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            BirthDate = (DateTime.TryParse(birthDate.ToString(), out DateTime temp) == true) ? birthDate: DateTime.MinValue;

            Validate();
        }

        public static User Create(string name, string lastName, string email, string confirmEmail,
            DateTime birthDate, string password, string confirmPassword, Role role)
            => new User(Guid.NewGuid(), name, lastName, email, confirmEmail, birthDate, password, 
                confirmPassword, role, DateTime.UtcNow, null);

        public static User Create(UserRequest userRequest, Role role)
            => new User(Guid.NewGuid(), userRequest.Name, userRequest.LastName, userRequest.Email, 
                userRequest.ConfirmEmail, Convert.ToDateTime(userRequest.BirthDate), 
                userRequest.Password, userRequest.ConfirmPassword, role, DateTime.UtcNow, null);

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

        private void Validate()
        {
            var validation = new UserValidation().Validate(this);
            if (!validation.IsValid)
                Error = validation.Errors.Select(c => c.ErrorMessage).ToList();
        }
    }
}