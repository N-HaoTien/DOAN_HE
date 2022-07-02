using ClothingShoping.Data;
using ClothingShoping.Models;
using ClothingShoping.Repository;
namespace ClothingShoping.Services
{
    public interface IOrderItemService
    {
        public OrderItem GetDetail(int id);

        public OrderItem Add(OrderItem OrderItem);

        public void Update(OrderItem OrderItem);

        public void Delete(int id);

        public OrderItem Delete(OrderItem OrderItem);
        public Task<IEnumerable<OrderItem>> GetListOrderIncludeOrderItembyUser(string Id);

        public void Save();
    }
    public class OrderItemService : IOrderItemService
    {
        public IOrderItem _OrderItem;
        public IUnitOfWork _unitOfWork;

        public OrderItemService(IOrderItem _OrderItem, IUnitOfWork unitOfWork)
        {
            _OrderItem = _OrderItem;
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<OrderItem>> GetListOrderIncludeOrderItembyUser(string Id)
        {
            return _OrderItem.GetListOrderIncludeOrderItembyUser(Id);
        }
        public OrderItem GetDetail(int id)
        {
            return _OrderItem.GetSingleById(id);
        }

        public OrderItem Add(OrderItem OrderItem)
        {
            return _OrderItem.Add(OrderItem);
        }

        public void Update(OrderItem OrderItem)
        {
            _OrderItem.Update(OrderItem);
        }

        public void Delete(int id)
        {
            _OrderItem.Delete(id);
        }

        public OrderItem Delete(OrderItem OrderItem)
        {
            return _OrderItem.Delete(OrderItem);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
