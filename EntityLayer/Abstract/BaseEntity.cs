namespace EntityLayer.Abstract
{
    public class BaseEntity
    {
        public BaseEntity() 
        {
            CreationDate = DateTime.Now;
        }
        public DateTime CreationDate { get; set; }
    }
}
