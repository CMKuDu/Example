namespace WebTest.Domain.Model
{
    public class Room
    {
        public int RoomId { get; set; }
        public string BedName { get; set; }

        public string IsVancant {  get; set; }
        public ICollection<Booking> Bookings {  get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }


    }
}
