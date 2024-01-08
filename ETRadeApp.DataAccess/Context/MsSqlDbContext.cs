using ETRadeApp.Core.RabbitMq;
using ETRadeApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ETRadeApp.DataAccess.Context
{
    public class MsSqlDbContext : DbContext
    {
        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
