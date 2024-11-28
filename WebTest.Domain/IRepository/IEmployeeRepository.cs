using WebTest.Domain.Model;

namespace WebTest.Domain.IRepository
{
    public interface IEmployeeRepository : IGenerateRepositoy<Employee>
    {
        Task<Employee> GetByCodeAsync(string employeeCode);
        Task<IEnumerable<Employee>> GetAllAsyncEmployee(int page, int pageSize);
    }
}
