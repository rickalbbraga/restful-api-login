using Restful.Login.Domain.Contracts.Requests;
using Restful.Login.Domain.Contracts.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restful.Login.Domain.Contracts.Interfaces.Services
{
    public interface IRoleService
    {
        Task<RoleResponse> Add(RoleRequest roleRequest);

        Task<IList<RoleResponse>> GetAll();
    }
}
