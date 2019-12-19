namespace Domain.Contracts.Response
{
    public class ErrorsResponse
    {
        public string Message { get; set; }

        public ErrorsResponse(string msg)
        {
            Message = msg;
        }
    }
}