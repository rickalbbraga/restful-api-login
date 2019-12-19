using Domain.Contracts.Requests;
using Entity = Domain.Entities;
using Xunit;

namespace Test.EntitiesTests.User
{
    public class UserTest
    {
        //private UserRequest request;

        //[Fact]
        //public void CreateSuccess()
        //{
        //    var user = Entity.User.Create(CreateRequest());
        //    Assert.True(user.IsValid);
        //}

        //[Fact]
        //public void CreateWithNameEmpty()
        //{
        //    var request = CreateRequest();
        //    request.Name = string.Empty;
        //    var user = Entity.User.Create(request);
        //    Assert.False(user.IsValid);
        //}

        //[Fact]
        //public void CreateWithLastNameEmpty()
        //{
        //    var request = CreateRequest();
        //    request.LastName = string.Empty;
        //    var user = Entity.User.Create(request);
        //    Assert.False(user.IsValid);
        //}

        //[Fact]
        //public void CreateWithEmailEmpty()
        //{
        //    var request = CreateRequest();
        //    request.Email = string.Empty;
        //    var user = Entity.User.Create(request);
        //    Assert.False(user.IsValid);
        //}

        //[Fact]
        //public void CreateWithConfirmEmailEmpty()
        //{
        //    var request = CreateRequest();
        //    request.ConfirmEmail = string.Empty;
        //    var user = Entity.User.Create(request);
        //    Assert.False(user.IsValid);
        //}

        //[Fact]
        //public void CreateWithConfirmEmailNotEqualEmail()
        //{
        //    var request = CreateRequest();
        //    request.ConfirmEmail = "teste@te.com.br";
        //    var user = Entity.User.Create(request);
        //    Assert.False(user.IsValid);
        //}

        //[Fact]
        //public void CreateWithEmailNotEmailAddress()
        //{
        //    var request = CreateRequest();
        //    request.Email = "teste.com";
        //    var user = Entity.User.Create(request);
        //    Assert.False(user.IsValid);
        //}

        //[Fact]
        //public void CreateWitPasswordEmpty()
        //{
        //    var request = CreateRequest();
        //    request.Password = string.Empty;
        //    var user = Entity.User.Create(request);
        //    Assert.False(user.IsValid);
        //}

        //[Fact]
        //public void CreateWitPasswordLessThan8()
        //{
        //    var request = CreateRequest();
        //    request.Password = "asdf157";
        //    var user = Entity.User.Create(request);
        //    Assert.False(user.IsValid);
        //}

        //[Fact]
        //public void CreateWitConfirmPasswordNotEqualPassword()
        //{
        //    var request = CreateRequest();
        //    request.ConfirmPassword = "asdf157";
        //    var user = Entity.User.Create(request);
        //    Assert.False(user.IsValid);
        //}

        // [Fact]
        // public void CreateWithBirthDateInvalid()
        // {
        //     var request = CreateRequest();
        //     request.BirthDate = "15/18/1990";
        //     var user = Entity.User.Create(request);
        //     Assert.False(user.IsValid);
        // }

        private static UserRequest CreateRequest()
        {
            return new UserRequest
            {
                Name = "User Test",
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