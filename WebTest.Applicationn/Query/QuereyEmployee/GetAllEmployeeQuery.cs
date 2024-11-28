using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.IQueries;

namespace WebTest.Applicationn.Query.QuereyEmployee
{
    public class GetAllEmployeeQuery : IQuery<IEnumerable<EmployeeDTO>>
    {
        public int Page { get; set; }  
        public int PageSize { get; set; } 

        public GetAllEmployeeQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
