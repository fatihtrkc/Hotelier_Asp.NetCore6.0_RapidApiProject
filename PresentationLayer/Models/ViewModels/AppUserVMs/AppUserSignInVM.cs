using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models.ViewModels.AppUserVMs
{
    public class AppUserSignInVM
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
