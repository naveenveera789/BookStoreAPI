using BusinessLayer.Interfaces;
using ModelLayer.Services;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class OrderBL : IOrderBL
    {
        IOrderRL orderRL;
        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }

        public string AddOrder(OrderModel orderModel)
        {
            try
            {
                return this.orderRL.AddOrder(orderModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DeleteOrder(int OrderId)
        {
            try
            {
                return this.orderRL.DeleteOrder(OrderId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<GetOrderModel> GetAllOrders(int UserId)
        {
            try
            {
                return this.orderRL.GetAllOrders(UserId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
