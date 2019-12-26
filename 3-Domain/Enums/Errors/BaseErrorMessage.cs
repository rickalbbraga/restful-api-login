namespace Restful.Login.Domain.Enums.Errors
{
    public class BaseErrorMessage
    {
        protected string Value { get; set; }

        protected BaseErrorMessage(string value)
        {
            Value = value;
        }

        public static string InvalidRequest { get { return new BaseErrorMessage("Invalid Request").Value; } }
    }
}
