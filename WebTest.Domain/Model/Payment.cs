namespace WebTest.Domain.Model
{
    public class Payment
    {
        public string Id { get; set; } 
        public string OrderId { get; set; } 
        public decimal Amount { get; set; } 
        public string PaymentMethod { get; set; } 
        public bool IsSuccess { get; set; } 
    }

}
