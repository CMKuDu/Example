using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;
using WebTest.Applicationn.Event.ProductEvent;

public class ProductEventConsumer
{
    private readonly IModel _channel;

    public ProductEventConsumer(IConnection connection)
    {
        _channel = connection.CreateModel();

        _channel.ExchangeDeclare(exchange: "product_event", type: ExchangeType.Topic, durable: true, autoDelete: false);

        _channel.QueueDeclare(queue: "product.create", durable: true, exclusive: false, autoDelete: false, arguments: null);

        _channel.QueueBind(queue: "product.create", exchange: "product_event", routingKey: "product.create");

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            //var body = ea.Body.ToArray();
            //var message = Encoding.UTF8.GetString(body);
            //var productEvent = JsonConvert.DeserializeObject<CreateProductEvent>(message);
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var routingKey = ea.RoutingKey;
            Console.WriteLine($" [x] Received '{routingKey}':'{message}'");
            //return Task.CompletedTask;

            _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        };

        _channel.BasicConsume(queue: "product.create", autoAck: false, consumer: consumer);
    }
}
