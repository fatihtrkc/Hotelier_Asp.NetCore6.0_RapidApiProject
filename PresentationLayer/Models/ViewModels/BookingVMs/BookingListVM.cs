using EntityLayer.Enums;

namespace PresentationLayer.Models.ViewModels.BookingVMs
{
    public class BookingListVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public RoomType RoomType { get; set; }
        public DateTime ChechIn { get; set; }
        public DateTime ChechOut { get; set; }
        public Status Status { get; set; }
    }
}
