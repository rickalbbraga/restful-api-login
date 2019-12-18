using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Data.Interfaces;
using Infra.Data.Repositories;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;

namespace Restful.Login.Infra.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
