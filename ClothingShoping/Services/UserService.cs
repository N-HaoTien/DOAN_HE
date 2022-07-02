using ClothingShoping.Data;
using ClothingShoping.Models;
using ClothingShoping.Repository;
using System.Data.Entity;
namespace ClothingShoping.Services
{
    public interface IUserService
    {
        public ApplicationUser GetDetail(int id);

        public ApplicationUser Add(ApplicationUser ApplicationUser);

        public void Update(ApplicationUser ApplicationUser);

        public void Delete(int id);

        public ApplicationUser Delete(ApplicationUser ApplicationUser);
        public IEnumerable<ApplicationUser> GetListApplicationUserByGroupId(string groupId);

        public void Save();
    }
    public class UserService : IUserService
    {
        public IUser _ApplicationUser;
        public IUnitOfWork _unitOfWork;

        public UserService(IUser _ApplicationUser, IUnitOfWork unitOfWork)
        {
            _ApplicationUser = _ApplicationUser;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ApplicationUser> GetListApplicationUserByGroupId(string Id)
        {
            return _ApplicationUser.GetListUserByGroupId(Id);
        }
        public ApplicationUser GetDetail(int id)
        {
            return _ApplicationUser.GetSingleById(id);
        }

        public ApplicationUser Add(ApplicationUser ApplicationUser)
        {
            return _ApplicationUser.Add(ApplicationUser);
        }

        public void Update(ApplicationUser ApplicationUser)
        {
            _ApplicationUser.Update(ApplicationUser);
        }

        public void Delete(int id)
        {
            _ApplicationUser.Delete(id);
        }

        public ApplicationUser Delete(ApplicationUser ApplicationUser)
        {
            return _ApplicationUser.Delete(ApplicationUser);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
