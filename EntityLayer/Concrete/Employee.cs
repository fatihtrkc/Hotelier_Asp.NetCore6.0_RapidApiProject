using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Employee : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
    }
}
