using WebTest.Domain.Model;

namespace WebTest.Domain.IRepository
{
    public interface IOrderRepository : IGenerateRepositoy<Order>
    {
        Task<IEnumerable<Order>> GetAllOrder();
        Task<Order> GetByIdOrder(int id);
    }
}
