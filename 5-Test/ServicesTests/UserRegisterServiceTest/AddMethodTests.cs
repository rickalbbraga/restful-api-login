using Application.Services;
using AutoMapper;
using Domain.Contracts.Interfaces.Repositories;
using Domain.Contracts.Interfaces.Services;
using Domain.Contracts.Requests;
using Domain.Entities;
using Domain.Validations;
using Moq;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Restful.Login.Domain.Entities;
using Restful.Login.Domain.Enums.Errors;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Restful.Login.Test.ServicesTests.UserRegisterServiceTest
{
    public class AddMethodTests
    {
        private readonly IUserRegisterService userRegisterService;
        private readonly Mock<IUserRegisterRepository> mockUserRepository = new Mock<IUserRegisterRepository>();
        private readonly Mock<IRoleRepository> mockRoleRepository = new Mock<IRoleRepository>();
        private readonly Mock<IMapper> mockMapper = new Mock<IMapper>();

        public AddMethodTests()
        {
            userRegisterService = new UserRegisterService(mockUserRepository.Object, mockRoleRepository.Object, mockMapper.Object);
        }

        [Fact]
        public void InvalidRequestWhenRequestLikeNull()
        {
            userRegisterService.Add(null).Wait();
            var notification = userRegisterService as Notifiable;
            Assert.Equal(ErrorMessageUserRegisterService.InvalidRequest, notification.Error.FirstOrDefault().Message);
        }

        [Fact]
        public void InvalidRoleIdWhenRoleIdGivenLikeNull()
        {
            mockRoleRepository.Setup(m => m.FindById(It.IsAny<Guid>())).Returns(Task.FromResult(null as Role));
            var request = CreateRequest();

            var response = userRegisterService.Add(request).Result;
            var notification = userRegisterService as Notifiable;
            Assert.Equal(ErrorMessageUserRegisterService.InvalidRoleId, notification.Error.FirstOrDefault().Message);
        }

        [Fact]
        public void TrueWhenUserRegisterGivenWithSuccess()
        {
            mockRoleRepository.Setup(m => m.FindById(It.IsAny<Guid>())).Returns(Task.FromResult(Role.Create("ADM")));
            mockUserRepository.Setup(x => x.Add(It.IsAny<User>())).Verifiable();
            var request = CreateRequest();

            var response = userRegisterService.Add(request).Result;
            var notification = userRegisterService as Notifiable;
            Assert.True(notification.IsValid);
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
