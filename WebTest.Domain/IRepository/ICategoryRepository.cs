using WebTest.Domain.Model;

namespace WebTest.Domain.IRepository
{
    public interface ICategoryRepository : IGenerateRepositoy<Category>
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetByIdCategory(int id);
    }
}
