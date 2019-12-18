using Domain.Commands;
using Restful.Login.Domain.Contracts.Response;
using System.Threading.Tasks;

namespace Restful.Login.Domain.Contracts.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<CustomerResponse> Add(CustomerCreateCommand command);
    }
}
