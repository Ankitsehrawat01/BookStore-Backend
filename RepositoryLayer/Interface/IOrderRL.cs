using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IOrderRL
    {
        public OrderModel addOrder(OrderModel orderModel, long UserId);
        public bool CancelOrder(long OrderId);
        public IEnumerable<GetOrderModel> GetAllOrders();
    }
}
