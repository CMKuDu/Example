namespace WebTest.Domain.Model
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int RoomId { get; set; }
        public Room Rooms { get; set; }
    }
}
