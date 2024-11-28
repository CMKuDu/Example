namespace WebTest.Domain.Model
{
    public class AddressHotel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string DeatailAddress { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
