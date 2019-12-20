using Domain.Contracts.Requests;
using Entity = Domain.Entities;
using Xunit;
using System;
using Restful.Login.Domain.Entities;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Restful.Login.Domain.Enums.Errors;

namespace Test.EntitiesTests.User
{
    public class UserTest
    {
        [Fact]
        public void CreateSuccess()
        {
            var user = Entity.User.Create("Teste", "Teste", "teste@teste.com", "teste@teste.com", DateTime.Parse("1990-10-10"), "Teste!@3", "Teste!@3", Role.Create("Owner"));
            Assert.True(user.IsValid);
        }

        [Theory]
        [ClassData(typeof(UserTestsCaseData))]
        public void UserCreatedWithError(Entity.User user, string errorMessage)
        {
            Assert.False(user.IsValid);
            Assert.Equal(errorMessage, user.Error.FirstOrDefault());
        }
    }

    public class UserTestsCaseData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { Entity.User.Create(string.Empty, "Teste", "teste@teste.com", "teste@teste.com", DateTime.UtcNow, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.NameEmpty },
                new object[] { Entity.User.Create("Testeaçslkdfalskjfaçsdkfjalskdjfasdçfalsdkfjasdlfkjasdçfasdlfakdfjasdçfkajdflajdflajdfajsdflajdflafakdfaldfkajsdlfkajsdlfajdlçfjasldfasdlf", string.Empty, "teste@teste.com", "teste@teste.com", DateTime.UtcNow, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.NameLengthMinorOrBiggerRequired },
                new object[] { Entity.User.Create("Teste", string.Empty, "teste@teste.com", "teste@teste.com", DateTime.UtcNow, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.LastNameEmpty },
                new object[] { Entity.User.Create("Teste", "Testealsjdlfajsdlfjasdlfjasldkjfalsdjfalksdjfalksdjfaklsdjflaksdjfalkjdflaksdjflakdjfalksdjfalksdjfalksdjfalkdjfalkdjfjfa", "teste@teste.com", "teste@teste.com", DateTime.UtcNow, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.LastNameLengthMinorOrBiggerRequired },
                new object[] { Entity.User.Create("Teste", "Teste", string.Empty, "teste@teste.com", DateTime.UtcNow, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.EmailEmpty },
                new object[] { Entity.User.Create("Teste", "Teste", "teste.com", "teste@teste.com", DateTime.UtcNow, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.InvalidEmail },
                //new object[] { Customer.Create("Teste", "ABed", "teste@teste.com", string.Empty, DateTime.UtcNow), ErrorMessageCustomer.PhoneEmpty },
                //new object[] { Customer.Create("Teste", "ABed", "teste@teste.com", "1198765432187", DateTime.UtcNow), ErrorMessageCustomer.InvalidPhone },
            };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}