namespace Restful.Login.Domain.Enums.Errors
{
    public class ErrorMessageUser
    {
        private string Value { get; }

        private ErrorMessageUser(string value)
        {
            Value = value;
        }

        public static string NameEmpty { get { return new ErrorMessageUser("Name is required field").Value; } }

        public static string NameLengthMinorOrBiggerRequired { get { return new ErrorMessageUser("Name have must min lenght 3 and max length 50 characters").Value; } }

        public static string LastNameEmpty { get { return new ErrorMessageUser("LastName is required field").Value; } }

        public static string LastNameLengthMinorOrBiggerRequired { get { return new ErrorMessageUser("LastName have must min lenght 3 and max length 50 characters").Value; } }

        public static string EmailEmpty { get { return new ErrorMessageUser("Email is required field").Value; } }

        public static string InvalidEmail { get { return new ErrorMessageUser("Invalid Email").Value; } }

        public static string ConfirmEmailEmpty { get { return new ErrorMessageUser("ConfirmEmail is required field").Value; } }

        public static string ConfirmEmailNotEqualEmail { get { return new ErrorMessageUser("ConfirmEmail is different from Email").Value; } }

        public static string PasswordEmpty { get { return new ErrorMessageUser("Password is required field").Value; } }

        public static string PasswordLengthMinorOrBiggerRequired { get { return new ErrorMessageUser("Password have must min lenght 3 and max length 50 characters").Value; } }

        public static string ConfirmPasswordEmpty { get { return new ErrorMessageUser("ConfirmPassword is required field").Value; } }

        public static string ConfirmPasswordNotEqualPassword { get { return new ErrorMessageUser("ConfirmPassword is different from Password").Value; } }

        public static string RoleEmpty { get { return new ErrorMessageUser("Role is required field").Value; } }

        public static string InvalidBirthDate { get { return new ErrorMessageUser("Invalid BirthDate").Value; } }
    }
}
