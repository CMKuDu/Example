using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.IQueries;

namespace WebTest.Applicationn.Query.QueryProduct
{
    public class GetByIdProductQuery : IQuery<ProductDTO>
    {
        public int ProductId { get; set; }
        public GetByIdProductQuery(int id) { ProductId = id; }
    }
}
