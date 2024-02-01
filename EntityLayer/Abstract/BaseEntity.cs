namespace EntityLayer.Abstract
{
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity() 
        {
            CreationDate = DateTime.Now;
        }
        public DateTime CreationDate { get; init; }
    }
}
