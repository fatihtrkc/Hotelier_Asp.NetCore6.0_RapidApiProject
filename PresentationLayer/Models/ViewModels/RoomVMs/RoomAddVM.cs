using EntityLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models.ViewModels.RoomVMs
{
    public class RoomAddVM
    {
        [Required(ErrorMessage = "Please enter room no !")]
        public string No { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public RoomType Type { get; set; }
        public decimal Price { get; set; }
    }
}
