using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Restful.Login.Domain.Notifications;

namespace Restful.Login.Domain.EventHandlers
{
    public class EmailHandler : INotificationHandler<CustomerActionNotification>
    {
        public Task Handle(CustomerActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("O cliente {0} {1} foi {2} com sucesso", notification.FirstName, notification.LastName, notification.Action.ToString().ToLower());
            });
        }
    }
}
