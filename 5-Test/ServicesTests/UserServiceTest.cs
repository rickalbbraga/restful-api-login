using System.Linq;
using Application.Services;
using Domain.Contracts.Interfaces.Repositories;
using Domain.Contracts.Interfaces.Services;
using Domain.Contracts.Requests;
using Domain.Entities;
using Domain.Validations;
using Moq;
using Xunit;

namespace Test.ServicesTests
{
    public class UserServiceTest
    {
        private readonly IUserRegisterService userRegisterService;
        private readonly Mock<IUserRegisterRepository> mockUserRepository = new Mock<IUserRegisterRepository>();

        public UserServiceTest()
        {
            userRegisterService = new UserRegisterService(mockUserRepository.Object);
        }

        [Fact]
        public void AddUserWithRequestNull()
        {
            var response = userRegisterService.Add(null).Result;
            var notification = userRegisterService as Notifiable;
            Assert.Equal("30000", notification.Error.FirstOrDefault());
        }

        [Fact]
        public void AddUserWithRequestInvalid()
        {
            var request = CreateRequest();
            request.Name = string.Empty;
            var response = userRegisterService.Add(request).Result;
            var notification = userRegisterService as Notifiable;
            Assert.Equal("10000", notification.Error.FirstOrDefault());
        }

        [Fact]
        public void AddUserWithSuccess()
        {
            mockUserRepository.Setup(x => x.Add(It.IsAny<User>()));
            var request = CreateRequest();
            var response = userRegisterService.Add(request).Result;
            var notification = userRegisterService as Notifiable;
            Assert.Equal(true, notification.IsValid);
        }

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