namespace Restful.Login.Domain.Enums.Errors
{
    public class ErrorMessageCustomer
    {
        private ErrorMessageCustomer(string value) { Value = value; }

        private string Value { get; }

        public static string FirstNameEmpty { get { return new ErrorMessageCustomer("FirstName is required field").Value; } }
        public static string FirstNameLengthMinorOrBiggerRequired { get { return new ErrorMessageCustomer("FirstName must have min lenght 3 character or max lenght 50 character").Value; } }
        public static string LastNameEmpty { get { return new ErrorMessageCustomer("LastName is required field").Value; } }
    }
}
