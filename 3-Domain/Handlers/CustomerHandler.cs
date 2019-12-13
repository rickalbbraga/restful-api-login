using Domain.Commands;
using Domain.Entities;
using Domain.Validations;
using MediatR;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Restful.Login.Domain.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class CustomerHandler : Notifiable, IRequestHandler<CustomerCreateCommand, Customer>
    {
        private readonly IMediator _mediator;
        private readonly ICustomerRepository _customerRepository;

        public CustomerHandler(IMediator mediator, ICustomerRepository customerRepository)
        {
            _mediator = mediator;
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(request.FirstName, request.LastName, request.Email, request.Phone, request.BirthDate);

            if (!customer.IsValid)
            {
                AddErrors(customer.Error);
                return null;
            }
                
            await _customerRepository.Save(customer);

            await _mediator.Publish(new CustomerActionNotification(customer, ActionNotification.Criado), cancellationToken);
            
            return await Task.FromResult(customer);
        }
    }
}