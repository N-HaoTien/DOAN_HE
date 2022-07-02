using ClothingShoping.Data;
using ClothingShoping.Models;
using ClothingShoping.Repository;
using System.Data.Entity;
namespace ClothingShoping.Services
{
    public interface IPictureService
    {
        public IEnumerable<Picture> GetAll();
        public Picture GetDetail(int id);

        public Picture Add(Picture Picture);

        public void Update(Picture Picture);

        public void Delete(int id);

        public Picture Delete(Picture Picture);

        public void Save();
    }
    public class PictureService : IPictureService
    {
        public IPicture _Picture;
        public IUnitOfWork _unitOfWork;

        public PictureService(IComment _comment, IUnitOfWork unitOfWork)
        {
            _comment = _comment;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Picture> GetAll()
        {
            return _Picture.GetAll();
        }
        public void Delete(int id)
        {
            _Picture.Delete(id);
        }
        public Picture Delete(Picture Picture)
        {
            return _Picture.Delete(Picture);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
        public Picture Add(Picture Picture)
        {
            return _Picture.Add(Picture);
        }

        public void Update(Picture Picture)
        {
            _Picture.Update(Picture);
        }
        public Picture GetDetail(int id)
        {
            return _Picture.GetSingleById(id);
        }
    }
}
