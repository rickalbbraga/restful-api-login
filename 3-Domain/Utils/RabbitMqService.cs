using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Restful.Login.Domain.Contracts.Notifications;
using System;
using System.Collections.Generic;
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

        public IList<object> ConsumeMessage(string queue)
        {
            IList<object> paymentSlipRegisterList = new List<object>();

            try
            {
                ConnectionFactory connectionFactory = new ConnectionFactory
                {
                    HostName = _rabbitConfiguration.HostName,
                    UserName = _rabbitConfiguration.UserName,
                    Port = _rabbitConfiguration.Port,
                    Password = _rabbitConfiguration.Password,

                };

                using (var connection = connectionFactory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    var queueDeclareResponse = channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
                    var consumer = new EventingBasicConsumer(channel);

                    for (int i = 0; i < queueDeclareResponse.MessageCount; i++)
                    {
                        var ea = channel.BasicGet(queue: queue, autoAck: false);
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        var entity = JsonConvert.DeserializeObject<object>(message);
                        paymentSlipRegisterList.Add(entity);
                    }
                }
            }
            catch (Exception ex)
            {
                //_logger.Error(new LogEntity
                //{
                //    Exception = ex,
                //    Project = "Net.Neon.Api.Partner.Consume.PaymentSlip"
                //}, new { Message = $"Error consume queue {queue}" });
            }

            return paymentSlipRegisterList;
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
