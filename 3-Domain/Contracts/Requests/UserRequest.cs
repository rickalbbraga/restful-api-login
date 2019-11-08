namespace Domain.Contracts.Requests
{
    public class UserRequest
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string BirthDate { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}