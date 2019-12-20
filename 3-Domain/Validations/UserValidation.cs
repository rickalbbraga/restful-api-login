using System;
using Domain.Entities;
using FluentValidation;
using Restful.Login.Domain.Enums.Errors;

namespace Domain.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorMessageUser.NameEmpty);
            RuleFor(x => x.Name).NotNull().WithMessage(ErrorMessageUser.NameEmpty);
            RuleFor(x => x.Name).Length(3, 50).WithMessage(ErrorMessageUser.NameLengthMinorOrBiggerRequired);          
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ErrorMessageUser.LastNameEmpty);
            RuleFor(x => x.LastName).NotNull().WithMessage(ErrorMessageUser.LastNameEmpty); 
            RuleFor(x => x.LastName).Length(3, 50).WithMessage(ErrorMessageUser.LastNameLengthMinorOrBiggerRequired);
            RuleFor(x => x.Email).NotEmpty().WithMessage(ErrorMessageUser.EmailEmpty);
            RuleFor(x => x.Email).NotNull().WithMessage(ErrorMessageUser.EmailEmpty);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ErrorMessageUser.InvalidEmail);
            RuleFor(x => x.ConfirmEmail).NotEmpty().WithMessage("ConfirmEmail is required field");
            RuleFor(x => x.ConfirmEmail).NotNull().WithMessage("ConfirmEmail is required field");
            RuleFor(x => x.ConfirmEmail).Equal(x => x.Email).WithMessage("ConfirmEmail is different from email");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required field");
            RuleFor(x => x.Password).NotNull().WithMessage("Password is required field");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Password have must min lenght 3 and max length 50 characters");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword is required field");
            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("ConfirmPassword is required field");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("ConfirmPassword is different from password");
            RuleFor(x => x.Role).NotEmpty().WithMessage("Role is required field");
            RuleFor(x => x.Role).NotNull().WithMessage("Role is required field");
            RuleFor(x => x.BirthDate).Must(date => DateIsValid(date)).WithMessage("Invalid birthDate");
        }

        private bool DateIsValid(DateTime? date)
        {
            if (date is null)
                return true;

            if (date.Equals(DateTime.MinValue))
                return false;

            return true;
        }
    }
}