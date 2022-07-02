using ClothingShoping.Data;
using ClothingShoping.Models;
using ClothingShoping.Repository;
using System.Data.Entity;
namespace ClothingShoping.Services
{
    public interface IOrderService
    {
        public Order GetDetail(int id);

        public Order Add(Order Order);

        public void Update(Order Order);

        public void Delete(int id);

        public Order Delete(Order Order);
        public Task<IEnumerable<Order>> GetListOrderbyUser(string Id);
        public Task<IEnumerable<Order>> GetListOrderbyFromToDate(DateTime From, DateTime To);

        public void Save();
    }
    public class OrderService : IOrderService
    {
        public IOrder _Order;
        public IUnitOfWork _unitOfWork;

        public OrderService(IOrder _Order, IUnitOfWork unitOfWork)
        {
            _Order = _Order;
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Order>> GetListOrderbyFromToDate(DateTime From, DateTime To)
        {
            return _Order.GetListOrderbyFromToDate(From, To);
        }
        public Task<IEnumerable<Order>> GetListOrderbyUser(string Id)
        {
            return _Order.GetListOrderbyUser(Id);
        }
        public Order GetDetail(int id)
        {
            return _Order.GetSingleById(id);
        }

        public Order Add(Order Order)
        {
            return _Order.Add(Order);
        }

        public void Update(Order Order)
        {
            _Order.Update(Order);
        }

        public void Delete(int id)
        {
            _Order.Delete(id);
        }

        public Order Delete(Order Order)
        {
            return _Order.Delete(Order);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
