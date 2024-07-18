using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Models;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderDbContext:DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> option):base(option)
        {
                
        }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            await OrderContextSeed.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Order>Orders { get; set; }
    }
}
