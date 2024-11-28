using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.ICommand;

namespace WebTest.Applicationn.Commands.EmployeeCommand
{
    public class CreateEmployeCommand : ICommand<string>
    {
        public EmployeeDTO EmployeeDTO { get; set; }
        public CreateEmployeCommand(EmployeeDTO employeeDTO)
        {
            EmployeeDTO = employeeDTO;
        }
    }
}
