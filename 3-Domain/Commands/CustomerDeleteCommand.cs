using MediatR;

namespace Domain.Commands
{
    public class CustomerDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}