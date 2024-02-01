using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models.ViewModels.SubscribeVMs
{
    public class SubscribeAddVM
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
