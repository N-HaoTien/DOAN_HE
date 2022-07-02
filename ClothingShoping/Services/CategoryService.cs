using ClothingShoping.Data;
using ClothingShoping.Models;
using ClothingShoping.Repository;
using System.Data.Entity;
namespace ClothingShoping.Services
{
    public interface ICategoryService
    {
        public Category GetDetail(int id);

        public IEnumerable<Category> GetAll(int page, int pageSize, out int totalRow, string filter);

        public IEnumerable<Category> GetAll();

        public Category Add(Category appRole);

        public void Update(Category AppRole);

        public void Delete(int id);

        public Category Delete(Category appRole);
        public void Save();
    }
    public class CategoryService : ICategoryService
    {
        private ICategory _category;
        private IUnitOfWork _unitOfWork;

        public CategoryService(ICategory category, IUnitOfWork unitOfWork)
        {
            _category = category;
            _unitOfWork = unitOfWork;
        }


        public Category Add(Category Category)
        {
            return _category.Add(Category);
        }

        public void Update(Category Category)
        {
            _category.Update(Category);
        }
        public Category GetDetail(int id)
        {
            return _category.GetSingleById(id);
        }

        public IEnumerable<Category> GetAll(int page, int pageSize, out int totalRow, string filter)
        {
            var query = _category.GetMulti(x => x.Status);

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Category> GetAll()
        {
            return _category.GetAll();
        }
        public void Delete(int id)
        {
            _category.Delete(id);
        }
        public Category Delete(Category Category)
        {
            return _category.Delete(Category);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
