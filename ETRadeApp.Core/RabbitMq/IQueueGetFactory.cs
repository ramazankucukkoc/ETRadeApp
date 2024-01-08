namespace ETRadeApp.Core.RabbitMq
{
    public interface IQueueGetFactory
    {
        Task<string> GetQueue();
    }
}
