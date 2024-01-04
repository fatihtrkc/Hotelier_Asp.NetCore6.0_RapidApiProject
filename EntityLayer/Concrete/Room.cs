using EntityLayer.Abstract;
using EntityLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Room : BaseEntity
    {
        [Key]
        public string No { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public RoomType Type { get; set; }
        public decimal Price { get; set; }
    }
}
