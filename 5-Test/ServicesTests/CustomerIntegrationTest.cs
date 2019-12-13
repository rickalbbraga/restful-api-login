using AutoMapper;
using MediatR;
using Moq;
using Restful.Login.Application.Services;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Domain.Contracts.Requests;
using Xunit;

namespace Restful.Login.Test.ServicesTests
{
    public class CustomerIntegrationTest
    {
        private readonly ICustomerService _customerService;
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        public CustomerIntegrationTest()
        {
            _customerService = new CustomerService(_mockMediator.Object, _mockMapper.Object);
        }

        [Fact]
        public void GivenCustomerSentThenReturnError()
        {

        }

        private CustomerRequest CreateRequest()
        {
            return new CustomerRequest
            {
                FirstName = "Teste",
                LastName = "Teste",
                Email = "teste@teste.com",
                Phone = "11987654321",
                BirthDate = "03/01/1990"
            };
        }
    }
}
