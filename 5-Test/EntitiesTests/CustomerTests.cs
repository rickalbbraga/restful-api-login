using Domain.Entities;
using Restful.Login.Domain.Enums.Errors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Extensions;

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
        [MemberData(nameof(CustomerTestData))]
        //[ClassData(typeof(CustomerTestData))]
        public void CustomerCreatedErrors(Customer customer, string errorMessage)
        {
            Assert.False(customer.IsValid); 
            Assert.Equal(errorMessage, customer.Error.FirstOrDefault());
        }

        //public class CustomerTestData : IEnumerable<object[]>
        //{
        //    private readonly List<object[]> _data = new List<object[]>
        //    {
        //        new object[] { Customer.Create(string.Empty, "Teste", "teste@teste.com", "11987654321", DateTime.UtcNow), ErrorMessageCustomer.FirstNameEmpty },
        //        new object[] { Customer.Create("AB", "Teste", "teste@teste.com", "11987654321", DateTime.UtcNow), ErrorMessageCustomer.FirstNameLengthMinorOrBiggerRequired },
        //        new object[] { Customer.Create("Teste", string.Empty, "teste@teste.com", "11987654321", DateTime.UtcNow), ErrorMessageCustomer.LastNameEmpty }
        //    };

        //    public IEnumerator<object[]> GetEnumerator()
        //    { return _data.GetEnumerator(); }

        //    IEnumerator IEnumerable.GetEnumerator()
        //    { return GetEnumerator(); }
        //}

        public static IEnumerable<object[]> CustomerTestData
        {
            get
            {
                return new[]
                {
                    new object[] { Customer.Create(string.Empty, "Teste", "teste@teste.com", "11987654321", DateTime.UtcNow), ErrorMessageCustomer.FirstNameEmpty },
                    new object[] { Customer.Create("AB", "Teste", "teste@teste.com", "11987654321", DateTime.UtcNow), ErrorMessageCustomer.FirstNameLengthMinorOrBiggerRequired },
                    new object[] { Customer.Create("Teste", string.Empty, "teste@teste.com", "11987654321", DateTime.UtcNow), ErrorMessageCustomer.LastNameEmpty }
                };
            }
        }
    }
}
