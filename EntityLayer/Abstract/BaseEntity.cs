namespace EntityLayer.Abstract
{
    public abstract class BaseEntity : IBaseEntity
    {
        public BaseEntity() 
        {
            CreationDate = DateTime.Now;
        }
        public DateTime CreationDate { get; init; }
    }
}
