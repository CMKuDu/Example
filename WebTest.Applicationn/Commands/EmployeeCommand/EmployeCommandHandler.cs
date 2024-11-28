using WebAPITest.Infastructure.UnitOfWork;
using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.ICommand;
using WebTest.Domain.IRepository;
using WebTest.Domain.Model;

namespace WebTest.Applicationn.Commands.EmployeeCommand
{
    public class EmployeCommandHandler : ICommandHandler<CreateEmployeCommand, string>,
                                        ICommandHandler<RemoveEmployeCommand, string>,
                                        ICommandHandler<UpdateEmployeCommand, string>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(CreateEmployeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.EmployeeDTO == null)
                    throw new ArgumentNullException(nameof(request.EmployeeDTO));

                var employee = new Employee
                {
                    EmployeeCode = $"NV_{DateTime.Now:yyyy_MM_dd}_{Guid.NewGuid().ToString().Substring(0, 4)}",
                    FullName = request.EmployeeDTO.FullName,
                    DateOfBirth = request.EmployeeDTO.DateOfBirth,
                    Position = request.EmployeeDTO.Position
                };

                await _employeeRepository.Add(employee);  
                 _unitOfWork.Compele();

                return employee.EmployeeCode;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error creating employee: " + ex.Message, ex);
            }
        }


        public async Task<string> Handle(RemoveEmployeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByCodeAsync(request.EmployeeCode);

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee not found.");
            }

            await _employeeRepository.Delete(employee);

            _unitOfWork.Compele();

            return employee.EmployeeCode;
        }

        public async Task<string> Handle(UpdateEmployeCommand request, CancellationToken cancellationToken)
        {
            //var employeeDTO = request.;
            var employee = await _employeeRepository.GetByCodeAsync(request.EmployeeCode);
            if (employee == null)
            {
                return "Employee not found";  
            }

            employee.FullName = request.EmployeeDTO.FullName;
            employee.DateOfBirth = request.EmployeeDTO.DateOfBirth;
            employee.Position = request.EmployeeDTO.Position;
            await _employeeRepository.Update(employee);
            _unitOfWork.Compele();
            return "Employee updated successfully";
        }
    }
}
