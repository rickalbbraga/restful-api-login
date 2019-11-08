namespace Domain.Contracts.Response
{
    public class ErrorsResponse
    {
        public int Code { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }
    }
}