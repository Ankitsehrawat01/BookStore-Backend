using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IOrderBL
    {
        public bool addOrder(OrderModel orderModel, long UserId);
        public bool CancelOrder(long OrderId);
        public IEnumerable<GetOrderModel> GetAllOrders();
    }
}
