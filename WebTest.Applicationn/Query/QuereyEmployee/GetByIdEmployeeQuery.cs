using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.IQueries;

namespace WebTest.Applicationn.Query.QuereyEmployee
{
    public class GetByIdEmployeeQuery : IQuery<EmployeeDTO>
    {
        public string EmployeeCode { get; set; } 

        public GetByIdEmployeeQuery(string employeeCode)
        {
            EmployeeCode = employeeCode;
        }
    }
}
