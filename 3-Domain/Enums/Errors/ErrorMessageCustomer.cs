namespace Restful.Login.Domain.Enums.Errors
{
    public class ErrorMessageCustomer
    {
        private string Value { get; }

        private ErrorMessageCustomer(string value)
        { 
            Value = value;
        }

        public static string FirstNameEmpty { get { return new ErrorMessageCustomer("FirstName is required field").Value; } }
        
        public static string FirstNameLengthMinorOrBiggerRequired { get { return new ErrorMessageCustomer("FirstName must have min lenght 3 character or max lenght 50 character").Value; } }
        
        public static string LastNameEmpty { get { return new ErrorMessageCustomer("LastName is required field").Value; } }
        
        public static string LastNameLengthMinorOrBiggerRequired { get { return new ErrorMessageCustomer("LastName must have min lenght 3 character or max lenght 50 character").Value; } }
        
        public static string EmailEmpty { get { return new ErrorMessageCustomer("Email is required field").Value; } }
        
        public static string InvalidEmail { get { return new ErrorMessageCustomer("Invalid Email").Value; } }
        
        public static string PhoneEmpty { get { return new ErrorMessageCustomer("Phone is required field").Value; } }
        
        public static string InvalidPhone { get { return new ErrorMessageCustomer("Invalid Phone").Value; } }
    }
}
