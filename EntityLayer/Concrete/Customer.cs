using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Customer : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
    }
}
