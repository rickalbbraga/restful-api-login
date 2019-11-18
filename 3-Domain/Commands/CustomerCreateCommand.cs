using MediatR;

namespace Domain.Commands
{
    public class CustomerCreateCommand : IRequest<string>
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
    }
}