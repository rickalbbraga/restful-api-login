using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restful.Login.Domain.Contracts.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task Save(Customer customer);
        
        Task Update(Guid id, Customer customer);
        
        Task Delete(Guid id);
        
        Task<Customer> GetById(Guid id);
        
        Task<IEnumerable<Customer>> GetAll();
    }
}
