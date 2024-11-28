namespace WebTest.Domain.Model
{
    public class RoomType
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string RoomThumb1 { get; set; }
        public string RoomThumb2 { get; set; }
        public string RoomThumb3 { get; set; }
        public string RoomThumb4 { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int TotalRooms { get; set; }
        public ICollection<Room> Rooms { get; set; }
        //public ICollection<RoomTypeBedType> RoomTypeBedTypes { get; set; }

        public PriceType PriceTypes { get; set; }
    }
}
