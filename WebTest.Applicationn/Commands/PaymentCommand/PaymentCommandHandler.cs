using WebAPITest.Infastructure.UnitOfWork;
using WebTest.Applicationn.ICommand;
using WebTest.Domain.IRepository;
using WebTest.Domain.Model;

namespace WebTest.Applicationn.Commands.PaymentCommand
{
    public class PaymentCommandHandler : ICommandHandler<ProcessPaymentCommand, string>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentCommandHandler(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _paymentRepository = paymentRepository;
        }
        public async Task<string> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new Payment
            {
                Id = Guid.NewGuid().ToString(),
                OrderId = Guid.NewGuid().ToString(),
                Amount = request.PaymentDTO.Amount,
                PaymentMethod = request.PaymentDTO.PaymentMethod,
                IsSuccess = request.PaymentDTO.IsSuccess
            };

            await _paymentRepository.Add(payment);
            _unitOfWork.Compele(); 
            return payment.Id;
        }
    }
}
