namespace Restful.Login.Domain.Contracts.Response
{
    public class LoginResponse
    {
        public string JWT { get; set; }

        public LoginResponse(string jwt)
        {
            JWT = jwt;
        }
    }
}
