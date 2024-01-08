using ETRadeApp.DataAccess.Abstract;
using ETRadeApp.DataAccess.Concrete;
using ETRadeApp.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETRadeApp.DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddDbContext<MsSqlDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            });
            return services;
        }
    }
}
