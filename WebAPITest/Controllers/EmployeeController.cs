using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebTest.Applicationn.Commands.EmployeeCommand;
using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.Query.QuereyEmployee;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllEmployeeQuery(page, pageSize);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{employeeCode}")]
        public async Task<IActionResult> GetEmployeeByCode(string employeeCode)
        {
            var query = new GetByIdEmployeeQuery(employeeCode);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound($"Employee with code {employeeCode} not found.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            var command = new CreateEmployeCommand(employeeDTO);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{employeeCode}")]
        public async Task<IActionResult> UpdateEmployee(string employeeCode, [FromBody] EmployeeDTO employeeDTO)
        {
            var command = new UpdateEmployeCommand(employeeCode, employeeDTO);
            var result = await _mediator.Send(command);

            if (string.IsNullOrEmpty(result))
            {
                return NotFound($"Employee with code {employeeCode} not found.");
            }

            return Ok(result);
        }

        [HttpDelete("{employeeCode}")]
        public async Task<IActionResult> DeleteEmployee(string employeeCode)
        {
            var command = new RemoveEmployeCommand(employeeCode);
            var result = await _mediator.Send(command);

            if (string.IsNullOrEmpty(result))
            {
                return NotFound($"Employee with code {employeeCode} not found.");
            }

            return Ok(result);
        }
    }
}
