using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole() 
        {
            CreationDate = DateTime.Now;
        }

        public DateTime CreationDate { get; init; }
    }
}
