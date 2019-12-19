using Domain.Contracts.Interfaces.Repositories;
using Domain.Validations;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Domain.Contracts.Requests;
using Restful.Login.Domain.Contracts.Response;
using Restful.Login.Domain.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Login.Application.Services
{
    public class LoginService : Notifiable, ILoginService
    {
        private readonly IUserRegisterRepository _userRepository;
        private readonly JWTConfiguration _jwtConfiguration;

        public LoginService(
            IUserRegisterRepository userRepository,
            IOptions<JWTConfiguration> options)
        {
            _userRepository = userRepository;
            _jwtConfiguration = options.Value;
        }

        public async Task<LoginResponse> Authentication(LoginRequest login)
        {
            var user = _userRepository.GetByCondition(u => u.Email.Equals(login.Email) && u.Password.Equals(login.Password)).Result.FirstOrDefault();
            
            if (user is null)
            {
                AddError("Login invalid");
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfiguration.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.Name)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                //Expires = DateTime.UtcNow.AddSeconds(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return await Task.FromResult(new LoginResponse(tokenHandler.WriteToken(token)));
        }
    }
}
