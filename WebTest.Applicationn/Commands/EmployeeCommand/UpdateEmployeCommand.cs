using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.ICommand;

namespace WebTest.Applicationn.Commands.EmployeeCommand
{
    public class UpdateEmployeCommand : ICommand<string>
    {
        public string EmployeeCode { get; set; }
        public EmployeeDTO EmployeeDTO { get; set; }
        public UpdateEmployeCommand(string employeeCode, EmployeeDTO employeeDTO)
        {
            EmployeeCode = employeeCode;
            EmployeeDTO = employeeDTO;
        }
    }
}
