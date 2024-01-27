using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser() 
        {
            CreationDate = DateTime.Now;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; init; }
    }
}
