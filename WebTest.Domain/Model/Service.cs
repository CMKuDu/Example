using System.ComponentModel.DataAnnotations;

namespace WebTest.Domain.Model
{
    public class Service
    {
        public int ServiceId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ServiceName { get; set; }
        public string Description { get; set; }
        
        public string ThumbOfficial1 {  get; set; } = string.Empty;
        public string ThumbOfficial2 {  get; set; } = string.Empty;
        public string ThumbOfficial3 {  get; set; } = string.Empty;
        public string ThumbOfficial4 {  get; set; } = string.Empty;
        public string ThumbOfficial5 {  get; set; } = string.Empty;

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        //public ICollection<SubService> SubServices { get; set; }
    }

}
