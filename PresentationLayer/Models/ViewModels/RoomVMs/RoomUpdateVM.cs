using EntityLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models.ViewModels.RoomVMs
{
    public class RoomUpdateVM
    {
        public string No { get; set; }
        public string Title { get; set; }
        [MinLength(10), MaxLength(100)]
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public RoomType Type { get; set; }
        public decimal Price { get; set; }
    }
}
