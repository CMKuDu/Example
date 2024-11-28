using WebTest.Applicationn.IEvent;
using WebTest.Applicationn.Service;

namespace WebTest.Applicationn.Event.OrderEvent
{
    public class OrderEventHandler : IEventHandler<CreateOrderEvent>
    {
        private readonly IRabbitMQService _rabbitmqService;
        public OrderEventHandler(IRabbitMQService rabbitmqService)
        {
            _rabbitmqService = rabbitmqService;
        }

        public Task Handle(CreateOrderEvent notification, CancellationToken cancellationToken)
        {
            _rabbitmqService.Publish(notification, "order_create", "order.event");
            return Task.CompletedTask;
        }
    }
}
