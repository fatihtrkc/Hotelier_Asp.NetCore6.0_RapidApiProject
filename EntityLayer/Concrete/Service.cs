using EntityLayer.Abstract;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Service : BaseEntity
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
