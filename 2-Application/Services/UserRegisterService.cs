using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts.Interfaces.Repositories;
using Domain.Contracts.Interfaces.Services;
using Domain.Contracts.Requests;
using Domain.Entities;
using Domain.Validations;

namespace Application.Services
{
    public class UserRegisterService : Notifiable, IUserRegisterService
    {
        private readonly IUserRegisterRepository _userRegisterRepository;

        public UserRegisterService(IUserRegisterRepository userRegisterRepository)
        {
            _userRegisterRepository = userRegisterRepository;
        }

        public async Task<dynamic> Add(UserRequest userRequest)
        {
            if (userRequest == null)
            {
                Error.Add("20000");
                return null;
            }

            var user = User.Create(userRequest);
            if (!user.IsValid)
            {
                Error = user.Error;
                return null;    
            }

            _userRegisterRepository.Add(user);
            return await Task.FromResult(user);
        }

        public void Delete(Guid id)
        {
            var entity = _userRegisterRepository.FindById(id).Result;
            if (entity.Id == null)
                Error.Add("30000");
            
            _userRegisterRepository.Delete(entity);
        }

        public IEnumerable<dynamic> GetAll() 
            => _userRegisterRepository.GetAll();

        public async Task<dynamic> GetById(Guid id) 
            => await _userRegisterRepository.FindById(id);

        public void Update(UserUpdateRequest userUpdateRequest, Guid userId)
        {
            var entityRegistered = _userRegisterRepository.FindById(userId).Result;
            entityRegistered.Update(userUpdateRequest);

            if (!entityRegistered.IsValid)
                Error = entityRegistered.Error;

            _userRegisterRepository.Update(entityRegistered);
        }
    }
}