using ClothingShoping.Models;
using ClothingShoping.Data;
using System.Data.Entity;
namespace ClothingShoping.Repository
{
    public interface IProduct : IRepository<Product>
    {
        public IEnumerable<Product> GetListProductIncludeCategory();
        public IEnumerable<Product> GetListProductbySearchAndCategoryId(string SearchString,int? Id);

    }
    public class ProductRepository : RepositoryBase<Product>,IProduct
    {
        public ApplicationDbContext DbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
        public IEnumerable<Product> GetListProductIncludeCategory()
        {
            return DbContext.Products.Include(p => p.Category).ToList();
        }
        public IEnumerable<Product> GetListProductbySearchAndCategoryId(string SearchString,int? Id)
        {
            var query = DbContext.Products.Include(p => p.Category).AsNoTracking().AsQueryable();
            if (string.IsNullOrEmpty(SearchString))
            {
                DbContext.Products.Include(p => p.Category).Where(p => p.Name.Contains(SearchString));
            }
            if (Id.HasValue)
            {
                DbContext.Products.Include(p => p.Category).Where(p => p.CategoryId == Id);
            }
            return query;
        }

    }
}
