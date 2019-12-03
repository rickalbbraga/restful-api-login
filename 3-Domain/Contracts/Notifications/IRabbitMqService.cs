using System.Threading.Tasks;

namespace Restful.Login.Domain.Contracts.Notifications
{
    public interface IRabbitMqService
    {
        bool PublishMessage(string queue, object obj);
    }
}
