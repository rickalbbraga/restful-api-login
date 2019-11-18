using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;

namespace Restful.Login.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> Customers { get; }

        public CustomerRepository()
        {
            Customers = new List<Customer>();
        }

        public async Task Delete(Guid id)
        {
            int index = Customers.FindIndex(m => m.Id == id);
            await Task.Run(() => Customers.RemoveAt(index));
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await Task.FromResult(Customers);
        }

        public async Task<Customer> GetById(Guid id)
        {
            var result = Customers.Where(p => p.Id == id).FirstOrDefault();
            return await Task.FromResult(result);
        }

        public async Task Save(Customer customer)
        {
            await Task.Run(() => Customers.Add(customer));
        }

        public async Task Update(Guid id, Customer customer)
        {
            int index = Customers.FindIndex(m => m.Id == id);
            if (index >= 0)
                await Task.Run(() => Customers[index] = customer);
        }
    }
}
