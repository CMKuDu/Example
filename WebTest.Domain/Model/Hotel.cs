using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebTest.Domain.Model
{
    public class Hotel
    {
        public int HotelId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }

        // Quan hệ 1-n với Address
        public ICollection<AddressHotel> AddressHotels { get; set; }

        // Quan hệ 1-n với Service
        public ICollection<Service> Services { get; set; }

        // Quan hệ 1-n với RoomType
        public ICollection<RoomType> RoomTypes { get; set; }
    }
}
