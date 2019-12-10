using Domain.Entities;
using MediatR;
using System;

namespace Domain.Commands
{
    public class CustomerCreateCommand : IRequest<Customer>
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }
    }
}