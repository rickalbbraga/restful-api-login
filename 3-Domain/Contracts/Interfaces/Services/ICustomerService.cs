using Restful.Login.Domain.Contracts.Requests;
using System.Threading.Tasks;

namespace Restful.Login.Domain.Contracts.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<dynamic> Add(CustomerRequest customerRequest);
    }
}
