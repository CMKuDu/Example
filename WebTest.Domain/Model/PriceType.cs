using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTest.Domain.Model
{
    public class PriceType
    {
        [Key, ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // Quan hệ 1-1 với RoomType
        public RoomType RoomType { get; set; }
    }
}
