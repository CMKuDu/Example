namespace WebTest.Applicationn.DTOs
{
    public class PaymentDTO
    {

        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsSuccess { get; set; }
    }
}
