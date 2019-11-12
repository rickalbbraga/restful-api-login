using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts.Requests;

namespace Domain.Contracts.Interfaces.Services
{
    public interface IUserRegisterService
    {
        Task<dynamic> Add(UserRequest userRequest);

        IEnumerable<dynamic> GetAll();

        Task<dynamic> GetById(Guid id);

        void Update(UserUpdateRequest userRequest, Guid userId);

        void Delete(Guid id);
    }
}