using AutoMapper;
using WebAPITest.Infastructure.UnitOfWork;
using WebTest.Applicationn.Event.ProductEvent;
using WebTest.Applicationn.ICommand;
using WebTest.Applicationn.IEvent;
using WebTest.Domain.IRepository;
using WebTest.Domain.Model;

namespace WebTest.Applicationn.Commands.ProductCommand
{
    public class ProductCommandHandler : ICommandHandler<CreateProductCommand, string>,
                                        ICommandHandler<UpdateProductCommand, string>,
                                        ICommandHandler<RemoveProductCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEventHandler<CreateProductEvent> _eventHandler;
        public ProductCommandHandler(IProductRepository productRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IEventHandler<CreateProductEvent> eventHandler)
        {
            _eventHandler = eventHandler;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.ProductDTO.Name,
                Description = request.ProductDTO.Description,
                CategoryId = request.ProductDTO.CategoryId 
            };

            //var productdto = _mapper.Map<Product>(request.ProductDTO);

            await _productRepository.Add(product);

            var productNotify = new CreateProductEvent(request.ProductDTO);
            await _eventHandler.Handle(productNotify, cancellationToken);    //public or send

            _unitOfWork.Compele();
            return product.Id.ToString();
        }

        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {   
            var product = new Product
            {
                Name = request.ProductDTO.Name,
                Description = request.ProductDTO.Description,
            };
            await _productRepository.Update(product);
            _unitOfWork.Compele();
            return product.Id.ToString();
        }

        public async Task<string> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = request.ProductId
            };
            var result = await _productRepository.GetById(product.Id);
            await _productRepository.Delete(result);
            return result.Id.ToString();
        }
    }
}
