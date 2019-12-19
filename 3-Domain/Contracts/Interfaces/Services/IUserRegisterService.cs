using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts.Requests;
using Restful.Login.Domain.Contracts.Response;

namespace Domain.Contracts.Interfaces.Services
{
    public interface IUserRegisterService
    {
        Task<UserResponse> Add(UserRequest userRequest);

        IEnumerable<dynamic> GetAll();

        Task<dynamic> GetById(Guid id);

        void Update(UserUpdateRequest userRequest, Guid userId);

        void Delete(Guid id);
    }
}