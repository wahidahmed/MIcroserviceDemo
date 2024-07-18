using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contacts.Persistance;
using Ordering.Domain.Models;
using Ordering.Infrastructure.Persistance; 


namespace Ordering.Infrastructure.Repository
{
    public class OrderRepository : CommonRepository<Order>, IOrderRepository
    {
        OrderDbContext _dbContext;
        public OrderRepository(OrderDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string username)
        {
            var orderList=await _dbContext.Orders.Where(x=>x.UserName.ToLower() == username.ToLower()).ToListAsync();
            return orderList;
        }
    }
}
