using ClothingShoping.Data;
namespace ClothingShoping.Repository

{
    public interface IUnitOfWork
    {

        public void Commit();
    }
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext DbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
