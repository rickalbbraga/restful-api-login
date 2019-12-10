using System;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithErrorCode("10000");
            RuleFor(x => x.Name).NotNull().WithErrorCode("10001"); 
            RuleFor(x => x.Name).Length(3, 50).WithErrorCode("10002");;           
            RuleFor(x => x.LastName).NotEmpty().WithErrorCode("10003");;
            RuleFor(x => x.LastName).NotNull().WithErrorCode("10004");; 
            RuleFor(x => x.LastName).Length(3, 50).WithErrorCode("10005");;
            RuleFor(x => x.Email).NotEmpty().WithErrorCode("10006");;
            RuleFor(x => x.Email).NotNull().WithErrorCode("10007");;
            RuleFor(x => x.Email).EmailAddress().WithErrorCode("10008");;
            RuleFor(x => x.ConfirmEmail).NotEmpty().WithErrorCode("10009");;
            RuleFor(x => x.ConfirmEmail).NotNull().WithErrorCode("10010");;
            RuleFor(x => x.ConfirmEmail).EmailAddress().WithErrorCode("10011");;
            RuleFor(x => x.ConfirmEmail).Equal(x => x.Email).WithErrorCode("10012");
            RuleFor(x => x.Password).NotEmpty().WithErrorCode("10013");
            RuleFor(x => x.Password).NotNull().WithErrorCode("10014");
            RuleFor(x => x.Password).MinimumLength(8).WithErrorCode("10015");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithErrorCode("10016");
            RuleFor(x => x.ConfirmPassword).NotNull().WithErrorCode("10017");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithErrorCode("10019");
            RuleFor(x => x.BirthDate).Must(date => DateIsValid(date)).WithErrorCode("10020");
        }

        private bool DateIsValid(DateTime date)
        {
            DateTime temp;

            if (DateTime.TryParse(date.ToString(), out temp))
                return true;
            return false;
        }
    }
}