using WebTest.Domain.Common;
using WebTest.Domain.IRepository;

namespace WebAPITest.Infastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository _uProduct { get; private set; }
        public IOrderRepository _orderRepository { get; private set; }
        public IEmployeeRepository _employeeRepository { get; private set; }

        //public IProductRepository uProduct => throw new NotImplementedException()/*;*/

        public UnitOfWork(ApplicationDbContext context,
            IProductRepository uProduct,
            IOrderRepository orderRepository,
            IEmployeeRepository employeeRepository)
        {
            _context = context;
            _uProduct = uProduct;
            _orderRepository = orderRepository;
            _employeeRepository = employeeRepository;
        }
        public int Compele()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool dispose)
        {
            if (dispose)
            {
                _context.Dispose();
            }
        }
    }
}
