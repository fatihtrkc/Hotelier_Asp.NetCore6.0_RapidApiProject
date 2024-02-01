using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class About : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CustomerCount { get; set; }
        public int EmployeeCount { get; set; }
        public int RoomCount { get; set; }
    }
}
