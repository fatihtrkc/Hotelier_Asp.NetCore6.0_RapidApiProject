using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Subscribe : BaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
