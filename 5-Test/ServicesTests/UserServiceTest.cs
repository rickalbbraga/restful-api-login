using System.Linq;
using Application.Services;
using AutoMapper;
using Domain.Contracts.Interfaces.Repositories;
using Domain.Contracts.Interfaces.Services;
using Domain.Contracts.Requests;
using Domain.Entities;
using Domain.Validations;
using Moq;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Xunit;

namespace Test.ServicesTests
{
    public class UserServiceTest
    {
        private readonly IUserRegisterService userRegisterService;
        private readonly Mock<IUserRegisterRepository> mockUserRepository = new Mock<IUserRegisterRepository>();
        private readonly Mock<IRoleRepository> mockRoleRepository = new Mock<IRoleRepository>();
        private readonly Mock<IMapper> mockMapper = new Mock<IMapper>();

        public UserServiceTest()
        {
            userRegisterService = new UserRegisterService(mockUserRepository.Object, mockRoleRepository.Object, mockMapper.Object);
        }

        [Fact]
        public void AddUserWithRequestNull()
        {
            userRegisterService.Add(null).Wait();
            var notification = userRegisterService as Notifiable;
            Assert.Equal("Invalid Request", notification.Error.FirstOrDefault().Message);
        }

        //[Fact]
        //public void AddUserWithRequestInvalid()
        //{
        //    var request = CreateRequest();
        //    request.Name = string.Empty;
        //    var response = userRegisterService.Add(request).Result;
        //    var notification = userRegisterService as Notifiable;
        //    Assert.Equal("10000", notification.Error.FirstOrDefault());
        //}

        //[Fact]
        //public void AddUserWithSuccess()
        //{
        //    mockUserRepository.Setup(x => x.Add(It.IsAny<User>()));
        //    var request = CreateRequest();
        //    var response = userRegisterService.Add(request).Result;
        //    var notification = userRegisterService as Notifiable;
        //    Assert.True(notification.IsValid);
        //}

        private static UserRequest CreateRequest()
        {
            return new UserRequest
            {
                Name = "Teste",
                LastName = "Last Name Test",
                Email = "test@test.com.br",
                ConfirmEmail = "test@test.com.br",
                BirthDate = "15/04/2019",
                Password = "Test!23f",
                ConfirmPassword = "Test!23f"
            };
        }
    }
}