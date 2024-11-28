namespace WebTest.Applicationn.Service
{
    public interface IRabbitMQService
    {
        void Publish<T>(T message, string exchange, string routingKey) where T : class;
    }
}
