using ETRadeApp.Core.RabbitMq;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ETradeApp.Core.RabbitMq
{
    public class QueueGetFactoryQuery : IQueueGetFactory
    {
        private readonly IConfiguration _configuration;
        private readonly RabbitMqSettings _rabbitMqSettings;
        private readonly ConnectionFactory _factory;

        public QueueGetFactoryQuery(IConfiguration configuration)
        {
            _configuration = configuration;
            _rabbitMqSettings = _configuration.GetSection("RabbitMqSettings").Get<RabbitMqSettings>();
            _factory = new ConnectionFactory
            {
                HostName = _rabbitMqSettings.HostName,
                Port = _rabbitMqSettings.Port,
                UserName = _rabbitMqSettings.UserName,
                Password = _rabbitMqSettings.Password,
            };
        }

        public async Task<string> GetQueue()
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "ETradeApp", durable: false, exclusive: false, autoDelete: false);

            var tcs = new TaskCompletionSource<string>();
            bool isCompleted = false;
            var queueDeclareOk = channel.QueueDeclarePassive("ETradeApp");
            var messageCount = queueDeclareOk.MessageCount;
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    string receivedMessage = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"Mesaj alındı: {receivedMessage}");

                    if (!isCompleted)
                    {
                        tcs.SetResult(receivedMessage);
                        isCompleted = true;
                        channel.BasicAck(ea.DeliveryTag, multiple: false);
                    }
                }
                catch (Exception ex)
                {
                    if (!isCompleted)
                    {
                        tcs.SetException(ex);
                        isCompleted = true;
                    }
                }
            };
            channel.BasicConsume(queue: "ETradeApp", autoAck: false, consumer: consumer);
            try
            {
                // Mesaj alındığında veya hata oluştuğunda tamamlanacak TaskCompletionSource'un task'ini bekleyin
                return await tcs.Task;
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama yapabilir veya hata mesajını işleyebilirsiniz.
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                throw;
            }
        }
    }
}
