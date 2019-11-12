namespace Domain.Contracts.Requests
{
    public class UserUpdateRequest
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ConfirmEmail { get; set; }

        public string BirthDate { get; set; }
    }
}