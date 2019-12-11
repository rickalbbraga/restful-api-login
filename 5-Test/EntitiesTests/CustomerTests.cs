using Domain.Entities;
using Restful.Login.Domain.Enums.Errors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Restful.Login.Test.EntitiesTests
{
    public class CustomerTests
    {
        private Customer CustomerFirstNameEmpty = Customer.Create(string.Empty, "Teste", "teste@teste.com", "11987654321", DateTime.UtcNow);

        [Fact]
        public void CustomerCreatedSuccess()
        {
            Customer customerSuccess = Customer.Create("Teste", "Teste", "teste@teste.com", "11987654321", DateTime.UtcNow);
            Assert.True(customerSuccess.IsValid);
        }

        [Theory]
        [ClassData(typeof(CustomerTestsCaseData))]
        public void CustomerCreatedErrors(Customer customer, string errorMessage)
        {
            Assert.False(customer.IsValid); 
            Assert.Equal(errorMessage, customer.Error.FirstOrDefault());
        }
    }

    public class CustomerTestsCaseData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { Customer.Create(string.Empty, "Teste", "teste@teste.com", "11987654321", DateTime.UtcNow), ErrorMessageCustomer.FirstNameEmpty },
                new object[] { Customer.Create("AB", "Teste", "teste@teste.com", "11987654321", DateTime.UtcNow), ErrorMessageCustomer.FirstNameLengthMinorOrBiggerRequired },
                new object[] { Customer.Create("Teste", string.Empty, "teste@teste.com", "11987654321", DateTime.UtcNow), ErrorMessageCustomer.LastNameEmpty },
                new object[] { Customer.Create("Teste", "AB", "teste@teste.com", "11987654321", DateTime.UtcNow), ErrorMessageCustomer.LastNameLengthMinorOrBiggerRequired },
                new object[] { Customer.Create("Teste", "AceB", string.Empty, "11987654321", DateTime.UtcNow), ErrorMessageCustomer.EmailEmpty },
                new object[] { Customer.Create("Teste", "ABed", "teste@@teste.com", "11987654321", DateTime.UtcNow), ErrorMessageCustomer.InvalidEmail },
                new object[] { Customer.Create("Teste", "ABed", "teste@teste.com", string.Empty, DateTime.UtcNow), ErrorMessageCustomer.PhoneEmpty },
                new object[] { Customer.Create("Teste", "ABed", "teste@teste.com", "1198765432187", DateTime.UtcNow), ErrorMessageCustomer.InvalidPhone },
            };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
