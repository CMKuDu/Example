
using RabbitMQ.Client;

namespace WebAPITest.Infastructure.RabbitMQBus
{
    public interface IRabbitMQBus
    {
        IConnection Connection { get; }
    }
}
