using System.Linq;

namespace SimpleTemplate_1.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
