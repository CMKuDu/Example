using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.ICommand;

namespace WebTest.Applicationn.Commands.EmployeeCommand
{
    public class RemoveEmployeCommand : ICommand<string>
    {
        public string EmployeeCode { get; set; }
        public RemoveEmployeCommand(string employeeCode)
        {
            EmployeeCode = employeeCode;
        }
    }
}
    