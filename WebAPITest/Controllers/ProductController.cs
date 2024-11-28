using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebTest.Applicationn.Commands.ProductCommand;
using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.Query.QueryProduct;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                throw new ArgumentNullException(nameof(productDTO));
            }
            var command = new CreateProductCommand(productDTO);
                var result = await _mediator.Send(command);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductDTO productDto)
        {
            if(productId == null)
            {
                throw new ArgumentNullException(nameof(productId));
            }
            if (string.IsNullOrEmpty(productDto.Name))
            {
                return BadRequest("Name is not null");
            }
            var command = new UpdateProductCommand(productDto);
            var result = _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _mediator.Send(new GetAllProductQuery());
            if(result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var result = await _mediator.Send(new GetByIdProductQuery(id));
           return Ok(result);
        }
    }
}
