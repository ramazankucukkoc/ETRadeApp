using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;

namespace ETRadeApp.Core.RabbitMq
{
    public class MessageFactory : ISendMesageFactory
    {
        private readonly IConfiguration Configuration;
        private readonly RabbitMqSettings _rabbitMqSettings;
        private readonly ConnectionFactory _factory;

        public MessageFactory(IConfiguration configuration)
        {
            Configuration = configuration;
            _rabbitMqSettings = Configuration.GetSection("RabbitMqSettings").Get<RabbitMqSettings>();
            _factory = new ConnectionFactory
            {
                HostName = _rabbitMqSettings.HostName,
                Port = _rabbitMqSettings.Port,
                UserName = _rabbitMqSettings.UserName,
                Password = _rabbitMqSettings.Password,
            };
        }
        public void SendMesageAsync(string message)
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "ETradeApp",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "ETradeApp",
                                 basicProperties: properties,
                                 body: body);
        }
    }
}
