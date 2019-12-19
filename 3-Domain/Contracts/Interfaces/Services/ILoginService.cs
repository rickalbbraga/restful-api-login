using Restful.Login.Domain.Contracts.Requests;
using Restful.Login.Domain.Contracts.Response;
using System.Threading.Tasks;

namespace Restful.Login.Domain.Contracts.Interfaces.Services
{
    public interface ILoginService
    {
        Task<LoginResponse> Authentication(LoginRequest login);
    }
}
