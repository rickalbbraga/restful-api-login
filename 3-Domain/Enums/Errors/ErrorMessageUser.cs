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

        public static string PhoneEmpty { get { return new ErrorMessageUser("Phone is required field").Value; } }

        public static string InvalidPhone { get { return new ErrorMessageUser("Invalid Phone").Value; } }
    }
}
