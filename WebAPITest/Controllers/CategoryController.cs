using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebTest.Applicationn.Commands.GategoryCommand;
using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.Query.QuereyCategory;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                throw new ArgumentNullException(nameof(categoryDTO));
            }
            var command = new CreateCategoryCommand(categoryDTO);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _mediator.Send(new GetAllCategoryQuery());
            if(result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            return Ok(result);
        }
    }
}
