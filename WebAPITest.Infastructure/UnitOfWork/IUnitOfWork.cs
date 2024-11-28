using WebTest.Domain.IRepository;

namespace WebAPITest.Infastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository _uProduct { get; }
        IOrderRepository _orderRepository { get; }
        IEmployeeRepository _employeeRepository { get; }
        int Compele();
    }
}
