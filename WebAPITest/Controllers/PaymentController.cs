using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebTest.Applicationn.Query.QueryPayment;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator) { _mediator = mediator; }
        [HttpGet]
        public async Task<IActionResult> GetAllPayment()
        {
            var result = await _mediator.Send(new GetAllPayment());
            if (result == null) { throw new ArgumentNullException(nameof(result)); }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var result = await _mediator.Send(new GetByIdPayment(id));
            if (result == null) { return NotFound(); }
            return Ok(result);
        }
    }
}
