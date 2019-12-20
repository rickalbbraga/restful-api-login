using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts.Interfaces.Repositories;
using Domain.Contracts.Interfaces.Services;
using Domain.Contracts.Requests;
using Domain.Entities;
using Domain.Validations;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Restful.Login.Domain.Contracts.Response;

namespace Application.Services
{
    public class UserRegisterService : Notifiable, IUserRegisterService
    {
        private readonly IUserRegisterRepository _userRegisterRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UserRegisterService(
            IUserRegisterRepository userRegisterRepository,
            IRoleRepository roleRepository,
            IMapper mapper)
        {
            _userRegisterRepository = userRegisterRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> Add(UserRequest userRequest)
        {
            if (userRequest == null)
            {
                AddError("Invalid request");
                return null;
            }

            var role = await _roleRepository.FindById(userRequest.RoleId);

            if (role is null)
            {
                AddError("Invalid roleId");
                return null;
            }

            var user = User.Create(userRequest, role);

            if (!user.IsValid)
            {
                AddErrors(user.Error);
                return null;    
            }

            _userRegisterRepository.Add(user);
            return await Task.FromResult(_mapper.Map<User, UserResponse>(user));
        }

        public void Delete(Guid id)
        {
            var entity = _userRegisterRepository.FindById(id).Result;
            if (entity.Id == null)
                AddError("30000");
            
            _userRegisterRepository.Delete(entity);
        }

        public IEnumerable<dynamic> GetAll() 
            => _userRegisterRepository.GetAll().Result;

        public async Task<dynamic> GetById(Guid id) 
            => await _userRegisterRepository.FindById(id);

        public void Update(UserUpdateRequest userUpdateRequest, Guid userId)
        {
            var entityRegistered = _userRegisterRepository.FindById(userId).Result;
            entityRegistered.Update(userUpdateRequest);

            if (!entityRegistered.IsValid)
                AddErrors(entityRegistered.Error);

            _userRegisterRepository.Update(entityRegistered);
        }
    }
}