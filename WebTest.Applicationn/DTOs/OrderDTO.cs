namespace WebTest.Applicationn.DTOs
{
    public class OrderDTO
    {
        public string? Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string CustomerId { get; set; }
        public decimal TotalAmount {get; set; }
        //public AddressDTO ShippingAddress { get; set; }
    }
}
