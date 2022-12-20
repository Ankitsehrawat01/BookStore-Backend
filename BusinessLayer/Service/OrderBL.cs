using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class OrderBL : IOrderBL
    {
        private readonly IOrderRL iOrderRL;
        public OrderBL(IOrderRL iOrderRL)
        {
            this.iOrderRL = iOrderRL;
        }

        public bool addOrder(OrderModel orderModel, long UserId)
        {
            try
            {
                return iOrderRL.addOrder(orderModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool CancelOrder(long OrderId)
        {
            try
            {
                return iOrderRL.CancelOrder(OrderId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<GetOrderModel> GetAllOrders()
        {
            try
            {
                return iOrderRL.GetAllOrders();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
