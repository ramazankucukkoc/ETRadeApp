using ETradeApp.Core.RabbitMq;
using ETRadeApp.Business.Abstract;
using ETRadeApp.Business.Concrete;
using ETRadeApp.Core.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ETRadeApp.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddSingleton<RabbitMqSettings>();
            services.AddScoped<ISendMesageFactory, MessageFactory>();
            services.AddScoped<IQueueGetFactory, QueueGetFactoryQuery>();
            return services;
        }
    }
}
