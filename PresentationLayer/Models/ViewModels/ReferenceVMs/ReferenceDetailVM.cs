namespace PresentationLayer.Models.ViewModels.ReferenceVMs
{
    public class ReferenceDetailVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public IFormFile Image { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
