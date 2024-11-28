using WebAPITest.Infastructure.Repository;
using WebAPITest.Infastructure.UnitOfWork;
using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.IQueries;
using WebTest.Domain.IRepository;

namespace WebTest.Applicationn.Query.QuereyEmployee
{
    public class EmployeeQueryHandler : IQueryHandler<GetAllEmployeeQuery, IEnumerable<EmployeeDTO>>,
                                        IQueryHandler<GetByIdEmployeeQuery, EmployeeDTO>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeQueryHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EmployeeDTO>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsyncEmployee(request.Page, request.PageSize);

            // Chuyển đổi từ Entity sang DTO
            var employeeDTOs = new List<EmployeeDTO>();
            foreach (var employee in employees)
            {
                employeeDTOs.Add(new EmployeeDTO
                {
                    EmployeeCode = employee.EmployeeCode,
                    FullName = employee.FullName,
                    DateOfBirth = employee.DateOfBirth,
                    Position = employee.Position
                });
            }

            return employeeDTOs;

        }

        public async Task<EmployeeDTO> Handle(GetByIdEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByCodeAsync(request.EmployeeCode);

            if (employee == null)
            {
                return null;
            }

            var employeeDTO = new EmployeeDTO
            {
                EmployeeCode = employee.EmployeeCode,
                FullName = employee.FullName,
                DateOfBirth = employee.DateOfBirth,
                Position = employee.Position
            };

            return employeeDTO;
        }
    }
}
