using Dapper;
using System.Data;
using WebTest.Domain.Common;
using WebTest.Domain.IRepository;
using WebTest.Domain.Model;

namespace WebAPITest.Infastructure.Repository
{
    public class ProductRepository : GenerateRepository<Product>, IProductRepository
    {
        private readonly IDbConnection _dbConnnectDp;
        //private readonly string _connectionString;
        public ProductRepository(ApplicationDbContext _context, IDbConnection dbConnnectDp) : base(_context) 
        {
            _dbConnnectDp = dbConnnectDp;   
        }

        public Task<IEnumerable<Product>> GetAllProduct()
        {
            var query = "Select * from Produt";
            var product = _dbConnnectDp.QueryAsync<Product>(query);
            return product;
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();
            //    var  result = connection.Query<Product>(query);
            //    //return result.ToList();
            //    return Task.FromResult(result.AsEnumerable());
            //}
        }

        public Task<Product> GetByIdProdeuct(int id)
        {
            var query = "Select * from Produt Where Id = @Id";
            var product = _dbConnnectDp.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });
            return product;
        }
    }
}
