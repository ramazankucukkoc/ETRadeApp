namespace ETRadeApp.Core.RabbitMq
{
    public interface ISendMesageFactory
    {
        void SendMesageAsync(string message);
    }
}
