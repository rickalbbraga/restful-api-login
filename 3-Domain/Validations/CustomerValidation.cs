using Domain.Entities;
using FluentValidation;
using Restful.Login.Domain.Enums.Errors;
using System;

namespace Restful.Login.Domain.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            string patternEmail = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            string patternPhone = @"[0-9]{10,11}";

            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ErrorMessageCustomer.FirstNameEmpty);
            RuleFor(x => x.FirstName).Length(3, 50).WithMessage(ErrorMessageCustomer.FirstNameLengthMinorOrBiggerRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ErrorMessageCustomer.LastNameEmpty);
            RuleFor(x => x.LastName).Length(3, 50).WithErrorCode("LastName must have min lenght 3 character or max lenght 50 character");
            RuleFor(x => x.Email).NotEmpty().WithErrorCode("Email is required field");
            RuleFor(x => x.Email).Matches(patternEmail).WithErrorCode("Invalid Email");
            RuleFor(x => x.Phone).NotEmpty().WithErrorCode("Phone is required field");
            RuleFor(x => x.Phone).Matches(patternPhone).WithErrorCode("Invalid Phone");
            //RuleFor(x => x.BirthDate).Must(date => DateIsValid(date)).WithErrorCode("Invalid BirthDate");
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
