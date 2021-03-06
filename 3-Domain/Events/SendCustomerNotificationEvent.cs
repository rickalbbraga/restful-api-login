﻿using MediatR;
using Restful.Login.Domain.Contracts.Notifications;
using Restful.Login.Domain.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace Restful.Login.Domain.Events
{
    public class SendQueueEvent : INotificationHandler<CustomerActionNotification>
    {
        private readonly IRabbitMqService _rabbitMq;

        public SendQueueEvent(IRabbitMqService rabbitMq)
        {
            _rabbitMq = rabbitMq;
        }

        public Task Handle(CustomerActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _rabbitMq.PublishMessage("Customer", notification);
            });           
        }
    }
}
