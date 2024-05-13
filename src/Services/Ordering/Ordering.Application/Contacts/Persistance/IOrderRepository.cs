using EF.Core.Repository.Interface.Repository;
using Ordering.Domain.Models;

namespace Ordering.Application.Contacts.Persistance
{
    public interface IOrderRepository:ICommonRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string username);
    }
}
