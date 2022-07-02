using ClothingShoping.Data;
using ClothingShoping.Models;
using System.Data.Entity;
namespace ClothingShoping.Repository
{
    public interface ICategory : IRepository<Category>
    {

    }
    public class CategoryRepository : RepositoryBase<Category>,ICategory
    {
        public ApplicationDbContext DbContext;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
    }
}
