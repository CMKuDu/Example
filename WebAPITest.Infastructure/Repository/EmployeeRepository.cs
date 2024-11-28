using Dapper;
using System.Data;
using WebTest.Domain.Common;
using WebTest.Domain.IRepository;
using WebTest.Domain.Model;

namespace WebAPITest.Infastructure.Repository
{
    public class EmployeeRepository : GenerateRepository<Employee>, IEmployeeRepository
    {
        private readonly IDbConnection _dbConnection;

        public EmployeeRepository(ApplicationDbContext context , IDbConnection dbConnection) : base(context) { _dbConnection = dbConnection; }

        public async Task<IEnumerable<Employee>> GetAllAsyncEmployee(int page, int pageSize)
        {
            var offSet = (page - 1 ) * pageSize;
            var query = "SELECT * FROM Employees ORDER BY EmployeeCode OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var empolyees = await _dbConnection.QueryAsync<Employee>(query, new { Offset = offSet, PageSize = pageSize });
            return empolyees;
        }

        public async Task<Employee> GetByCodeAsync(string employeeCode)
        {
            var query = "SELECT * FROM Employees WHERE EmployeeCode = @EmployeeCode";
            var result = await _dbConnection.QueryFirstOrDefaultAsync<Employee>(query, new { EmployeeCode = employeeCode });
            return result;
        }
    }
}
