using Newtonsoft.Json;
using WebTest.Applicationn.IEvent;
using WebTest.Applicationn.Service;

namespace WebTest.Applicationn.Event.ProductEvent
{
    public class ProductEventHandler : IEventHandler<CreateProductEvent>
    {
        private readonly IRabbitMQService _rabbitMQService;
        public ProductEventHandler (IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }
        public Task Handle(CreateProductEvent notification, CancellationToken cancellationToken)
        {
            //var jsonMessage = JsonConvert.SerializeObject(notification);
            _rabbitMQService.Publish(notification, "product_event", "product.create");
            return Task.CompletedTask;
        }
    }
}
