using WebTest.Domain.Model;

namespace WebTest.Domain.IRepository
{
    public interface IProductRepository : IGenerateRepositoy<Product>
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetByIdProdeuct(int id);
    }
}
