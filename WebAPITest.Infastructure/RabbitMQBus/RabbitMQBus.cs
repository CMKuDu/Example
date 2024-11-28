using RabbitMQ.Client;

namespace WebAPITest.Infastructure.RabbitMQBus
{
    public class RabbitMQBus : IRabbitMQBus, IDisposable
    {
        private IConnection? _connection;
        public IConnection Connection => _connection!;

        public RabbitMQBus()
        {
            InitializeConnectionAsync().Wait();
        }

        private async Task InitializeConnectionAsync()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/"
            };

            _connection = factory.CreateConnection();
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
