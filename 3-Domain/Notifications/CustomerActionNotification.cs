using Domain.Entities;
using MediatR;
using System;

namespace Restful.Login.Domain.Notifications
{
    public class CustomerActionNotification : INotification
    {
        public Guid Id { get; private set; }

        public string FirstName { get; private set; }
        
        public string LastName { get; private set; }
        
        public string Email { get; private set; }

        public string Phone { get; private set; }
        
        public ActionNotification Action { get; private set; }

        public CustomerActionNotification(Customer customer, ActionNotification action)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            Phone = customer.Phone;
            Action = action;
        }
    }
}
