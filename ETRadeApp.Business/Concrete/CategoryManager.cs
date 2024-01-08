using ETRadeApp.Business.Abstract;
using ETRadeApp.Core.RabbitMq;
using ETRadeApp.DataAccess.Context;
using ETRadeApp.Entities;
using Newtonsoft.Json;

namespace ETRadeApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly MsSqlDbContext msSqlDbContext;
        private readonly ISendMesageFactory _sendMesageFactory;
        private readonly IQueueGetFactory _queueGetFactory;
        public CategoryManager(MsSqlDbContext msSqlDbContext, ISendMesageFactory sendMesageFactory, IQueueGetFactory queueGetFactory)
        {
            _queueGetFactory = queueGetFactory;
            _sendMesageFactory = sendMesageFactory;
            this.msSqlDbContext = msSqlDbContext;
        }
        public  void Add(Category category)
        {
            var categoryJson = JsonConvert.SerializeObject(category);
            Message message = new Message();
            message.Content = categoryJson;
            message.Name = category.Name;
             _sendMesageFactory.SendMesageAsync(categoryJson);
            msSqlDbContext.Messages.Add(message);
            msSqlDbContext.SaveChanges();
        }
        public async Task ConsumerAdd()
        {
            var message = await _queueGetFactory.GetQueue();         
            var categoryQueue = JsonConvert.DeserializeObject<Category>(message);
            msSqlDbContext.Categories.Add(categoryQueue);
            msSqlDbContext.SaveChanges();
        }
    }
}
