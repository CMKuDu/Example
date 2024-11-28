using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.IQueries;

namespace WebTest.Applicationn.Query.QueryPayment
{
    public class GetByIdPayment : IQuery<PaymentDTO>
    {
        public string PaymentId { get; set; }
        public GetByIdPayment(string id ) { PaymentId = id;  }
    }
}
