using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using WebAPITest.Infastructure.RabbitMQBus;

namespace WebTest.Applicationn.Service
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IRabbitMQBus _rabbitMQBus;

        // Cấu hình tên exchange và queue nếu cần thiết
        private const string _defaultExchange = "order_create_exchange";
        private const string _defaultQueue = "order.event";
        private const string _defaultRoutingKey = "order.event";

        public RabbitMQService(IRabbitMQBus rabbitMQBus)
        {
            _rabbitMQBus = rabbitMQBus;
            SetupQueueAndExchange();
        }

        private void SetupQueueAndExchange()
        {
            using var channel = _rabbitMQBus.Connection.CreateModel();
            channel.ExchangeDeclare(exchange: _defaultExchange, type: ExchangeType.Topic, durable: true, autoDelete: false);
            channel.QueueDeclare(queue: _defaultQueue, durable: true, exclusive: false, autoDelete: false);
            channel.QueueBind(queue: _defaultQueue, exchange: _defaultExchange, routingKey: _defaultRoutingKey);
        }

        public void Publish<T>(T message, string exchange = _defaultExchange, string routingKey = _defaultRoutingKey) where T : class
        {
            using var channel = _rabbitMQBus.Connection.CreateModel();

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(exchange: exchange, routingKey: routingKey, basicProperties: properties, body: body);
        }
    }
}