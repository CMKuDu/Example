using AutoMapper;
using WebAPITest.Infastructure.UnitOfWork;
using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.IQueries;
using WebTest.Domain.IRepository;

namespace WebTest.Applicationn.Query.QueryProduct
{
    public class ProductQueryHandler : IQueryHandler<GetAllProductQuery, IEnumerable<ProductDTO>>,
                                        IQueryHandler<GetByIdProductQuery, ProductDTO>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductQueryHandler(IProductRepository productRepository,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = productRepository;    
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllProduct();

            var productDTOs = products.Select(p => new ProductDTO
            {
                //Description = p.Id,
                Name = p.Name,
                Description = p.Description,
                CategoryId = p.CategoryId
            }).ToList();

            return productDTOs;
        }

        public async Task<ProductDTO> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)

        {
            var result = await _repository.GetByIdProdeuct(request.ProductId);
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            var productDto = new ProductDTO
            {
                Name = result.Name,
                Description = result.Description,
            };
            
            return productDto;

        }
    }
}
