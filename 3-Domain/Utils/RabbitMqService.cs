using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Restful.Login.Domain.Contracts.Notifications;
using System;
using System.Text;

namespace Restful.Login.Domain.Utils
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly RabbitMqConfiguration _rabbitConfiguration;

        public RabbitMqService(IOptions<RabbitMqConfiguration> options)
        {
            _rabbitConfiguration = options.Value;
        }

        public bool PublishMessage(string queue, object obj)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = _rabbitConfiguration.HostName,
                    Port = _rabbitConfiguration.Port,
                    UserName = _rabbitConfiguration.UserName,
                    Password = _rabbitConfiguration.Password
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queue,
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    string message = JsonConvert.SerializeObject(obj);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(string.Empty,
                                         queue,
                                         null,
                                         body);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //grava erro elasticsearch
                return false;
            }
        }
    }
}
