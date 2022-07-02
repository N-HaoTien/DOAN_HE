using ClothingShoping.Data;
using ClothingShoping.Models;
using System.Data.Entity;

namespace ClothingShoping.Repository
{
    public interface IPicture : IRepository<Picture>
    {

    }
    public class PictureRepository : RepositoryBase<Picture>, IPicture
    {
        public ApplicationDbContext DbContext;

        public PictureRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
    }
}
