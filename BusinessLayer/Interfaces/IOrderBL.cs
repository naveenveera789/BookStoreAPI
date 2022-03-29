using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IOrderBL
    {
        string AddOrder(OrderModel orderModel);
        string DeleteOrder(int OrderId);
        List<GetOrderModel> GetAllOrders(int UserId);
    }
}
