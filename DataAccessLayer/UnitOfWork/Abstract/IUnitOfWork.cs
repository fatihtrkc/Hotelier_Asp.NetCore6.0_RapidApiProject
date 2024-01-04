namespace DataAccessLayer.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
