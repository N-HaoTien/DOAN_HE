using ClothingShoping.Data;
using ClothingShoping.Models;
using ClothingShoping.Repository;
using System.Data.Entity;
namespace ClothingShoping.Services
{
    public interface ICommentService
    {
        public Comment GetDetail(int id);

        public Comment Add(Comment Comment);

        public void Update(Comment Comment);

        public void Delete(int id);

        public Comment Delete(Comment Comment);
        public Task<IEnumerable<Comment>> GetListCommentIncludeAllUserbyProduct(int Id);

        public void Save();
    }
    public class CommentService : ICommentService
    {
        public IComment _comment;
        public IUnitOfWork _unitOfWork;

        public CommentService(IComment _comment, IUnitOfWork unitOfWork)
        {
            _comment = _comment;
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Comment>> GetListCommentIncludeAllUserbyProduct(int Id)
        {
            return _comment.GetListCommentIncludeAllUserbyProduct(Id);
        }
        public Comment GetDetail(int id)
        {
            return _comment.GetSingleById(id);
        }

        public Comment Add(Comment Comment)
        {
            return _comment.Add(Comment);
        }

        public void Update(Comment Comment)
        {
            _comment.Update(Comment);
        }

        public void Delete(int id)
        {
            _comment.Delete(id);
        }

        public Comment Delete(Comment Comment)
        {
            return _comment.Delete(Comment);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
