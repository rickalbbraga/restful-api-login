using System;
using System.Threading.Tasks;
using Domain.Contracts.Requests;

namespace Domain.Contracts.Interfaces.Services
{
    public interface IUserRegisterService
    {
         Task<dynamic> Add(UserRequest userRequest);
    }
}