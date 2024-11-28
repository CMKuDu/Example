using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTest.Applicationn.Commands.OrderCommand;
using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.Query.QueryOrder;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDTO orderDto)
        {
            if(orderDto == null)
            {
                throw new ArgumentNullException(nameof(orderDto));
            }
            var command = new CreateOrderCommand(orderDto);
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var result = await mediator.Send(new GetAllOrderQuery());
            if(result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            return Ok(result);
        }
    }
}
