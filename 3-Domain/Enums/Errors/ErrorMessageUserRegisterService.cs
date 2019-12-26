namespace Restful.Login.Domain.Enums.Errors
{
    public class ErrorMessageUserRegisterService : BaseErrorMessage
    {
        private ErrorMessageUserRegisterService(string value)
            : base(value)
        {
            Value = value;
        }

        public static string InvalidRoleId { get { return new ErrorMessageUserRegisterService("Invalid roleId").Value; } }
    }
}
