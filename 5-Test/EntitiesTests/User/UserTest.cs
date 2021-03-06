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
                new object[] { Entity.User.Create("Testea�slkdfalskjfa�sdkfjalskdjfasd�falsdkfjasdlfkjasd�fasdlfakdfjasd�fkajdflajdflajdfajsdflajdflafakdfaldfkajsdlfkajsdlfajdl�fjasldfasdlf", string.Empty, "teste@teste.com", "teste@teste.com", DateTime.UtcNow, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.NameLengthMinorOrBiggerRequired },
                new object[] { Entity.User.Create("Teste", string.Empty, "teste@teste.com", "teste@teste.com", DateTime.UtcNow, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.LastNameEmpty },
                new object[] { Entity.User.Create("Teste", "Testealsjdlfajsdlfjasdlfjasldkjfalsdjfalksdjfalksdjfaklsdjflaksdjfalkjdflaksdjflakdjfalksdjfalksdjfalksdjfalkdjfalkdjfjfa", "teste@teste.com", "teste@teste.com", DateTime.UtcNow, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.LastNameLengthMinorOrBiggerRequired },
                new object[] { Entity.User.Create("Teste", "Teste", string.Empty, "teste@teste.com", DateTime.UtcNow, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.EmailEmpty },
                new object[] { Entity.User.Create("Teste", "Teste", "teste.com", "teste@teste.com", DateTime.UtcNow, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.InvalidEmail },
                new object[] { Entity.User.Create("Teste", "Teste", "teste@teste.com", string.Empty, DateTime.UtcNow, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.ConfirmEmailEmpty },
                new object[] { Entity.User.Create("Teste", "Teste", "teste@teste.com", "teste.com.br", DateTime.UtcNow, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.ConfirmEmailNotEqualEmail },
                new object[] { Entity.User.Create("Teste", "Teste", "teste@teste.com", "teste@teste.com", DateTime.UtcNow, string.Empty, "Teste!@3", Role.Create("Owner")), ErrorMessageUser.PasswordEmpty },
                new object[] { Entity.User.Create("Teste", "Teste", "teste@teste.com", "teste@teste.com", DateTime.UtcNow, "Teste!@3", string.Empty, Role.Create("Owner")), ErrorMessageUser.ConfirmPasswordEmpty },
                new object[] { Entity.User.Create("Teste", "Teste", "teste@teste.com", "teste@teste.com", DateTime.UtcNow, "Teste!@3", "Teste!@", Role.Create("Owner")), ErrorMessageUser.ConfirmPasswordNotEqualPassword },
                //new object[] { Entity.User.Create("Teste", "Teste", "teste@teste.com", "teste@teste.com", DateTime.UtcNow, "Teste!@3", "Teste!@3", null), ErrorMessageUser.RoleEmpty },
                new object[] { Entity.User.Create("Teste", "Teste", "teste@teste.com", "teste@teste.com", DateTime.MinValue, "Teste!@3", "Teste!@3", Role.Create("Owner")), ErrorMessageUser.InvalidBirthDate },
            };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}