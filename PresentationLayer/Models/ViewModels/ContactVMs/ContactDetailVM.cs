namespace PresentationLayer.Models.ViewModels.ContactVMs
{
    public class ContactDetailVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
