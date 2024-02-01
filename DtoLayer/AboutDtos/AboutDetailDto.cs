namespace DtoLayer.AboutDtos
{
    public class AboutDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int RoomCount { get; set; }
        public int EmployeeCount { get; set; }
        public int CustomerCount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
