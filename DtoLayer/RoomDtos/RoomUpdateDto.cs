using EntityLayer.Enums;

namespace DtoLayer.RoomDtos
{
    public class RoomUpdateDto
    {
        public string No { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public RoomType Type { get; set; }
        public decimal Price { get; set; }
    }
}
