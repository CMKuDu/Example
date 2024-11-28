using Dapper;
using System.Data;
using WebTest.Domain.Common;
using WebTest.Domain.IRepository;
using WebTest.Domain.Model;

namespace WebAPITest.Infastructure.Repository
{
    public class PaymentRepository : GenerateRepository<Payment>, IPaymentRepository
    {
        private readonly IDbConnection _connection;
        public PaymentRepository(ApplicationDbContext context, IDbConnection connection) : base(context) { _connection = connection; }


        public Task<IEnumerable<Payment>> GetAllPayment()
        {
            var query = "SELECT * FROM Payment";
            var dapper = _connection.QueryAsync<Payment>(query);
            return dapper;
        }

        public Task<Payment> GetByIdPayment(string id)
        {
            var query = "SELECT * FROM Payment where Id = @Id";
            var dapper = _connection.QuerySingleOrDefaultAsync<Payment>(query, new {Id = id});
            return dapper;
        }
    }
}
