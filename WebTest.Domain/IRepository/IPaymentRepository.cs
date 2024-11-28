using WebTest.Domain.Model;

namespace WebTest.Domain.IRepository
{
    public interface IPaymentRepository : IGenerateRepositoy<Payment>
    {
        Task<IEnumerable<Payment>> GetAllPayment();
        Task<Payment> GetByIdPayment(string id);
    }
}
