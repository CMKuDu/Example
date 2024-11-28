using Dapper;
using RabbitMQ.Client;
using System.Data;
using WebTest.Domain.Common;
using WebTest.Domain.IRepository;
using WebTest.Domain.Model;

namespace WebAPITest.Infastructure.Repository
{
    public class CategoryRepository : GenerateRepository<Category>, ICategoryRepository
    {
        private readonly IDbConnection _connection;
        public CategoryRepository(ApplicationDbContext _context, IDbConnection connection): base(_context) 
        {
            _connection = connection;
        }

        public Task<IEnumerable<Category>> GetAllCategory()
        {
            var query = "SELECT * FROM Categories";
            var dapper = _connection.QueryAsync<Category>(query);
            return dapper;
        }

        public Task<Category> GetByIdCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
