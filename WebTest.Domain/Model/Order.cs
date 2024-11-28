namespace WebTest.Domain.Model
{
    public class Order
    {
        public string? Id { get; set; }
        public int ProductId { get; set; } 
        public int Quantity { get; set; } 
        public string CustomerId { get; set; } 
        public decimal TotalAmount { get; set; }
        //public Address ShippingAddress {  get; private set; }

        //public void UpdateAddress (Address newAddress)
        //{
        //    ShippingAddress = newAddress;
        //}
    }
    //public record Address
    //{
    //    public string Street { get; }
    //    public string City { get; }
    //    public string Country { get; }
    //    public Address(string street, string city, string country) 
    //    { Street = street; City = city; Country = country; }
    //}

}
