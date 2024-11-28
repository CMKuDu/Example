using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using WebAPITest.Infastructure.RabbitMQBus;
using WebTest.Applicationn.Commands.PaymentCommand;
using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.Event.OrderEvent;
using WebTest.Applicationn.ICommand;

namespace WebTest.Applicationn.Service
{
    public class PaymentConsumer : BackgroundService
    {
        private readonly ILogger<PaymentConsumer> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IRabbitMQBus _rabbitMQBus;
        private IModel _channel;
        private readonly string _exchangeName = "order_create"; 
        private readonly string _queueName = "order.event";
        private readonly string _routingKey = "order.event";

        public PaymentConsumer(ILogger<PaymentConsumer> logger, IServiceProvider serviceProvider, IRabbitMQBus rabbitMQBus)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _rabbitMQBus = rabbitMQBus;

            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {
            _channel = _rabbitMQBus.Connection.CreateModel();

            _channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Topic, durable: true, autoDelete: false);
            _channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queue: _queueName, exchange: _exchangeName, routingKey: _routingKey);

            _logger.LogInformation("PaymentConsumer connected to RabbitMQ and bound to exchange and queue.");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                _logger.LogInformation($"Received message: {message}");

                try
                {
                    var orderEvent = JsonConvert.DeserializeObject<CreateOrderEvent>(message);
                    if (orderEvent != null)
                    {
                        await HandleMessageAsync(orderEvent);
                    }

                    _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing message.");

                    _channel.BasicNack(deliveryTag: ea.DeliveryTag, multiple: false, requeue: false);
                }
            };

            _channel.BasicConsume(queue: _queueName, autoAck: false, consumer: consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessageAsync(CreateOrderEvent orderEvent)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var commandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<ProcessPaymentCommand, string>>();

                var paymentDTO = new PaymentDTO
                {
                    OrderId = orderEvent.OrderDTO.Id,
                    Amount = orderEvent.OrderDTO.TotalAmount,
                    PaymentMethod = "CreditCard",
                    IsSuccess = true
                };

                var paymentCommand = new ProcessPaymentCommand(paymentDTO);
                var result = await commandHandler.Handle(paymentCommand, CancellationToken.None);

                _logger.LogInformation($"Payment processed with ID: {result}");

            }
        }

        public override void Dispose()
        {
            _channel?.Close();
            _rabbitMQBus.Connection?.Close();
            base.Dispose();
        }
    }
}
