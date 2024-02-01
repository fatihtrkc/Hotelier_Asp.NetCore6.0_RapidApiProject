using EntityLayer.Enums;

namespace PresentationLayer.Models.ViewModels.BookingVMs
{
    public class BookingUpdateVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public RoomType RoomType { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public string? Request { get; set; }
        public DateTime ChechIn { get; set; }
        public DateTime ChechOut { get; set; }
        public Status Status { get; set; }
    }
}
