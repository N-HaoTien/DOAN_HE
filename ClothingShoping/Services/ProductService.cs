using ClothingShoping.Data;
using ClothingShoping.Models;
using ClothingShoping.Repository;
using System.Data.Entity;
namespace ClothingShoping.Services
{
    public interface IProductService
    {
        public Product GetDetail(int id);

        public Product Add(Product Product);

        public void Update(Product Product);

        public void Delete(int id);

        public Product Delete(Product Product);
        public Task<IEnumerable<Product>> GetListProductIncludeCategory();
        public Task<IEnumerable<Product>> GetListProductbySearchAndCategoryId(string SearchString, int? Id);

        public void Save();
    }
    public class ProductService : IProductService
    {
        public IProduct _Product;
        public IUnitOfWork _unitOfWork;

        public ProductService(IProduct _Product, IUnitOfWork unitOfWork)
        {
            _Product = _Product;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Product>> GetListProductIncludeCategory ()
        {
            return _Product.GetListProductIncludeCategory();
        }
        public async Task<IEnumerable<Product>> GetListProductbySearchAndCategoryId(string SearchString, int? Id)
        {
            return _Product.GetListProductbySearchAndCategoryId(SearchString,Id);
        }
        public Product GetDetail(int id)
        {
            return _Product.GetSingleById(id);
        }

        public Product Add(Product Product)
        {
            return _Product.Add(Product);
        }

        public void Update(Product Product)
        {
            _Product.Update(Product);
        }

        public void Delete(int id)
        {
            _Product.Delete(id);
        }

        public Product Delete(Product Product)
        {
            return _Product.Delete(Product);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
