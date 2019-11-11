using System;
using System.Threading.Tasks;
using Domain.Contracts.Interfaces.Services;
using Domain.Contracts.Requests;
using Domain.Entities;
using Domain.Validations;

namespace Application.Services
{
    public class UserRegisterService : Notifiable, IUserRegisterService
    {
        public async Task<dynamic> Add(UserRequest userRequest)
        {
            var user = User.Create(userRequest);
            if (!user.IsValid)
            {
                Error = user.Error;
                return null;    
            }

            return Guid.NewGuid();
        }
    }
}