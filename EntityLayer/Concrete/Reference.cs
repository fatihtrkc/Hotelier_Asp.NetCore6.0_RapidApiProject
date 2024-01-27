using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Reference : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Comment { get; set; }
    }
}
