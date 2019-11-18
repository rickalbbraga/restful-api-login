using System.Threading;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Entities;
using MediatR;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Restful.Login.Domain.Notifications;

namespace Domain.Handlers
{
    public class CustomerHandler : IRequestHandler<CustomerCreateCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly ICustomerRepository _customerRepository;

        public CustomerHandler(IMediator mediator, ICustomerRepository customerRepository)
        {
            _mediator = mediator;
            _customerRepository = customerRepository;
        }

        public async Task<string> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(request.FirstName, request.LastName, request.Email, request.Phone);

            await _customerRepository.Save(customer);

            await _mediator.Publish(new CustomerActionNotification
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Action = ActionNotification.Criado
            }, cancellationToken);

            return await Task.FromResult("Cliente registrado com sucesso");
        }
    }
}