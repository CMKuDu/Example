using Dapper;
using System.Data;
using WebTest.Domain.Common;
using WebTest.Domain.IRepository;
using WebTest.Domain.Model;

namespace WebAPITest.Infastructure.Repository
{
    public class OrderRepository : GenerateRepository<Order>, IOrderRepository
    {
        private readonly IDbConnection _dbConnnectDp;
        public OrderRepository(ApplicationDbContext context, IDbConnection dbConnnectDp) : base(context) { _dbConnnectDp = dbConnnectDp; }

        public Task<IEnumerable<Order>> GetAllOrder()
        {
            var query = "Select * from Produt";
            var product = _dbConnnectDp.QueryAsync<Order>(query);
            return product;
        }

        public Task<Order> GetByIdOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
