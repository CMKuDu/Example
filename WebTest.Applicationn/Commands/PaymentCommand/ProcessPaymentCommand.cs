using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.ICommand;

namespace WebTest.Applicationn.Commands.PaymentCommand
{
    public class ProcessPaymentCommand : ICommand<string> 
    {
        public PaymentDTO PaymentDTO { get; set; }
        public ProcessPaymentCommand(PaymentDTO paymentDTO)
        {
            PaymentDTO = paymentDTO;
        }
    }
}
