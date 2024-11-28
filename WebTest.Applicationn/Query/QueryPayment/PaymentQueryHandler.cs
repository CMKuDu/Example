using MediatR;
using WebAPITest.Infastructure.UnitOfWork;
using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.IQueries;
using WebTest.Domain.IRepository;

namespace WebTest.Applicationn.Query.QueryPayment
{
    public class PaymentQueryHandler : IQueryHandler<GetAllPayment, IEnumerable<PaymentDTO>>,
                                       IQueryHandler<GetByIdPayment, PaymentDTO>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentQueryHandler(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
        {_paymentRepository = paymentRepository; _unitOfWork = unitOfWork; }

        public async Task<IEnumerable<PaymentDTO>> Handle(GetAllPayment request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetAllPayment();
            var paymentDTO = payment.Select(x => new PaymentDTO
            {
                Amount = x.Amount,
                OrderId = x.OrderId,
                IsSuccess = x.IsSuccess,
                PaymentMethod = x.PaymentMethod,
            }).ToList();
            return paymentDTO;
        }

        public async Task<PaymentDTO> Handle(GetByIdPayment request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetByIdPayment(request.PaymentId);
            if(payment == null) {throw new ArgumentNullException(nameof(payment));}
            var paymentDTO = new PaymentDTO
            {
                Amount= payment.Amount,
                OrderId = payment.OrderId,
                IsSuccess= payment.IsSuccess,
                PaymentMethod = payment.PaymentMethod,
            };
            return paymentDTO;
        }
    }
}
