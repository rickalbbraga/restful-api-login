using AutoMapper;
using Domain.Validations;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Domain.Contracts.Requests;
using Restful.Login.Domain.Contracts.Response;
using Restful.Login.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restful.Login.Application.Services
{
    public class RoleService : Notifiable, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(
            IRoleRepository roleRepository,
            IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleResponse> Add(RoleRequest roleRequest)
        {
            Role role = Role.Create(roleRequest.Name);

            _roleRepository.Add(role);

            return await Task.FromResult(_mapper.Map<Role, RoleResponse>(role));
        }

        public async Task<IList<RoleResponse>> GetAll()
        {
            var roles = await _roleRepository.GetAll();
            return _mapper.Map<IEnumerable<Role>, IList<RoleResponse>>(roles);
        }
    }
}
