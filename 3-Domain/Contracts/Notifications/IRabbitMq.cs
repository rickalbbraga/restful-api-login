using System.Threading.Tasks;

namespace Restful.Login.Domain.Contracts.Notifications
{
    public interface IRabbitMq
    {
        bool PublishMessage(string queue, object obj);
    }
}
